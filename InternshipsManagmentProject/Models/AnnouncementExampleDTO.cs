using InternshipsManagmentProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternshipsManagmentProject.Models
{
    public class AnnouncementExampleDTO
    {
        public Firm  FirmHolder { get; set; }

        public Internship InternshipInQuestion { get; set; }
        public Recruiter Recruiter { get; set; }

    }
}