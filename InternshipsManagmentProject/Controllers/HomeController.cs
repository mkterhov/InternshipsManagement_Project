using InternshipsManagmentProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternshipsManagmentProject.Controllers
{
    public class HomeController : Controller
    {
        private Entities db = new Entities();
        [HttpGet]
        public ActionResult Index()
        {

            var internships = db.Internships.AsEnumerable();
            return View(internships);
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            var internships = db.Internships.Where(x => x.Title.Contains(search) || x.Title.Equals(search));
            return View(internships);
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