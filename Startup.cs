using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BarcodeLab.Startup))]
namespace BarcodeLab
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
