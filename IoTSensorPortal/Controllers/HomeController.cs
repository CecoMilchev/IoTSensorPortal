using Bytes2you.Validation;
using IoTSensorPortal.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IoTSensorPortal.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ApplicationUserManager userManager;
        //private readonly ApplicationDbContext applicationDbContext;

        public HomeController()
        { 
        }
        //public HomeController(ApplicationUserManager userManager, ApplicationDbContext applicationDbContext)
        //{
        //    Guard.WhenArgument<ApplicationUserManager>(userManager, "userManager").IsNull();
        //    this.userManager = userManager;
        //    Guard.WhenArgument<ApplicationDbContext>(applicationDbContext, "applicationDbContext").IsNull();
        //    this.applicationDbContext = applicationDbContext;
        //}
        public ActionResult Index()
        {
            return View();
        }
        
    }
}