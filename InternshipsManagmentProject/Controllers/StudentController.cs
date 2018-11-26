using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InternshipsManagmentProject.Data;
namespace InternshipsManagmentProject.Controllers
{
    public class StudentController : Controller
    {
        Student student = new Student
        {
            Name = "Abdu",
            LastName = "Akbar",
            University = "UBoomBoom",
            Domain = "Public Detonations",
            Birthday = DateTime.Today,
            Bio = "An explosive man with terrorizingly religious skills!",
            StudentInternships = new List<StudentInternship>()
        };

        public ActionResult StudentProfile(int selection = 0)
        {
            
            StudentInternship si0 = new StudentInternship();
            Internship i0 = new Internship
            {
                Title = "Noob Internship",
                Description = "Place your laptop on a flat surface to stop the pointers from dangling. Sure hope you got your lego pieces to build the project and then run, run because... erm... it's going to explode!"
            };
            si0.Internship = i0;
            si0.StatusOfApplication = false;
            si0.Completed = false;
            si0.StarredForFurtherReview = false;
            student.StudentInternships.Add(si0);

            StudentInternship si1 = new StudentInternship();
            Internship i1 = new Internship
            {
                Title = "Motor-Disabled Internship",
                Description = "Perfect! Now imagine a cursor flying around and drag your dreams in the Recycle Bin. Blink twice to right click and then fart to empty Recycle Bin."
            };
            si1.Internship = i1;
            si1.StatusOfApplication = true;
            si1.Completed = true;
            si1.StarredForFurtherReview = false;
            student.StudentInternships.Add(si1);

            StudentInternship si2 = new StudentInternship();
            Internship i2 = new Internship
            {
                Title = "Actual Internship",
                Description = "Well hey let's just run this command with zero knowledge of the underlaying shenanigans and hope that it has the same result on a dozen different systems! Iiiiiiha!!!"
            };
            si2.Internship = i2;
            si2.StatusOfApplication = true;
            si2.Completed = false;
            si2.StarredForFurtherReview = false;
            student.StudentInternships.Add(si2);

            StudentInternship si3 = new StudentInternship();
            Internship i3 = new Internship
            {
                Title = "Random Internship",
                Description = "all hail 47 our lord and saviour"
            };
            si3.Internship = i3;
            si3.StatusOfApplication = true;
            si3.Completed = true;
            si3.StarredForFurtherReview = true;
            student.StudentInternships.Add(si3);

            ViewBag.Selection = selection;
            return View(student);
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