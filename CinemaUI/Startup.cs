using Microsoft.Owin;
using Owin;
using System.Web.Routing;

[assembly: OwinStartupAttribute(typeof(CinemaUI.Startup))]
namespace CinemaUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           ConfigureAuth(app);
            app.MapSignalR();
           
        }
    }
}
