using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CovertusWebApplication.Startup))]

namespace CovertusWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
