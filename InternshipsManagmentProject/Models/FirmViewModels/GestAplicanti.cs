using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InternshipsManagmentProject.Data;

namespace InternshipsManagmentProject.Models.FirmViewModels
{
    public class GestAplicanti
    {
        public GestAplicanti(List<Student> list)
        {
            StudentiAplicanti = list;
        }
        public List<Student> StudentiAplicanti;

    }
}