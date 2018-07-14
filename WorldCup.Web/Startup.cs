using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WorldCup.Web.Startup))]
namespace WorldCup.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
