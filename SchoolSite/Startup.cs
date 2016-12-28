using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoolSite.Startup))]
namespace SchoolSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
