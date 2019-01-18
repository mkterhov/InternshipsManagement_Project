using InternshipsManagmentProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternshipsManagmentProject.Models.FirmViewModels
{
    public class HomeFirm
    {
        public HomeFirm(Firm firm, List<Internship> internships)
        {
            Firm = firm;
            FirmInternships = internships;
        }
        public Firm Firm;
        public List<Internship> FirmInternships;
    }
}