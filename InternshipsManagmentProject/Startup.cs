using System;
using System.Threading.Tasks;
using InternshipsManagmentProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InternshipsManagmentProject.Startup))]
namespace InternshipsManagmentProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRoles();
        }

        private async Task createRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Visitor"))
            {
                var role = new IdentityRole();
                role.Name = "Visitor";
                await roleManager.CreateAsync(role);
            }
            if (!roleManager.RoleExists("Student"))
            {
                var role = new IdentityRole();
                role.Name = "Student";
                await roleManager.CreateAsync(role);
            }
            if (!roleManager.RoleExists("Recruiter"))
            {
                var role = new IdentityRole();
                role.Name = "Recruiter";
                await roleManager.CreateAsync(role);
            }
            if (!roleManager.RoleExists("Administrator"))
            {
                var role = new IdentityRole();
                role.Name = "Administrator";
                await roleManager.CreateAsync(role);
            }
        }
    }
}
