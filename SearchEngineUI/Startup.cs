using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SearchEngineUI.Startup))]
namespace SearchEngineUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
