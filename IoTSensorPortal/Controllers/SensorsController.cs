using Bytes2you.Validation;
<<<<<<< HEAD
using IoTSensorPortal.DataService;
using Microsoft.AspNet.Identity;
=======
using IoTSensorPortal.Data;
using IoTSensorPortal.Data.Models;
using IoTSensorPortal.DataProvider;
using IoTSensorPortal.DataService;
using System.Linq;
using System.Threading.Tasks;
>>>>>>> 80ed9acb03256809300c40694b0153580778031a
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
<<<<<<< HEAD
            Guard.WhenArgument(sensorService, "sensorService").IsNull();
=======
            Guard.WhenArgument(sensorService, "sensorService").IsNull().Throw();
>>>>>>> 80ed9acb03256809300c40694b0153580778031a
            this.sensorService = sensorService;
            Guard.WhenArgument<SensorDataProvider>(sensorDataProvider, "sensorDataProvider").IsNull();
            this.sensorDataProvider = sensorDataProvider;
        }


        public async Task Run()
        {
<<<<<<< HEAD
            var sensors = this.sensorService.GetAllSensors();
            return View(sensors);
=======
            await sensorDataProvider.Update();
>>>>>>> 80ed9acb03256809300c40694b0153580778031a
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
<<<<<<< HEAD
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
=======
            var id = sensorService.RegisterSensor(model);


            return this.RedirectToAction("Details", "Sensor", id);

>>>>>>> 80ed9acb03256809300c40694b0153580778031a
        }


    }
}