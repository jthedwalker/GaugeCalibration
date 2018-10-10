using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using GaugeCalibration.Models;

namespace GaugeCalibration.Controllers
{
    public class CommentsController : Controller
    {
        private GaugeContext db = new GaugeContext();

        // GET: Comments/Create
        public ActionResult Create(int? id)
        {
            ViewBag.Serial = new SelectList(db.Gauges, "Id", "Serial");
         
            if (id != null)
            {
                ViewBag.GaugeId = new SelectList(db.Gauges.Where(g => g.Id == id), "Id", "Serial");
                
                return View();
            }

            return View();
        }

        // POST: Comments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Details", "Gauges", new {id = comment.GaugeId});
            }

            ViewBag.GaugeId = new SelectList(db.Gauges, "Id", "Serial", comment.GaugeId);
            return View(comment);
        }


        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.GaugeId = new SelectList(db.Gauges, "Id", "Serial", comment.GaugeId);
            return View(comment);
        }

        // POST: Comments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Gauges", new { id = comment.GaugeId });
            }
            ViewBag.GaugeId = new SelectList(db.Gauges, "Id", "Serial", comment.GaugeId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Details", "Gauges", new { id = comment.GaugeId });
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
