using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RLRP.WebUI.Startup))]
namespace RLRP.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
