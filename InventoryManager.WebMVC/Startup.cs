using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InventoryManager.WebMVC.Startup))]
namespace InventoryManager.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
