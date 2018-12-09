using InternshipsManagmentProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternshipsManagmentProject.Controllers
{
    public class AnnouncmentController : Controller
    {
        Entities entities = new Entities();
        // GET: Announcment
        public ActionResult Index()
        {

            Internship internship = entities.Internships.FirstOrDefault();
            return View(internship);
        }
    }
}