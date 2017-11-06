using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IoTSensorPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationUserManager userManager;

        public HomeController(ApplicationUserManager userManager)
        {
            Guard.WhenArgument<ApplicationUserManager>(userManager, "userManager").IsNull();
            this.userManager = userManager;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewPublicSensors()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}