using InternshipsManagementProject.Logic.Models;
using InternshipsManagmentProject.Data;
using InternshipsManagmentProject.Data.Repos;
using System;
using System.Collections.Generic;

namespace InternshipsManagementProject.Logic.Sercice
{
    public class StudentService
    {
        private RepositoryGenericDRH<Student> _repo = new RepositoryGenericDRH<Student>();


        public void InternsipService()
        {
            this._repo = new RepositoryGenericDRH<Student>();
        }

        public LogicResponseHandler<Student> GetById(string id)
        {
            var result = _repo.GetById(id);
            if (result.Succes)
            {
                return new LogicResponseHandler<Student> { Content = result.Container, Status = result.Succes };
            }
            else
            {
                return new LogicResponseHandler<Student> { Status = false };
            }
        }

        public LogicResponseHandler<IEnumerable<Student>> GetAll()
        {
            var result = _repo.GetAll();
            if (result.Succes)
            {
                return new LogicResponseHandler<IEnumerable<Student>> { Content = result.Container, Status = result.Succes };
            }
            else
            {
                return new LogicResponseHandler<IEnumerable<Student>> { Status = false };
            }
        }

        public LogicResponseHandler<string> AddEntity(bool? available, DateTime birthday,
        string domain,string faculty,string levelOfStudies,Resume resume,string skills,
        string websiteLink,string university,bool? subscribed,
        ICollection<StudentInternship> studentInternships,string studentId,string studentCV,
        AspNetUser aspNetUser,string bio,bool? deleted,string lastName,string name,string userId)
        {
            var result = _repo.AddEntity(
                new Student
                {
                    AspNetUser = aspNetUser,
                    Bio = bio,
                    Deleted = deleted,
                    LastName = lastName,
                    Name = name,
                    UserId = userId,
                    Available = available,
                    Birthday = birthday,
                    Domain = domain,
                    Faculty = faculty,
                    LevelOfStudies = levelOfStudies,
                    Resume = resume,
                    Skills = skills,
                    StudentCV = studentCV,
                    StudentId = studentId,
                    StudentInternships = studentInternships,
                    Subscribed = subscribed,
                    University = university,
                    WebsiteLink = websiteLink
                });

            if (result.Succes)
            {
                return new LogicResponseHandler<string> { Status = true, Content = "Succes!" };
            }
            else
            {
                return new LogicResponseHandler<string> { Status = false, Content = result.Container };
            }
        }

        public LogicResponseHandler<string> UpdateEntity(bool? available, DateTime birthday,
        string domain, string faculty, string levelOfStudies, Resume resume, string skills,
        string websiteLink, string university, bool? subscribed,
        ICollection<StudentInternship> studentInternships, string studentId, string studentCV,
        AspNetUser aspNetUser, string bio, bool? deleted, string lastName, string name, string userId)
        {
            var result = _repo.UpdateEntity(
                new Student
                {
                    AspNetUser = aspNetUser,
                    Bio = bio,
                    Deleted = deleted,
                    LastName = lastName,
                    Name = name,
                    UserId = userId,
                    Available = available,
                    Birthday = birthday,
                    Domain = domain,
                    Faculty = faculty,
                    LevelOfStudies = levelOfStudies,
                    Resume = resume,
                    Skills = skills,
                    StudentCV = studentCV,
                    StudentId = studentId,
                    StudentInternships = studentInternships,
                    Subscribed = subscribed,
                    University = university,
                    WebsiteLink = websiteLink
                });

            if (result.Succes)
            {
                return new LogicResponseHandler<string> { Status = true, Content = "Succes!" };
            }
            else
            {
                return new LogicResponseHandler<string> { Status = false, Content = result.Container };
            }
        }
    }
}
