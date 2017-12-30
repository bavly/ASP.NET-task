using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EFG_Task.Startup))]
namespace EFG_Task
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
