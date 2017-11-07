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

        //[Authorize(Roles = "Admin")]
        public ActionResult ViewPublicSensors()
        {
            return View();
        }

        [Authorize]
        public /*async Task<ActionResult>*/ActionResult About()
        {
            //this.applicationDbContext.Roles.Add(new IdentityRole() { Name = "Admin" });
            //await this.applicationDbContext.SaveChangesAsync();
            //var user = await this.userManager.FindByNameAsync(this.User.Identity.Name);
            //await this.userManager.AddToRoleAsync(user.Id, "Admin");

            return View();
        }
    }
}