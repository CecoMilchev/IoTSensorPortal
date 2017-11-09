using Bytes2you.Validation;
using IoTSensorPortal.DataService;
using System.Web.Mvc;
using static IoTSensorPortal.Models.SensorViewModels;

namespace IoTSensorPortal.Controllers
{
    public class SensorsController : Controller
    {
        private readonly ISensorService service;

        public SensorsController(ISensorService service)
        {
            Guard.WhenArgument(service, "sensorService").IsNull();
            this.service = service;
        }

        //update table specification every 30min cache
        public void Run()
        {
            //var sensors = await service.Update();     //TO DO: da se podkara
            //View(sensors);
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
            if (this.ModelState.IsValid)
            {
                //this.service.RegisterSensor(model);

                //to return ID
                //return this.RedirectToAction("Details", new { id = sensorId });
                return this.RedirectToAction("Create");
            };

            // return this.RedirectToAction("Details", "Sensor", id);
            return null;
        }


    }
}