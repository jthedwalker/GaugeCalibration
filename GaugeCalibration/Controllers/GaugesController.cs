using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.WebPages;
using GaugeCalibration.Models;
using GaugeCalibration.ViewModels;

namespace GaugeCalibration.Controllers
{
    public class GaugesController : Controller
    {
        private GaugeContext db = new GaugeContext();

        // GET: Gauges
        public ActionResult Index(string plant)
        {
            if (!plant.IsEmpty())
            {
                return View(db.Gauges.Where(g => g.Plant == plant));
            }

            var gauges = db.Gauges;
            return View(gauges.ToList());
        }

        // GET: Gauges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gauge gauge = db.Gauges.Find(id);
            if (gauge == null)
            {
                return HttpNotFound();
            }
            return View(gauge);
        }

        // GET: Gauges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gauges/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gauge gauge)
        {
            if (ModelState.IsValid)
            {
                db.Gauges.Add(gauge);
                db.SaveChanges();
                return RedirectToAction("Index", "Gauges", new { plant = gauge.Plant });
            }

            return View(gauge);
        }

        // GET: Gauges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gauge gauge = db.Gauges.Find(id);
            if (gauge == null)
            {
                return HttpNotFound();
            }
            return View(gauge);
        }

        // POST: Gauges/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Gauge gauge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gauge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Gauges", new { plant = gauge.Plant});
            }
            return View(gauge);
        }

        // GET: Gauges/Edit/5
        public ActionResult Entry(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = new EntryViewModel();
            var gauge = db.Gauges.Find(id);
            viewModel.Gauge = gauge;
            if (gauge == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // POST: Gauges/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Entry(EntryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = db.Gauges.Find(viewModel.Gauge.Id);
                result.LastCal = viewModel.Gauge.LastCal;
                result.NextCal = viewModel.Gauge.NextCal;
                result.Status = result.Status;
                
                var comment = new Comment();
                comment.GaugeId = viewModel.Gauge.Id;
                comment.Date = viewModel.Comments.Date;
                comment.Name = viewModel.Comments.Name;
                comment.Text = viewModel.Comments.Text;

                db.Comments.Add(comment);
                
                db.SaveChanges();
                return RedirectToAction("Index", "Gauges", new { plant = result.Plant});
            }
            return View(viewModel);
        }

        // GET: Gauges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gauge gauge = db.Gauges.Find(id);
            if (gauge == null)
            {
                return HttpNotFound();
            }
            return View(gauge);
        }

        // POST: Gauges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gauge gauge = db.Gauges.Find(id);
            db.Gauges.Remove(gauge);
            db.SaveChanges();
            return RedirectToAction("Index", "Gauges", new { plant = gauge.Plant});
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
