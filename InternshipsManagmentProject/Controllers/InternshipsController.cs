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
        List<Internship> ins = new List<Internship>
            {
                new Internship()
                {
                    Title = "internship",
                    Comments = new List<Comment> { new Comment() { Content = "This is a comment" }, new Comment() { Content = "This is another comment" } },
                    Category = "cat",
                    City = "Oz",
                    Department = "dep",
                    Description = "des",
                    EndDate = new DateTime(),
                    StartDate = new DateTime(),
                    Keywords = "keys",
                    Recruiter = new Recruiter() { Name = "name", UserId = "id" },
                    PositionsAvailable = 30,
                    Deleted = false,
                    Hidden = false,
                    InternshipId = "in_id_test",
                    RecruiterResponsibleId = "r_id",
                    TypeJob = "type_job",
                    Duration = "duration",
                    InternshipPostPhoto = "photo",
                    FirmOrganizerId = "f_id",
                    StudentInternships = null,
                    DeadlineApplications = new DateTime(),
                    LastUpdated = new DateTime(),
                    Files = null,
                    Firm = new Firm() { Name = "Firm", Logo = "logo", Description = "desc", Deleted = false, FirmId = "f_id" },
                    Image = null
                }
            };

        private Entities db = new Entities();
        private InternshipsManagementProject.Logic.Sercice.InternshipService service = new InternshipsManagementProject.Logic.Sercice.InternshipService();

        // GET: Internships
        public ActionResult Index()
        {
            var internships = db.Internships.Include(i => i.Firm).Include(i => i.Image).Include(i => i.Recruiter);
            service = new InternshipsManagementProject.Logic.Sercice.InternshipService();
            //var internships = service.GetAll();

            if(internships.Count() == 0) return View(ins);
            if (internships.Count()>0)
                return View(internships.ToList());
            else
                return View("~\\Shared\\Error.cshtml");
        }


        // GET: Internships/Details/5
        public ActionResult Details(string id, string comm_txt = null, string comm_file = null)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id == "in_id_test")
            {
                if (comm_txt != null) {
                    Comment c = new Comment() { CommentId = "100percentunique", Content = comm_txt, DateCreated = new DateTime() };
                    if (comm_file != null) c.Files = new List<File>() { new Data.File() { FileName = comm_file } };
                    ins[0].Comments.Add(c);
                }
                return View(ins[0]);
            }
            Internship internship = db.Internships.Find(id);
            if (internship == null)
            {
                return HttpNotFound();
            }
            if (comm_txt != null) {
                Comment c = new Comment() { CommentId = "100percentunique", Content = comm_txt, DateCreated = new DateTime() };
                if (comm_file != null) c.Files = new List<File>() { new Data.File() { FileName = comm_file } };
                internship.Comments.Add(c);
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
        public ActionResult Create([Bind(Include = "StartDate,EndDate,Description,City,PositionsAvailable,InternshipPostPhoto,Category,Title")] Internship internship)
        {
            if (ModelState.IsValid)
            {
                string guid = Guid.NewGuid().ToString();
                internship.InternshipId = guid;
                var userId = Session["UserId"].ToString();
                Recruiter recruiter = db.Recruiters.Where(a => a.UserId == userId).FirstOrDefault();
                Firm firm = recruiter.Firm;
                internship.FirmOrganizerId = firm.FirmId;
                internship.RecruiterResponsibleId = recruiter.RecruiterId;
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
            if (id == "in_id_test")
            {
                return View(ins[0]);
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
        public ActionResult Edit([Bind(Include = " InternshipId,FirmOrganizerId,RecruiterResponsibleId,StartDate,EndDate,Description,City,PositionsAvailable,InternshipPostPhoto,Category,Title")] Internship internship)
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
