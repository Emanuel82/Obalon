using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Obalon.Startup))]
namespace Obalon
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
