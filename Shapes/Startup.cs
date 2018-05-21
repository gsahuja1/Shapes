using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shapes.Startup))]
namespace Shapes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
