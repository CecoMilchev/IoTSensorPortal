using Bytes2you.Validation;
using IoTSensorPortal.Areas.Admin.Models;
using IoTSensorPortal.DataService;
using IoTSensorPortal.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;

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
            Guard.WhenArgument<ApplicationDbContext>(dbContext, "dbContext").IsNull().Throw();
            this.dbContext = dbContext;
            Guard.WhenArgument<ApplicationUserManager>(userManager, "userManager").IsNull().Throw();
            this.userManager = userManager;
            Guard.WhenArgument<ISensorService>(sensorService, "sensorService").IsNull().Throw();
            this.sensorService = sensorService;
        }

        public ActionResult AllUsers()
        {
            var usersViewModel = this.dbContext
                .Users
                .Select(UserViewModel.Create).ToList();

            return this.View(usersViewModel);
        }

        public object GetAllSensorsList()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult> EditUser(string username)
        {
            var user = await this.userManager.FindByNameAsync(username);
            var userViewModel = UserViewModel.Create.Compile()(user);
            userViewModel.IsAdmin = await this.userManager.IsInRoleAsync(user.Id, "Admin");

            return this.PartialView("_EditUser", userViewModel);
        }

        public object WithCallTo(Func<object, object> p)
        {
            throw new NotImplementedException();
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
            var model = this.sensorService.GetAllSensorsList();
            return View(model);
        }
    }
}