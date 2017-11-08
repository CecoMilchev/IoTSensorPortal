using Bytes2you.Validation;
using IoTSensorPortal.DataProvider.Models;
using IoTSensorPortal.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        public ActionResult AddNewSensor()
        {
            return View();
        }
    }
}