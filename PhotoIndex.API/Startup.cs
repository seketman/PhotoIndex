using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PhotoIndex.API.Startup))]

namespace PhotoIndex.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
