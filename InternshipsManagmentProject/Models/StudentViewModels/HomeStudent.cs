using InternshipsManagmentProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternshipsManagmentProject.Models
{
    public class HomeStudent
    {
        public HomeStudent() { }
        public HomeStudent(Student student, List<Internship> internships, List<String> list)
        {
            Student = student;
            Internships = internships;
            ListOfIdsOfAppliedInternships = list;
        }

        public List<string> ListOfIdsOfAppliedInternships { get; set; }
        public List<Internship> Internships { get; set; }
        public Student Student { get; set; }

    }
}