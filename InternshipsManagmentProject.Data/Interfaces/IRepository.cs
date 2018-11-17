using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipsManagmentProject.Data.Interfaces
{
    internal interface IRepository
    {
        File GetFileById(string idFile);

        Resume GetResumeById(string idResume);

        Image GetImageById(string idImage);


        IEnumerable<Internship> GetInternshipsByCategory(string category);
        IEnumerable<Internship> GetAllInternships();

        IEnumerable<Student> GetAllStudents();
        Student GetStudentByUserName(string username);

        IEnumerable<Internship> GetAllInternshipsByFirm(string FirmName);
        StudentInternship GetApplicationByUserNameAndInternshipId(string username, string id);

        bool SaveAll();
        void AddEntity<T>(T newItem) where T : class;
    }
}
