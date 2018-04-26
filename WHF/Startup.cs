using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WHF.Startup))]
namespace WHF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
