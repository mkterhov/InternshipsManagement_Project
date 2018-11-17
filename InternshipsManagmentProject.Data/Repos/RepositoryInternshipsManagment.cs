using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace InternshipsManagmentProject.Data.Interfaces
{
    //NOT TO BE USED YET, UNDER DEVELOPMENT
    class RepositoryInternshipsManagment : IRepository
    {
        private readonly Entities _DataContext;

        public RepositoryInternshipsManagment(Entities DataContext)
        {
            _DataContext = DataContext;
        }


        //Add an entity by a model of an entity, in theory should work generic, but needs further investigation of the matter
        public void AddEntity<T>(T newItem) where T : class
        {
            _DataContext.Set<T>().Add(newItem);
            SaveAll();
        }
        //returns all the internships
        public IEnumerable<Internship> GetAllInternships()
        {
            return _DataContext.Internships.ToList();
        }
        //returns all the interships by firm that is holding them
        public IEnumerable<Internship> GetAllInternshipsByFirm(string FirmName)
        {
            return _DataContext.Internships.ToList().Where(internship=> internship.Firm.Name==FirmName).OrderBy(internship=>internship.Title);

        }
        //returns all the students, not sure if efficent
        public IEnumerable<Student> GetAllStudents()
        {
            return _DataContext.Students.ToList();
        }
        //returns a submitted application of a student to a particular internhsip
        public StudentInternship GetApplicationByUserNameAndInternshipId(string username, string internshipId)
        {
            return _DataContext.StudentInternships.
                Where(internshipStud=> internshipStud.Student.AspNetUser.UserName == username && internshipStud.InternshipId==internshipId).
                FirstOrDefault();

        }
        //returns a file by an id
        public File GetFileById(string idFile)
        {
            return _DataContext.Files.Where(file => file.FileId == idFile).FirstOrDefault();
        }
        //get image by an id 
        public Image GetImageById(string idImage)
        {
            return _DataContext.Images.Where(img => img.Id == idImage).FirstOrDefault();

        }
        //get internships by category
        public IEnumerable<Internship> GetInternshipsByCategory(string category)
        {
            return _DataContext.Internships.Where(internship=>internship.Category==category).ToList();
        }
        // get resume by id 
        public Resume GetResumeById(string idResume)
        {
            return _DataContext.Resumes.Where(resume=>resume.Id==idResume).FirstOrDefault();
        }
        //get student by userName 
        public Student GetStudentByUserName(string username)
        {
            return _DataContext.Students.Where(student => student.AspNetUser.UserName == username).FirstOrDefault();
        }

        //returns true if dataContext was able to save the changes, false otherwise
        public bool SaveAll()
        {
            return _DataContext.SaveChanges() > 0;
        }
    }
}
