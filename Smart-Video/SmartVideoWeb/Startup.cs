using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartVideoWeb.Startup))]
namespace SmartVideoWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
