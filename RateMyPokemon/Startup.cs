using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RateMyPokemon.Startup))]
namespace RateMyPokemon
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
