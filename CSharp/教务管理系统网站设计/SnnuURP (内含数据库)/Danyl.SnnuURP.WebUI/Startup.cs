using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Danyl.SnnuURP.WebUI.Startup))]
namespace Danyl.SnnuURP.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
