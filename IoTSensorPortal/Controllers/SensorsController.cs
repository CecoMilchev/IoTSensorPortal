using Bytes2you.Validation;
using IoTSensorPortal.DataService;
using System.Threading.Tasks;
using System.Web.Mvc;
using IoTSensorPortal.Models;
using System.Collections.Generic;
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
            this.sensorService.Update();
        }

        public async Task<ActionResult> ViewPublicSensors()
        {
            //var viewModel = await this.sensorService.();


            return View();
        }

        [Authorize]
        public void RegisterSensor()
        {
            this.sensorService.RegisterSensor(this.User.Identity.Name);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> RegisterSensor(SensorViewModels.SensorViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                model.Owner = this.User.Identity.Name;
                model.Url = "";
                this.sensorService.RegisterSensor(this.User.Identity.Name);

                //to return ID
                return this.RedirectToAction("Details", new { id = model.Id });
            };

            return this.RedirectToAction("Details", "Sensors", model.Id);
        }

        public ActionResult Details(SensorViewModels.SensorViewModel model)
        {
            return this.View();
        }




        //[ChildActionOnly]
        //[OutputCache(Duration = 3600)]
        //public ActionResult DropDownPartial()
        //{
        //    //List<SelectListItem> dropDownValues = this.sensorService.GetPublic().Select(s => new SelectListItem() { Text = s. }).tol();
        //    //return this.PartialView(dropDownValues);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize]
        //public ActionResult RegisterSensor(SensorViewModel model)
        //{
        //    if (this.ModelState.IsValid)
        //    {
        //        var id = this.sensorService.RegisterSensor(this.User.Identity.Name, model);
        //        return this.RedirectToAction("Details", new { id });
        //    };

        //    return View(); //this.RedirectToAction("Create"); can`t find create
        //}

    }
}
