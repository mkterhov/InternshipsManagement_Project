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
    public class StudentsAccountDetailsController : Controller
    {
        private Entities db = new Entities();

        // GET: StudentsAccountDetails
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.AspNetUser).Include(s => s.Resume);
            return View(students.ToList());
        }

        // GET: StudentsAccountDetails/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: StudentsAccountDetails/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.StudentCV = new SelectList(db.Resumes, "Id", "Name");
            return View();
        }

        // POST: StudentsAccountDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,LastName,UserId,University,Domain,Bio,Birthday,LevelOfStudies,Available,StudentCV")] Student student)
        {
            if (ModelState.IsValid)
            {
                string guid = Guid.NewGuid().ToString();
                student.StudentId = guid;
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", student.UserId);
            ViewBag.StudentCV = new SelectList(db.Resumes, "Id", "Name", student.StudentCV);
            return View(student);
        }

        // GET: StudentsAccountDetails/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", student.UserId);
            ViewBag.StudentCV = new SelectList(db.Resumes, "Id", "Name", student.StudentCV);
            return View(student);
        }

        // POST: StudentsAccountDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,Name,LastName,UserId,University,Domain,Bio,Birthday,LevelOfStudies,Available,StudentCV")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", student.UserId);
            ViewBag.StudentCV = new SelectList(db.Resumes, "Id", "Name", student.StudentCV);
            return View(student);
        }

        // GET: StudentsAccountDetails/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: StudentsAccountDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
