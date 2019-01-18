using InternshipsManagementProject.Logic.Models;
using InternshipsManagmentProject.Data;
using InternshipsManagmentProject.Data.Repos;
using System;
using System.Collections.Generic;

namespace InternshipsManagementProject.Logic.Sercice
{
    public class FirmService
    {
        private RepositoryGenericDRH<Firm> _repo = new RepositoryGenericDRH<Firm>();


        public void InternsipService()
        {
            this._repo = new RepositoryGenericDRH<Firm>();
        }

        public LogicResponseHandler<Firm> GetById(string id)
        {
            var result = _repo.GetById(id);
            if (result.Succes)
            {
                return new LogicResponseHandler<Firm> { Content = result.Container, Status = result.Succes };
            }
            else
            {
                return new LogicResponseHandler<Firm> { Status = false };
            }
        }

        public LogicResponseHandler<IEnumerable<Firm>> GetAll()
        {
            var result = _repo.GetAll();
            if (result.Succes)
            {
                return new LogicResponseHandler<IEnumerable<Firm>> { Content = result.Container, Status = result.Succes };
            }
            else
            {
                return new LogicResponseHandler<IEnumerable<Firm>> { Status = false };
            }
        }

        public LogicResponseHandler<string> AddEntity(bool deleted, string description,
            Image image, ICollection<Recruiter> recruiters, ICollection<Internship> internships,
            string firmId, string logo, string name, int numberOfEmployees)
        {
            var result = _repo.AddEntity(
                new Firm
                {
                    Deleted = deleted,
                    Description = description,
                    FirmId = firmId,
                    Image = image,
                    Internships = internships,
                    Logo = logo,
                    Name = name,
                    NumberOfEmployees = numberOfEmployees,
                    Recruiters = recruiters
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

        public LogicResponseHandler<string> UpdateEntity(string oldGuid, string category,
            string city, ICollection<Comment> comments, DateTime deadlineAplications, bool deleted,
            string department, string description, string duration, DateTime endDate,
            ICollection<File> files, Firm firm, string firmOrganizerid, bool hidden,
            Image image, string internshipId, string internshipPostPhoto,
            string keywords, DateTime lastUpdated, int positionsAvailable, Recruiter recruiter,
            string recruiterResponsibleId, DateTime startDate, ICollection<StudentInternship> studentInternships,
            ICollection<StudentInternship> studentInternships1, string title, string typeJob, string firmId,
            ICollection<Internship> internships, string logo, string name)
        {
            var result = _repo.UpdateEntity(
                new Firm
                {
                   Deleted = deleted,
                   Description = description,
                   FirmId = firmId,
                   Image = image,
                   Internships = internships,
                   Logo = logo,
                   Name = name
                   //NumberOfEmployees= numberOfEmployees,
                   //Recruiters = recruiters
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
