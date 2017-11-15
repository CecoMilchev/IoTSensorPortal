using IoTSensorPortal.Areas.Admin.Controllers;
using IoTSensorPortal.Areas.Admin.Models;
using IoTSensorPortal.DataService;
using IoTSensorPortal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestStack.FluentMVCTesting;

namespace IoTSensorPortal.UnitTests.Areas.Admin.Controllers.AdminControllerTests
{
    [TestClass]
    public class AllUsersShould
    {
        [TestMethod]
        public void ReturnDefaultView_WithCorrectViewModel()
        {
            // Arrange
            var storeMock = new Mock<IUserStore<RegisteredUser>>();
            var userManagerMock = new Mock<ApplicationUserManager>(storeMock.Object);
            var dbContextMock = new Mock<ApplicationDbContext>();
            var sensorService = new Mock<ISensorService>();

            List<RegisteredUser> users = new List<RegisteredUser>()
            {
                new RegisteredUser() { UserName = "firstUser" },
                new RegisteredUser() { UserName = "secondUser" }
            };
            var usersSetMock = new Mock<DbSet<RegisteredUser>>().SetupData(users);

            var resultViewModel = users.AsQueryable().Select(UserViewModel.Create).ToList();

            dbContextMock.SetupGet(m => m.Users).Returns(usersSetMock.Object);

            AdminController controller = new AdminController(userManagerMock.Object, dbContextMock.Object, sensorService.Object);

            // Act & Assert
            controller
                .WithCallTo(c => c.AllUsers())
                .ShouldRenderDefaultView()
                .WithModel<List<UserViewModel>>(viewModel =>
                {
                    for (int i = 0; i < viewModel.Count; i++)
                    {
                        Assert.AreEqual(resultViewModel[i].Username, viewModel[i].Username);
                    }
                });
        }
    }
}
