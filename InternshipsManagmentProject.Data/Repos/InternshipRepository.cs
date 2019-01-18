using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternshipsManagmentProject.Data.Interfaces;
using InternshipsManagmentProject.Data.Utilities;

namespace InternshipsManagmentProject.Data.Repos
{
    public class InternshipRepository
    {
        public DataResponseHandler<string> AddEntity(Internship newItem)
        {
            using (var context = new Entities())
            {
                try
                {
                    var role = new DataResponseHandler<string> { Succes = true };
                    context.Internships.Add(newItem);
                    role.Container = newItem.InternshipId;
                    
                    return role;
                }
                catch (Exception ex)
                {
                    return new DataResponseHandler<string> { Succes = false, Container = ex.Message};
                }
            }
        }

        public DataResponseHandler<Internship> GetById(string guid)
        {
            using (var context = new Entities())
            {
                try
                {
                    var role = new DataResponseHandler<Internship> { Succes = true };
                    role.Container = context.Internships.Find(guid);

                    return role;
                }
                catch (Exception ex)
                {
                    return new DataResponseHandler<Internship> { Succes = false };
                }
            }
        }

        public DataResponseHandler<string> UpdateEntity(Internship newItem, string guid)
        {
            using (var context = new Entities())
            {
                try
                {
                    var role = new DataResponseHandler<string> { Succes = true };
                    var oldItem = context.Internships.Find(guid);
                    oldItem.Hidden = newItem.Hidden;
                    oldItem.Image = newItem.Image;
                    oldItem.InternshipId = newItem.InternshipId;
                    oldItem.InternshipPostPhoto = newItem.InternshipPostPhoto;
                    oldItem.Keywords = newItem.Keywords;
                    oldItem.LastUpdated = newItem.LastUpdated;
                    oldItem.PositionsAvailable = newItem.PositionsAvailable;
                    oldItem.Recruiter = newItem.Recruiter;
                    oldItem.RecruiterResponsibleId = newItem.RecruiterResponsibleId;
                    oldItem.StartDate = newItem.StartDate;
                    oldItem.StudentInternships = newItem.StudentInternships;
                    oldItem.Title = newItem.Title;
                    oldItem.TypeJob = newItem.TypeJob;

                    role.Container = oldItem.InternshipId;
                    return role;
                }
                catch (Exception ex)
                {
                    return new DataResponseHandler<string> { Succes = false, Container = ex.Message };
                }
            }
        }

        public DataResponseHandler<IEnumerable<Internship>> GetAll()
        {
            using (var context = new Entities())
            {
                try
                {
                    var role = new DataResponseHandler<IEnumerable<Internship>> { Succes = true };
                    role.Container = context.Internships.ToList();

                    return role;
                }
                catch (Exception ex)
                {
                    return new DataResponseHandler<IEnumerable<Internship>> { Succes = false };
                }
            }
        }
    }
}
