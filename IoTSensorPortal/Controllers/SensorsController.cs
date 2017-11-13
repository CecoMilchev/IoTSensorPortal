using Bytes2you.Validation;
using IoTSensorPortal.DataService;
using IoTSensorPortal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

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

        public void Run() //public only for the windows service to run
        {
            //update our service
            this.service.Update();
            //Need counter
            this.GetSensorTypes();
        }

        private IEnumerable<SpecificationViewModel> GetSensorTypes()
        {
            var sensorSpecification = this.service.GetSensorSpecifications<SpecificationViewModel>();
            return sensorSpecification;
        }

        [Authorize]
        public ActionResult Create()
        {
            return this.View();
        }

        [Authorize, ValidateAntiForgeryToken, HttpPost]
        public ActionResult Create(SensorRegisterViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var id = this.service.CreateSensor(this.User.Identity.Name, model);
                return this.RedirectToAction("Details", new { id });
            };
            return this.View();
        }

        [Authorize, ValidateAntiForgeryToken, HttpPost]
        public ActionResult Edit(EditViewModel model)
        {
            if (model.Id != null && this.ModelState.IsValid)
            {
                var sensor = this.service.UpdateSensor(model.Id, model);
                return View(sensor);
            }
            return View();
        }

        [Authorize, ValidateAntiForgeryToken, HttpPost]
        public ActionResult Delete(Guid id)
        {
            if (id != null)
            {
                this.service.DeleteSensor(id);
            }
            return this.View();
        }

        [Authorize, ValidateAntiForgeryToken, HttpPost]
        public ActionResult Details(Guid id)
        {
            if (id != null)
            {
                string jsonString = this.service.ReadSensor(id);
                var model = JsonConvert.DeserializeObject<FullDetailsViewModel>(jsonString);
                //kak da go kast kum viewModel
                return View(model);
            }
            return View();
        }

        public ActionResult PublicList()
        {
            var model = this.service.GetPublicList();
            return View(model);
        }

        [Authorize]
        public ActionResult OwnList(SensorListViewModel model)
        {
            //var model = this.service.GetUserOwn(this.User.Identity.Name);
            return View();
        }

        [Authorize]
        public ActionResult SharedToUserList()
        {
            var model = this.service.GetSharedToUser(this.User.Identity.Name);
            return View(model);
        }






    }
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
