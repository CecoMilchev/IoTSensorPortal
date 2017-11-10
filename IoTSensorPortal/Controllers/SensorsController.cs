using Bytes2you.Validation;
using IoTSensorPortal.DataService;
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
        //update table specification every 30min cache
        public void Run()
        {
            //var sensors = await service.Update();     //TO DO: da se podkara
            //View(sensors);
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

            return this.RedirectToAction("Details", "Sensor");
            //if (this.ModelState.IsValid)
            //{
            //    //this.service.RegisterSensor(model);

            //    //to return ID
            //    //return this.RedirectToAction("Details", new { id = sensorId });
            //    return this.RedirectToAction("Create");
            //};

            // return this.RedirectToAction("Details", "Sensor", id);
            return null;
        }


    }
}