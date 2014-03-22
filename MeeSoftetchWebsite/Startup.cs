using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeeSoftetchWebsite.Startup))]
namespace MeeSoftetchWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
