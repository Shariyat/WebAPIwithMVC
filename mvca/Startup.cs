using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvca.Startup))]
namespace mvca
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
