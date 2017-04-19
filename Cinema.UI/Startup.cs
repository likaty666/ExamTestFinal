using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cinema.UI.Startup))]
namespace Cinema.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
