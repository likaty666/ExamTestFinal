using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamTest1.Startup))]
namespace ExamTest1
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
