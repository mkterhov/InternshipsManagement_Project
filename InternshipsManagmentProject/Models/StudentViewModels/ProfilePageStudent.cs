using InternshipsManagmentProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternshipsManagmentProject.Models
{
    public class ProfilePageStudent
    {
        Student Student;
        List<StudentInternship> AppliedInternships;
        List<Email> StudentEmails;
        List<Internship> StudentInternships;
    }
}