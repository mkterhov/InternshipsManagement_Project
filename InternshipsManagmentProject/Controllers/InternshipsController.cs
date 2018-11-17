using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InternshipsManagmentProject.Data;

namespace InternshipsManagmentProject.Controllers
{
    public class InternshipsController : Controller
    {
        private Entities db = new Entities();

        // GET: Internships
        public ActionResult Index()
        {
            var internships = db.Internships.Include(i => i.Firm).Include(i => i.Image).Include(i => i.Recruiter);
            return View(internships.ToList());
        }
        

        // GET: Internships/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Internship internship = db.Internships.Find(id);
            if (internship == null)
            {
                return HttpNotFound();
            }
            return View(internship);
        }

        // GET: Internships/Create
        public ActionResult Create()
        {
            ViewBag.FirmOrganizerId = new SelectList(db.Firms, "FirmId", "Name");
            ViewBag.InternshipPostPhoto = new SelectList(db.Images, "Id", "Name");
            ViewBag.RecruiterResponsibleId = new SelectList(db.Recruiters, "RecruiterId", "Name");
            return View();
        }

        // POST: Internships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirmOrganizerId,RecruiterResponsibleId,StartDate,EndDate,Description,City,PositionsAvailable,InternshipPostPhoto,Category,Title")] Internship internship)
        {
            if (ModelState.IsValid)
            {
                string guid = Guid.NewGuid().ToString();
                internship.InternshipId = guid;
                db.Internships.Add(internship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FirmOrganizerId = new SelectList(db.Firms, "FirmId", "Name", internship.FirmOrganizerId);
            ViewBag.InternshipPostPhoto = new SelectList(db.Images, "Id", "Name", internship.InternshipPostPhoto);
            ViewBag.RecruiterResponsibleId = new SelectList(db.Recruiters, "RecruiterId", "Name", internship.RecruiterResponsibleId);
            return View(internship);
        }

        // GET: Internships/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Internship internship = db.Internships.Find(id);
            if (internship == null)
            {
                return HttpNotFound();
            }
            ViewBag.FirmOrganizerId = new SelectList(db.Firms, "FirmId", "Name", internship.FirmOrganizerId);
            ViewBag.InternshipPostPhoto = new SelectList(db.Images, "Id", "Name", internship.InternshipPostPhoto);
            ViewBag.RecruiterResponsibleId = new SelectList(db.Recruiters, "RecruiterId", "Name", internship.RecruiterResponsibleId);
            return View(internship);
        }

        // POST: Internships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InternshipId,FirmOrganizerId,RecruiterResponsibleId,StartDate,EndDate,Description,City,PositionsAvailable,InternshipPostPhoto,Category,Title")] Internship internship)
        {
            if (ModelState.IsValid)
            {
                db.Entry(internship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FirmOrganizerId = new SelectList(db.Firms, "FirmId", "Name", internship.FirmOrganizerId);
            ViewBag.InternshipPostPhoto = new SelectList(db.Images, "Id", "Name", internship.InternshipPostPhoto);
            ViewBag.RecruiterResponsibleId = new SelectList(db.Recruiters, "RecruiterId", "Name", internship.RecruiterResponsibleId);
            return View(internship);
        }

        // GET: Internships/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Internship internship = db.Internships.Find(id);
            if (internship == null)
            {
                return HttpNotFound();
            }
            return View(internship);
        }

        // POST: Internships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Internship internship = db.Internships.Find(id);
            db.Internships.Remove(internship);
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
    }
}
