using Bytes2you.Validation;
using IoTSensorPortal.Data;
using IoTSensorPortal.Data.Models;
using IoTSensorPortal.DataProvider;
using IoTSensorPortal.DataService;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

using static IoTSensorPortal.Models.SensorViewModels;

namespace IoTSensorPortal.Controllers
{
    public class SensorsController : Controller
    {

        private readonly SensorDataProvider sensorDataProvider;
        private readonly ISensorService sensorService;
        
        public SensorsController(ISensorService sensorService, SensorDataProvider sensorDataProvider)
        {
            Guard.WhenArgument(sensorService, "sensorService").IsNull().Throw();
            this.sensorService = sensorService;
            Guard.WhenArgument<SensorDataProvider>(sensorDataProvider, "sensorDataProvider").IsNull();
            this.sensorDataProvider = sensorDataProvider;
        }


        public async Task Run()
        {
            await sensorDataProvider.Update();
        }
        //[Authorize]
        //public ActionResult ViewPublicSensors()
        //{
        //    var sensors = this.dbContext.se.GetAllSensors().Select(
        //        s => new SensorShortViewModel()
        //        {
        //            SensorId = s.Id,
        //            User = s.Owner,
        //            SensorName = s.Tag
        //        });

        //    return View(sensors);
        //}

        [Authorize]
        public ActionResult RegisterSensor()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult RegisterSensor(SensorViewModel model)
        {
            var id = sensorService.RegisterSensor(model);


            return this.RedirectToAction("Details", "Sensor", id);

        }


    }
}