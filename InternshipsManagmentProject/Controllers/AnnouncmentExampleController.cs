using InternshipsManagmentProject.Data;
using InternshipsManagmentProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternshipsManagmentProject.Controllers
{
    public class AnnouncmentExampleController : Controller
    {
        Entities entities = new Entities();
        // GET: AnnouncmentExample
        public ActionResult Index()
        {
            List<AnnouncementExampleDTO> list = GetAnnouncements();

            return View(list);
        }
        public List<AnnouncementExampleDTO> GetAnnouncements()
        {
            List<AnnouncementExampleDTO> list = new List<AnnouncementExampleDTO>();
            for (int i = 0; i < entities.Internships.Count(); i++) {
                Internship intr = entities.Internships.Where(a => a.PositionsAvailable > 0).FirstOrDefault();
                AnnouncementExampleDTO dTO = new AnnouncementExampleDTO
                {
                    InternshipInQuestion = intr,
                FirmHolder = intr.Firm,
                Recruiter = intr.Recruiter

                };
                list.Add(dTO);
            }

            return list;
        }
             
    }
}