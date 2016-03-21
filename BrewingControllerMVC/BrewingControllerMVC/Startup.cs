using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BrewingControllerMVC.Startup))]
namespace BrewingControllerMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
