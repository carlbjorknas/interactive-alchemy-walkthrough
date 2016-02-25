using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InteractiveAlchemyWalkthrough.Startup))]
namespace InteractiveAlchemyWalkthrough
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
