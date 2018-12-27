using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipsManagmentProject.Data.Interfaces
{
    public interface IRepository
    {
        File GetById(string guid);

        void AddEntity<T>(T newItem) where T : class;

        void UpdateEntity<T>(T newItem, string guid) where T : class;
    }
}
