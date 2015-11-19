using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JSMall.Startup))]
namespace JSMall
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
