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
    [Authorize(Roles ="Recruiter")]
    public class RecruitersAccountDetailsController : Controller
    {
        private Entities db = new Entities();

        // GET: RecruitersAccountDetails
        public ActionResult Index()
        {
            var recruiters = db.Recruiters.Include(r => r.AspNetUser).Include(r => r.Firm);
            return View(recruiters.ToList());
        }

        // GET: RecruitersAccountDetails/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recruiter recruiter = db.Recruiters.Find(id);
            if (recruiter == null)
            {
                return HttpNotFound();
            }
            return View(recruiter);
        }

        // GET: RecruitersAccountDetails/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.FirmId = new SelectList(db.Firms, "FirmId", "Name");
            return View();
        }

        // POST: RecruitersAccountDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,LastName,FirmId,ContactEmail,Bio")] Recruiter recruiter)
        {
            if (ModelState.IsValid)
            {
                string guid = Guid.NewGuid().ToString();
                recruiter.RecruiterId = guid;
                recruiter.UserId = Session["UserId"].ToString();
                db.Recruiters.Add(recruiter);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", recruiter.UserId);
            ViewBag.FirmId = new SelectList(db.Firms, "FirmId", "Name", recruiter.FirmId);
            return View(recruiter);
        }

        // GET: RecruitersAccountDetails/Edit/5
        public ActionResult Edit(string id)
        {
            if(Session["UserId"] != null)
            {
                id = Session["UserId"].ToString();
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            
            Recruiter recruiter = db.Recruiters.Where(x => x.UserId == id).FirstOrDefault();
            if (recruiter == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", recruiter.UserId);
            ViewBag.FirmId = new SelectList(db.Firms, "FirmId", "Name", recruiter.FirmId);
            return View(recruiter);
        }

        // POST: RecruitersAccountDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecruiterId,Name,LastName,FirmId,ContactEmail,Bio,UserId")] Recruiter recruiter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recruiter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", recruiter.UserId);
            ViewBag.FirmId = new SelectList(db.Firms, "FirmId", "Name", recruiter.FirmId);
            return View(recruiter);
        }

        // GET: RecruitersAccountDetails/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recruiter recruiter = db.Recruiters.Find(id);
            if (recruiter == null)
            {
                return HttpNotFound();
            }
            return View(recruiter);
        }

        // POST: RecruitersAccountDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Recruiter recruiter = db.Recruiters.Find(id);
            db.Recruiters.Remove(recruiter);
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
