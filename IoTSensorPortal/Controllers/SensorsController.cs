using Bytes2you.Validation;
using IoTSensorPortal.Data.Models;
using IoTSensorPortal.DataService;
using IoTSensorPortal.DTOs;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

using static IoTSensorPortal.Models.SensorViewModels;

namespace IoTSensorPortal.Controllers
{
    public class SensorsController : Controller
    {
        private ISensorService sensorService;

        public SensorsController(ISensorService sensorService)
        {
            Guard.WhenArgument<ISensorService>(sensorService, "sensorService").IsNull();
            this.sensorService = sensorService;
        }

        [Authorize]
        public ActionResult ViewPublicSensors()
        {
            var sensors = this.sensorService.GetAllSensors().Select(
                s => new SensorShortViewModel()
                {
                    SensorId = s.Id,
                    User = s.ApplicationUser,
                    SensorName = s.Tag
                });
                
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
            if (!this.ModelState.IsValid)
            {
                return View(sensor);
            }

            var sensorDto = new SensorDto()
            {
                Tag = sensor.Tag,
                Description = sensor.Description,
                MinPollingIntervalInSeconds = sensor.MinPollingIntervalInSeconds,
                MeasureType = sensor.MeasureType
            };

            var sensorId = this.sensorService.CreateSensor(sensorDto, this.User.Identity.GetUserId());

            //return this.RedirectToAction("Details", new { id = sensorId });
            return this.RedirectToAction("Create");

        }
    }
}