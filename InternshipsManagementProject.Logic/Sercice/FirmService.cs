using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternshipsManagmentProject.Data.Interfaces;

namespace InternshipsManagementProject.Logic.Sercice
{
    public class FirmService
    {
        private IRepository repo;

        public FirmService(string connectionString)
        {
            this.repo = new RepositoryInternshipsManagment();
        }

        public string GetFirmById(string guid)
        {

        }
    }
}
