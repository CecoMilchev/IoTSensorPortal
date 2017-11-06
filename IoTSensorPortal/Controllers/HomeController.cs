using Bytes2you.Validation;
using System.Web.Mvc;

namespace IoTSensorPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationUserManager userManager;

        public HomeController()
        { 
        }
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
            return View();
        }
    }
}