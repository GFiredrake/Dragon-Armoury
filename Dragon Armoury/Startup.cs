using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dragon_Armoury.Startup))]
namespace Dragon_Armoury
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
