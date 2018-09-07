using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MD.WebForms.Startup))]
namespace MD.WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
