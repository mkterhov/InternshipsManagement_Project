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
        }
    }
}
