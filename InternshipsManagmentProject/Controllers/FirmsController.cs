using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InternshipsManagmentProject.Data;
using InternshipsManagmentProject.Data.Interfaces;
using InternshipsManagmentProject.Models.FirmViewModels;

namespace InternshipsManagmentProject.Controllers
{
    public class FirmsController : Controller
    {
        private Entities db = new Entities();

        // GET: Firms
        public ActionResult Index()
        {
            var firms = db.Firms.Include(f => f.Image);
            return View(firms.ToList());
        }

        // GET: Firms/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firm firm = db.Firms.Find(id);
            if (firm == null)
            {
                return HttpNotFound();
            }
            return View(firm);
        }

        // GET: Firms/Create
        public ActionResult Create()
        {
            
            ViewBag.Logo = new SelectList(db.Images, "Id", "Name");
            return View();
        }

        // POST: Firms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description,NumberOfEmployees,Logo")] Firm firm)
        {
            if (ModelState.IsValid)
            {
                string guid = Guid.NewGuid().ToString();
                firm.FirmId = guid;
                db.Firms.Add(firm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Logo = new SelectList(db.Images, "Id", "Name", firm.Logo);
            return View(firm);
        }

        // GET: Firms/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firm firm = db.Firms.Find(id);
            if (firm == null)
            {
                return HttpNotFound();
            }
            ViewBag.Logo = new SelectList(db.Images, "Id", "Name", firm.Logo);
            return View(firm);
        }

        // POST: Firms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FirmId,Name,Description,NumberOfEmployees,Logo")] Firm firm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(firm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Logo = new SelectList(db.Images, "Id", "Name", firm.Logo);
            return View(firm);
        }

        // GET: Firms/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firm firm = db.Firms.Find(id);
            if (firm == null)
            {
                return HttpNotFound();
            }
            return View(firm);
        }

        // POST: Firms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Firm firm = db.Firms.Find(id);
            db.Firms.Remove(firm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult HomeFirma()
        {
            var userId = Session["UserId"].ToString();
            Recruiter recruiter = db.Recruiters.Where(a => a.UserId == userId).FirstOrDefault();
            Firm firm = recruiter.Firm;
            List<Internship> internships = Enumerable.ToList(db.Internships.Where(x => x.FirmOrganizerId == firm.FirmId).AsEnumerable());

            HomeFirm homeFirma = new HomeFirm(firm, internships);
            return View(homeFirma);
        }
        public ActionResult GestApl()
        {
            List<Student> lista = Enumerable.ToList(db.Students.AsEnumerable());
            GestAplicanti gestApl = new GestAplicanti(lista);
            return View(gestApl);
        }
    }
}
