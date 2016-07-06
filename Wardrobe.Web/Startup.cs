using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wardrobe.Web.Startup))]
namespace Wardrobe.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
