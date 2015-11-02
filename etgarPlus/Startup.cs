using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(etgarPlus.Startup))]
namespace etgarPlus
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
