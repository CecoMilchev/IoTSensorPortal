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

        //[Authorize]
        public ActionResult Create()
        {
            return this.View();
        }

        [/*Authorize*/ ValidateAntiForgeryToken, HttpPost]
        public ActionResult Create(CreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var id = this.service.CreateSensor(this.User.Identity.Name, model);
                return this.RedirectToAction("OwnList", new { id });
            };
            return this.View();
        }

        [/*Authorize*/ HttpGet]
        public ActionResult Edit(Guid id) //get the view 
        {
            var model = new EditViewModel(id, this.service.ReadSensor(id));

            return View(model);
        }

        [/*Authorize*/ ValidateAntiForgeryToken, HttpPost]
        public ActionResult Edit(EditViewModel model) //dava greshka zaradi guid
        {
            if (this.ModelState.IsValid)
            {
                var sensor = this.service.UpdateSensor(model.Id, model);
                return View(sensor);
            }
            return View();
        }

        [/*Authorize*/ ValidateAntiForgeryToken, HttpPost]
        public ActionResult Delete(Guid id)
        {
            if (id != null)
            {
                this.service.DeleteSensor(id);
            }
            return this.View();
        }

        //[/*Authorize*/]
        public ActionResult Details(Guid id)
        {
            var data = this.service.ReadSensor(id);
            var model = new DetailsViewModel(data);
            return View(model);
        }

        public ActionResult PublicList()
        {
            var model = new MasterDetailViewModel(this.service.GetPublicList());
            return View(model);
        }

        //[/*Authorize*/]
        public ActionResult OwnList()
        {
            var username = this.User.Identity.Name;
            var model = new MasterDetailViewModel(this.service.GetUserOwn(username));
            return View(model);
        }

        //[/*Authorize*/]
        public ActionResult SharedToUserList()
        {
            var username = this.User.Identity.Name;
            var model = new MasterDetailViewModel(this.service.GetSharedToUser(username));

            return View(model);
        }

        public void Run() //public only for the windows service to run
        {
            //update our service
            this.service.Update();
        }

        private IEnumerable<SpecificationModel> GetSensorTypes()
        {
            var sensorSpecification = this.service.GetSensorSpecifications();
            return sensorSpecification;
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
