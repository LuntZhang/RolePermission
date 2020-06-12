using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(My.Rolepermission.WebApp.Startup))]
namespace My.Rolepermission.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
