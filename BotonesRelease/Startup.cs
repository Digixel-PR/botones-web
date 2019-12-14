using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BotonesRelease.Startup))]
namespace BotonesRelease
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
