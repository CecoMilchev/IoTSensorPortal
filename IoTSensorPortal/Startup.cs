using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IoTSensorPortal.Startup))]
namespace IoTSensorPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
