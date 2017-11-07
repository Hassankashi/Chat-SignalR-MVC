using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MvcSignal.Startup))]
namespace MvcSignal
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}