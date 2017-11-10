using Bytes2you.Validation;
using IoTSensorPortal.DataService.Contracts;
using System.Web.Mvc;

using static IoTSensorPortal.Models.SensorViewModels;

namespace IoTSensorPortal.Controllers
{
    public class SensorsController : Controller
    {
        private readonly ISensorService sensorService;
        
        public SensorsController(ISensorService sensorService)
        {
            Guard.WhenArgument(sensorService, "sensorService").IsNull().Throw();
            this.sensorService = sensorService;
        }


        public void Run()
        {
            //this.sensorService.UpdateAllSensors();
        }

        [Authorize]
        public ActionResult ViewPublicSensors()
        {
            //this.sensorService.Get();

            return View();
        }

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
            //var id = sensorService.RegisterSensor(model);


            return this.RedirectToAction("Details", "Sensor");

        }


    }
}