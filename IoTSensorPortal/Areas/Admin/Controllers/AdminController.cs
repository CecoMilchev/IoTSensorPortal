using Bytes2you.Validation;
using IoTSensorPortal.Areas.Admin.Models;
using IoTSensorPortal.DataService;
using IoTSensorPortal.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IoTSensorPortal.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ApplicationUserManager userManager;
        private readonly ISensorService sensorService;
        
        public AdminController(ApplicationUserManager userManager, ApplicationDbContext dbContext,
            ISensorService sensorService)
        {
            Guard.WhenArgument<ApplicationDbContext>(dbContext, "dbContext").IsNull();
            this.dbContext = dbContext;
            Guard.WhenArgument<ApplicationUserManager>(userManager, "userManager").IsNull();
            this.userManager = userManager;
            Guard.WhenArgument<ISensorService>(sensorService, "sensorService").IsNull();
            this.sensorService = sensorService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllUsers()
        {
            var usersViewModel = this.dbContext
                .Users
                .Select(UserViewModel.Create).ToList();

            return this.View(usersViewModel);
        }

        public async Task<ActionResult> EditUser(string username)
        {
            var user = await this.userManager.FindByNameAsync(username);
            var userViewModel = UserViewModel.Create.Compile()(user);
            userViewModel.IsAdmin = await this.userManager.IsInRoleAsync(user.Id, "Admin");

            return this.PartialView("_EditUser", userViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditUser(UserViewModel userViewModel)
        {
            if (userViewModel.IsAdmin)
            {
                await this.userManager.AddToRoleAsync(userViewModel.Id, "Admin");
            }
            else
            {
                await this.userManager.RemoveFromRoleAsync(userViewModel.Id, "Admin");
            }

            return this.RedirectToAction("AllUsers");
        }

        public ActionResult AllSensors()
        {
            var allSensorsViewModel = this.sensorService.GetAllSensorsList();
            return View(allSensorsViewModel);
        }
    }
}