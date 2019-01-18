using InternshipsManagementProject.Logic.Models;
using InternshipsManagmentProject.Data;
using InternshipsManagmentProject.Data.Repos;
using System;
using System.Collections.Generic;

namespace InternshipsManagementProject.Logic.Sercice
{
    public class RecruterService
    {
        private RepositoryGenericDRH<Recruiter> _repo = new RepositoryGenericDRH<Recruiter>();


        public void InternsipService()
        {
            this._repo = new RepositoryGenericDRH<Recruiter>();
        }

        public LogicResponseHandler<Recruiter> GetById(string id)
        {
            var result = _repo.GetById(id);
            if (result.Succes)
            {
                return new LogicResponseHandler<Recruiter> { Content = result.Container, Status = result.Succes };
            }
            else
            {
                return new LogicResponseHandler<Recruiter> { Status = false };
            }
        }

        public LogicResponseHandler<IEnumerable<Recruiter>> GetAll()
        {
            var result = _repo.GetAll();
            if (result.Succes)
            {
                return new LogicResponseHandler<IEnumerable<Recruiter>> { Content = result.Container, Status = result.Succes };
            }
            else
            {
                return new LogicResponseHandler<IEnumerable<Recruiter>> { Status = false };
            }
        }

        public LogicResponseHandler<string> AddEntity(bool deleted, Firm firm, AspNetUser aspNetUser, 
            string bio, string contactEmail, string firmId, ICollection<Internship> internships, 
            string lastName, string name, string recruiterId, string userId)
        {
            var result = _repo.AddEntity(
                new Recruiter
                {
                    AspNetUser = aspNetUser,
                    Bio = bio,
                    ContactEmail = contactEmail,
                    Deleted = deleted,
                    Firm = firm,
                    FirmId = firmId,
                    Internships = internships,
                    LastName = lastName,
                    Name = name,
                    RecruiterId = recruiterId,
                    UserId = userId
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

        public LogicResponseHandler<string> UpdateEntity(bool deleted, Firm firm, AspNetUser aspNetUser,
            string bio, string contactEmail, string firmId, ICollection<Internship> internships,
            string lastName, string name, string recruiterId, string userId)
        {
            var result = _repo.UpdateEntity(
                new Recruiter
                {
                    AspNetUser = aspNetUser,
                    Bio = bio,
                    ContactEmail = contactEmail,
                    Deleted = deleted,
                    Firm = firm,
                    FirmId = firmId,
                    Internships = internships,
                    LastName = lastName,
                    Name = name,
                    RecruiterId = recruiterId,
                    UserId = userId
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
