using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GaugeCalibration.Models;

namespace GaugeCalibration.Controllers
{
    public class HomeController : Controller
    {
        private GaugeContext db = new GaugeContext();

        public ActionResult Index()
        {
            var list = db.Gauges.Select(g => g.Plant).Distinct();
            ViewBag.Plant = new SelectList(list);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}