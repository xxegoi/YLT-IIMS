using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_IIMS.Startup))]
namespace MVC_IIMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
