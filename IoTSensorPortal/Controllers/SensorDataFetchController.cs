using System.Web.Mvc;
using IoTSensorPortal.DataProvider;
using Bytes2you.Validation;
using System.Threading.Tasks;

namespace IoTSensorPortal.Controllers
{
    public class SensorDataFetchController : Controller
    {
        private readonly SensorDataProvider sensorDataProvider;
        public SensorDataFetchController(SensorDataProvider sensorDataProvider)
        {
            Guard.WhenArgument<SensorDataProvider>(sensorDataProvider, "sensorDataProvider").IsNull();
            this.sensorDataProvider = sensorDataProvider;
        }
        public async Task Run()
        {
            await sensorDataProvider.GetAllSensors();
        }
    }
}