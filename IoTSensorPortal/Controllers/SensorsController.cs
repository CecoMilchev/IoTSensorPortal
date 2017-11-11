using Bytes2you.Validation;
using IoTSensorPortal.DataService;
using System.Collections.Generic;
using System.Web.Mvc;
using static IoTSensorPortal.Models.SensorViewModels;

namespace IoTSensorPortal.Controllers
{
    public class SensorsController : Controller
    {
        private readonly ISensorService service;

        public SensorsController(ISensorService sensorService)
        {
            Guard.WhenArgument(sensorService, "sensorService").IsNull().Throw();
            this.service = sensorService;
        }
        //update table specification every 30min cache
        public void Run()
        {
            var sensorTypes = this.service.Update();  //TO DO: da se podkara nqmam survisa da testvam
            View(sensorTypes);
        }

        [Authorize]
        public ActionResult ViewPublicSensors()
        {
            //var result = this.service.GetPublic(); //Needs a sensor short VM no history and a collection
            //error na prazna kolekciq 
            var result = new List<SensorShortViewModel>
            {
                new SensorShortViewModel { Id = "peshoId", Name = "Pesho name", Owner = "Pesho Owns" }
            };

            return View(result);
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
            if (this.ModelState.IsValid)
            {
                var id = this.service.RegisterSensor(this.User.Identity.Name, model);
                return this.RedirectToAction("Details", new { id });
            };

            return View(); //this.RedirectToAction("Create"); can`t find create
        }


    }
}