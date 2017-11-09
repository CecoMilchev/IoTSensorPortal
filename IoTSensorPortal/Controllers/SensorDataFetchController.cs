using System.Web.Mvc;
using IoTSensorPortal.DataProvider;
using Bytes2you.Validation;
using System.Threading.Tasks;
using IoTSensorPortal.DataService;

namespace IoTSensorPortal.Controllers
{
    public class SensorDataFetchController : Controller
    {
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
    }
}