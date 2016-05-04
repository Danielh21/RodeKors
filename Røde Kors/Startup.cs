using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Røde_Kors.Startup))]
namespace Røde_Kors
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
