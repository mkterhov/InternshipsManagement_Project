using InternshipsManagmentProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternshipsManagmentProject.Models
{
    public class HomeStudent
    {
        public List<string> ListOfIdsOfAppliedInternships { get; set; }
        //List<string> Categories;
        //string Keywords;
        public List<Internship> Internships { get; set; }
    }
}