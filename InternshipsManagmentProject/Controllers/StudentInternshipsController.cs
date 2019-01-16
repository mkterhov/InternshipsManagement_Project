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
    public class StudentInternshipsController : Controller
    {
        private Entities db = new Entities();

        // GET: StudentInternships
        public ActionResult Index()
        {
            var studentInternships = db.StudentInternships.Include(s => s.Internship).Include(s => s.Resume).Include(s => s.Student);
            return View(studentInternships.ToList());
        }

        // GET: StudentInternships/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInternship studentInternship = db.StudentInternships.Find(id);
            if (studentInternship == null)
            {
                return HttpNotFound();
            }
            return View(studentInternship);
        }

        // GET: StudentInternships/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: StudentInternships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,InternshipId,StudentUserId,DateCreated,Completed,Updates,SubmitedResume,StatusOfApplication,StudentResumeId,StarredForFurtherReview")] StudentInternship studentInternship)
        {
            if (ModelState.IsValid)
            {
               // ViewBag.InternshipId = id;
                //ViewBag.SubmitedResume = new SelectList(db.Resumes, "Id", "Name");
                //ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name");
                ViewBag.StudentId = Session["UserId"];
                db.StudentInternships.Add(studentInternship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InternshipId = new SelectList(db.Internships, "InternshipId", "FirmOrganizerId", studentInternship.InternshipId);
            ViewBag.SubmitedResume = new SelectList(db.Resumes, "Id", "Name", studentInternship.SubmitedResume);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name", studentInternship.StudentId);
            return View(studentInternship);
        }

        // GET: StudentInternships/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInternship studentInternship = db.StudentInternships.Find(id);
            if (studentInternship == null)
            {
                return HttpNotFound();
            }
            ViewBag.InternshipId = new SelectList(db.Internships, "InternshipId", "FirmOrganizerId", studentInternship.InternshipId);
            ViewBag.SubmitedResume = new SelectList(db.Resumes, "Id", "Name", studentInternship.SubmitedResume);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name", studentInternship.StudentId);
            return View(studentInternship);
        }

        // POST: StudentInternships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,InternshipId,StudentUserId,DateCreated,Completed,Updates,SubmitedResume,StatusOfApplication,StudentResumeId,StarredForFurtherReview")] StudentInternship studentInternship)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentInternship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InternshipId = new SelectList(db.Internships, "InternshipId", "FirmOrganizerId", studentInternship.InternshipId);
            ViewBag.SubmitedResume = new SelectList(db.Resumes, "Id", "Name", studentInternship.SubmitedResume);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name", studentInternship.StudentId);
            return View(studentInternship);
        }

        // GET: StudentInternships/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInternship studentInternship = db.StudentInternships.Find(id);
            if (studentInternship == null)
            {
                return HttpNotFound();
            }
            return View(studentInternship);
        }

        // POST: StudentInternships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StudentInternship studentInternship = db.StudentInternships.Find(id);
            db.StudentInternships.Remove(studentInternship);
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
