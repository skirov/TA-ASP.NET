using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormsExam.Startup))]
namespace WebFormsExam
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
