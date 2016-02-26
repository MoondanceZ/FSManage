using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FSManage.Startup))]
namespace FSManage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
