using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PalRSA.Startup))]
namespace PalRSA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
