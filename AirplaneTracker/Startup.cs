using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AirplaneTracker.Startup))]
namespace AirplaneTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
