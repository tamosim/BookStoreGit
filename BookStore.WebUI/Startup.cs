using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookStore.WebUI.Startup))]
namespace BookStore.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
