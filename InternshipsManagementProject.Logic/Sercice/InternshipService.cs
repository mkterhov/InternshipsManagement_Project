using InternshipsManagementProject.Logic.Models;
using InternshipsManagmentProject.Data;
using InternshipsManagmentProject.Data.Repos;
using System;
using System.Collections.Generic;

namespace InternshipsManagementProject.Logic.Sercice
{
    public class InternshipService
    {
        private RepositoryGenericDRH<Internship> _repo = new RepositoryGenericDRH<Internship>();


        public void InternsipService()
        {
            this._repo = new RepositoryGenericDRH<Internship>();
        }

        public LogicResponseHandler<Internship> GetById(string id)
        {
            var result = _repo.GetById(id);
            if (result.Succes)
            {
                return new LogicResponseHandler<Internship> { Content = result.Container, Status = result.Succes };
            }
            else
            {
                return new LogicResponseHandler<Internship> { Status = false };
            }
        }

        public LogicResponseHandler<IEnumerable<Internship>> GetAll()
        {
            var result = _repo.GetAll();
            if (result.Succes)
            {
                return new LogicResponseHandler<IEnumerable<Internship>> { Content = result.Container, Status = result.Succes };
            }
            else
            {
                return new LogicResponseHandler<IEnumerable<Internship>> { Status = false };
            }
        }

        public LogicResponseHandler<string> AddEntity(string category, string city, 
            ICollection<Comment> comments, DateTime deadlineAplications, bool deleted,
            string department, string description, string duration, DateTime endDate,
            ICollection<File> files, Firm firm, string firmOrganizerid, bool hidden,
            Image image, string internshipId, string internshipPostPhoto,
            string keywords, DateTime lastUpdated, int positionsAvailable, Recruiter recruiter,
            string recruiterResponsibleId, DateTime startDate, ICollection<StudentInternship> studentInternships,
            ICollection<StudentInternship> studentInternships1, string title, string typeJob)
        {
            var result = _repo.AddEntity(
                new Internship
                {
                    Category = category,
                    City = city,
                    Comments = comments,
                    DeadlineApplications = deadlineAplications,
                    Deleted = deleted,
                    Department = department,
                    Description = description,
                    Duration = duration,
                    EndDate = endDate,
                    Files = files,
                    Firm = firm,
                    FirmOrganizerId = firmOrganizerid,
                    Hidden = hidden,
                    Image = image,
                    InternshipId = internshipId,
                    InternshipPostPhoto = internshipPostPhoto,
                    Keywords = keywords,
                    LastUpdated = lastUpdated,
                    PositionsAvailable = positionsAvailable,
                    Recruiter = recruiter,
                    RecruiterResponsibleId = recruiterResponsibleId,
                    StartDate = startDate,
                    StudentInternships = studentInternships,
                    Title = title,
                    TypeJob = typeJob
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
            string city,ICollection<Comment> comments, DateTime deadlineAplications, bool deleted,
            string department, string description, string duration, DateTime endDate,
            ICollection<File> files, Firm firm, string firmOrganizerid, bool hidden,
            Image image, string internshipId, string internshipPostPhoto,
            string keywords, DateTime lastUpdated, int positionsAvailable, Recruiter recruiter,
            string recruiterResponsibleId, DateTime startDate, ICollection<StudentInternship> studentInternships,
            ICollection<StudentInternship> studentInternships1, string title, string typeJob)
        {
            var result = _repo.UpdateEntity(
                new Internship
                {
                    Category = category,
                    City = city,
                    Comments = comments,
                    DeadlineApplications = deadlineAplications,
                    Deleted = deleted,
                    Department = department,
                    Description = description,
                    Duration = duration,
                    EndDate = endDate,
                    Files = files,
                    Firm = firm,
                    FirmOrganizerId = firmOrganizerid,
                    Hidden = hidden,
                    Image = image,
                    InternshipId = internshipId,
                    InternshipPostPhoto = internshipPostPhoto,
                    Keywords = keywords,
                    LastUpdated = lastUpdated,
                    PositionsAvailable = positionsAvailable,
                    Recruiter = recruiter,
                    RecruiterResponsibleId = recruiterResponsibleId,
                    StartDate = startDate,
                    StudentInternships = studentInternships,
                    Title = title,
                    TypeJob = typeJob
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
