using Bytes2you.Validation;
using IoTSensorPortal.DataService;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

using static IoTSensorPortal.Models.SensorViewModels;

namespace IoTSensorPortal.Controllers
{
    public class SensorsController : Controller
    {
        private ISensorService sensorService;

        public SensorsController(ISensorService sensorService)
        {
            Guard.WhenArgument(sensorService, "sensorService").IsNull();
            this.sensorService = sensorService;
        }

        [Authorize]
        public ActionResult ViewPublicSensors()
        {
            var sensors = this.sensorService.GetAllSensors();
            return View(sensors);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SensorCreateViewModel sensor)
        {
            if (this.ModelState.IsValid)
            {
                this.sensorService.CreateSensor(
                User.Identity.GetUserName(),
                sensor.Name,
                sensor.Description,
                sensor.Url,
                sensor.RefreshRate,
                sensor.Unit,
                $"{sensor.MinRange}-{sensor.MinRange}",
                sensor.IsPublic);
                //to return ID
                //return this.RedirectToAction("Details", new { id = sensorId });
                return this.RedirectToAction("Create");
            };

            return View(sensor);
        }
    }
}