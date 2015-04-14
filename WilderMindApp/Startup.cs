using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WilderMindApp.Startup))]
namespace WilderMindApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
