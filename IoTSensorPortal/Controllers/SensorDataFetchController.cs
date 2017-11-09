using System.Web.Mvc;
using IoTSensorPortal.DataProvider;
using Bytes2you.Validation;
using System.Threading.Tasks;
using IoTSensorPortal.DataService;

namespace IoTSensorPortal.Controllers
{
    public class SensorDataFetchController : Controller
    {
<<<<<<< HEAD
        private readonly ISensorDataProvider sensorService;
        public SensorDataFetchController(ISensorDataProvider sensorService)
        {
            Guard.WhenArgument(sensorService, "sensorDataProvider").IsNull();
            this.sensorService = sensorService;
        }

        public async Task Run()
        {
            await sensorService.Ge();
        }
=======
        
>>>>>>> 80ed9acb03256809300c40694b0153580778031a
    }
}