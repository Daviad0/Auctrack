using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoAuctrack.Startup))]
namespace DemoAuctrack
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
