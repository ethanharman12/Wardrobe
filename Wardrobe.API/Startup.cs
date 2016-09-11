using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wardrobe.API.Startup))]
namespace Wardrobe.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
