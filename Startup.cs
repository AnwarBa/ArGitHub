using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Aanchal_RIMS.Startup))]
namespace Aanchal_RIMS
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
