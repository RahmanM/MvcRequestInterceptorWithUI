using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Asp.Net.RequestInterceptors.Startup))]
namespace Asp.Net.RequestInterceptors
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
