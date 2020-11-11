using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecruitingProject.Startup))]
namespace RecruitingProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
