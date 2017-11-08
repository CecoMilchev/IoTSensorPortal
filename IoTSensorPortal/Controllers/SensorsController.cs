using Bytes2you.Validation;
using IoTSensorPortal.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IoTSensorPortal.Controllers
{
    public class SensorsController : Controller
    {
        private ISensorState sensorState;
        private ISensorInfo sensorInfo;

        public SensorsController(ISensorState sensorState, ISensorInfo sensorInfo)
        {
            Guard.WhenArgument<ISensorState>(sensorState, "sensorState").IsNull();
            Guard.WhenArgument<ISensorInfo>(sensorInfo, "sensorInfo").IsNull();
            this.sensorInfo = sensorInfo;
            this.sensorState = sensorState;
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }





        // GET: Sensors
        public ActionResult Index()
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult ViewPublicSensors()
        {
            return View();
        }

        public /*async Task<ActionResult>*/ActionResult About()
        {
            //this.applicationDbContext.Roles.Add(new IdentityRole() { Name = "Admin" });
            //await this.applicationDbContext.SaveChangesAsync();
            //var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);
            //await this.userManager.AddToRoleAsync(user.Id, "Admin");

            return View();
        }

        [Authorize]
        public ActionResult AddNewSensor()
        {
            return View();
        }
    }
}