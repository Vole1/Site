using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyRoughSite1.Startup))]
namespace MyRoughSite1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
