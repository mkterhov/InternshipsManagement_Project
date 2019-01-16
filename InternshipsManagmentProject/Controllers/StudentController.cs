using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InternshipsManagmentProject.Data;
using InternshipsManagmentProject.Models;

namespace InternshipsManagmentProject.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        Entities entities = new Entities();
        Student student;
        //    new Student
        //{
        //    Name = "Abdu",
        //    LastName = "Akbar",
        //    University = "UBoomBoom",
        //    Domain = "Public Detonations",
        //    Birthday = DateTime.Today,
        //    Bio = "An explosive man with terrorizingly religious skills!",
        //    StudentInternships = new List<StudentInternship>()
        //};

        public ActionResult StudentHome()
        {
            HomeStudent homeStudent = new HomeStudent();
            string UserId = Session["UserId"].ToString();
            Student student = entities.Students.Where(user => user.UserId == UserId).FirstOrDefault();
            if (student != null && student.StudentInternships.Count > 0)
            {
                foreach(var studentInternship in student.StudentInternships.ToList()){
                    homeStudent.ListOfIdsOfAppliedInternships.Add(studentInternship.StudentId);

                }
            }
            homeStudent.Internships = entities.Internships.ToList();
            return View(homeStudent);
        }


        public StudentController() {
            //Console.WriteLine("CONSTRUCTOR");
            //StudentInternship si0 = new StudentInternship();
            //Internship i0 = new Internship
            //{
            //    Title = "Noob Internship",
            //    Description = "Place your laptop on a flat surface to stop the pointers from dangling. Sure hope you got your lego pieces to build the project and then run, run because... erm... it's going to explode!"
            //};
            //si0.Internship = i0;
            //si0.StatusOfApplication = false;
            //si0.Completed = false;
            //si0.StarredForFurtherReview = false;
            //student.StudentInternships.Add(si0);

            //StudentInternship si1 = new StudentInternship();
            //Internship i1 = new Internship
            //{
            //    Title = "Motor-Disabled Internship",
            //    Description = "Perfect! Now imagine a cursor flying around and drag your dreams in the Recycle Bin. Blink twice to right click and then fart to empty Recycle Bin."
            //};
            //si1.Internship = i1;
            //si1.StatusOfApplication = true;
            //si1.Completed = true;
            //si1.StarredForFurtherReview = false;
            //student.StudentInternships.Add(si1);

            //StudentInternship si2 = new StudentInternship();
            //Internship i2 = new Internship
            //{
            //    Title = "Actual Internship",
            //    Description = "Well hey let's just run this command with zero knowledge of the underlaying shenanigans and hope that it has the same result on a dozen different systems! Iiiiiiha!!!"
            //};
            //si2.Internship = i2;
            //si2.StatusOfApplication = true;
            //si2.Completed = false;
            //si2.StarredForFurtherReview = false;
            //student.StudentInternships.Add(si2);

            //StudentInternship si3 = new StudentInternship();
            //Internship i3 = new Internship
            //{
            //    Title = "Random Internship",
            //    Description = "all hail 47 our lord and saviour"
            //};
            //si3.Internship = i3;
            //si3.StatusOfApplication = true;
            //si3.Completed = true;
            //si3.StarredForFurtherReview = true;
            //student.StudentInternships.Add(si3);

            //StudentInternship si4 = new StudentInternship();
            //Internship i4 = new Internship
            //{
            //    Title = "Yet Another Internship",
            //    Description = "YACK!"
            //};
            //si4.Internship = i4;
            //si4.StatusOfApplication = false;
            //si4.Completed = false;
            //si4.StarredForFurtherReview = true;
            //student.StudentInternships.Add(si4);
        }
        //[Bind(Include = "Name,LastName,UserId,University,Domain,Bio,Birthday,LevelOfStudies,Available,StudentCV")] Student createOrUpdateStudent = null
        [HttpGet]
        public ActionResult StudentProfile(string idStudent=null, int selection = 0, string imagePath = "")
        {
            string UserId = Session["UserId"].ToString();
            if (idStudent != null)
            {
                student = entities.Students.Find(idStudent);
            }
            if (idStudent == null)
            {
                
                student = entities.Students.Where(user => user.UserId == UserId).ToList().FirstOrDefault() ;
            }
            if (imagePath.Length>0) {
                //load image pls
            }
            
            ViewBag.Selection = selection;
            //if (createOrUpdateStudent.Name!=null) {
            //    student = createOrUpdateStudent;
            //}
            return View(student);
        }

        public ActionResult StudentRegister()
        {
            Student student = entities.Students.Find(Session["UserId"]);
            if(student!=null)
            {
                return View(student);
            }
            return View(new Student());
        }
        [HttpPost]
        public ActionResult StudentRegister([Bind(Include = "Name,LastName,UserId,University,Domain,Bio,Birthday,WebsiteLink,LevelOfStudies,Available,StudentCV")] Student createOrUpdateStudent)
        {
            if (ModelState.IsValid)
            {

                string studentId = entities.Students.Where(st => st.UserId == createOrUpdateStudent.UserId).ToList().FirstOrDefault().StudentId;
                createOrUpdateStudent.StudentId = studentId;

                Student updateStudent = entities.Students.Find(studentId);
                entities.Entry(updateStudent).CurrentValues.SetValues(createOrUpdateStudent);

                entities.SaveChanges();

                return RedirectToAction("StudentProfile");

            }
            return RedirectToAction("StudentProfile");

        }
        [HttpPost]
        public void StudentUpdate()
        {
            student.Name = Request["Name"];
            student.LastName = Request["LastName"];
            student.University = Request["University"];
            student.Domain = Request["Domain"];
            //student.Birthday = DateTime.Parse(Request["Birthday"]);
            student.Bio = Request["Bio"];
            Console.WriteLine("New Name:" + Request["Name"]);
            Console.WriteLine("New Last Name:" + Request["LastName"]);

        }

        public void StudentFirmResponse(bool response, string id)
        {

        }

        public void StudentFirmRating(int rating, string id)
        {

        }
    }
}