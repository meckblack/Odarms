using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Odarms.Startup))]
namespace Odarms
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
