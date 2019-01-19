using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InternshipsManagmentProject.Data;

namespace InternshipsManagmentProject.Controllers
{
    public class StudentInternshipsController : Controller
    {
        private const string ContentPath = "~/Content/Images/";
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
        //public ActionResult Create()
        //{
           
        //    return View();
        //}
        public ActionResult Create(string internshipId=null)
        {
            if(internshipId!=null)
                Session["InternshipId"] = internshipId;
            return View();
        }
        // POST: StudentInternships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "StudentId,InternshipId,DateCreated,Completed,Updates,SubmitedResume,StatusOfApplication,StudentResumeId,StarredForFurtherReview")] StudentInternship studentInternship)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var userId = Session["UserId"].ToString();
        //       // ViewBag.InternshipId = id;
        //        //ViewBag.SubmitedResume = new SelectList(db.Resumes, "Id", "Name");
        //        //ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name");
        //        studentInternship.StudentId = Session["UserId"].ToString();
        //        var studId = db.Students.Where(st => st.UserId == userId).FirstOrDefault().StudentId;
        //        studentInternship.StudentId = studId;
        //        db.StudentInternships.Add(studentInternship);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.InternshipId = new SelectList(db.Internships, "InternshipId", "FirmOrganizerId", studentInternship.InternshipId);
        //    ViewBag.SubmitedResume = new SelectList(db.Resumes, "Id", "Name", studentInternship.SubmitedResume);
        //    ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name", studentInternship.StudentId);
        //    return View(studentInternship);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubmitedResume,Updates")] StudentInternship studentInternship, HttpPostedFileBase SubmitedResume, string internshipId = null)
        {
            if (ModelState.IsValid)
            {
                var userId = Session["UserId"].ToString();
                // ViewBag.InternshipId = id;
                //ViewBag.SubmitedResume = new SelectList(db.Resumes, "Id", "Name");
                //ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Name");
                studentInternship.StudentId = Session["UserId"].ToString();
                studentInternship.Stage = "0";
                studentInternship.DateCreated =DateTime.Today;
                studentInternship.InternshipId = Session["InternshipId"].ToString();
                var studId = db.Students.Where(st => st.UserId == userId).FirstOrDefault().StudentId;
                studentInternship.StudentId = studId;
                studentInternship.StatusOfApplication = false;
                studentInternship.Completed = false;
                studentInternship.StarredForFurtherReview = false;
                studentInternship.StudentUserId = userId;
                studentInternship.Completed = false;
                studentInternship.StarredForFurtherReview = false;
                studentInternship.Hidden = false;


                Data.Resume fileToSave = new Data.Resume();

                if (SubmitedResume != null)
                {
                    var fileName = Path.GetFileName(SubmitedResume.FileName);
                    var directoryToSave = Server.MapPath(Url.Content(ContentPath));
                    string GuidFileName = Guid.NewGuid().ToString() + ".pdf";
                    var pathToSave = Path.Combine(directoryToSave, GuidFileName);
                    SubmitedResume.SaveAs(pathToSave);
                    fileToSave.Name = GuidFileName;
                    fileToSave.Path = pathToSave;
                    fileToSave.Id = Guid.NewGuid().ToString();
                    db.Resumes.Add(fileToSave);
                    studentInternship.Resume = fileToSave;
                }
                
                db.StudentInternships.Add(studentInternship);
                db.SaveChanges();
                return RedirectToAction("StudentProfile","Student");
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
