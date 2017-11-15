using IoTSensorPortal.Areas.Admin.Controllers;
using IoTSensorPortal.DataService;
using IoTSensorPortal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using TestStack.FluentMVCTesting;

namespace IoTSensorPortal.UnitTests.Areas.Admin.Controllers.AdminControllerTests
{
    [TestClass]
    public class AllSensorsShould
    {
        [TestMethod]
        public void CallCorrectServiceMethodAndReturnCorrectView()
        {
            //Arrange
            var user = new Mock<IUserStore<RegisteredUser>>();
            var applicationUserManager = new Mock<ApplicationUserManager>(user.Object);
            var context = new Mock<ApplicationDbContext>();
            var sensorServiceMock = new Mock<ISensorService>();

            var sensors = new List<string>()
            {
                { "Sensor1" },
                { "Sensor2" }
            };
            
            sensorServiceMock.Setup(s => s.GetAllSensorsList()).Returns(sensors);

            var controller = new AdminController(applicationUserManager.Object, context.Object, sensorServiceMock.Object);
            
            //Act & Assert
            controller
                .WithCallTo(s => s.AllSensors())
                .ShouldRenderDefaultView()
                .WithModel<List<string>>
            (viewModel =>
            {
                for (int i = 0; i < viewModel.Count; i++)
                {
                    Assert.AreEqual(viewModel[i], sensors[i]);
                }
            });
        }
    }
}
