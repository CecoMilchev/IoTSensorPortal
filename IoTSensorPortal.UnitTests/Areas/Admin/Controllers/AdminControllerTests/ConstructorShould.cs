using IoTSensorPortal.Areas.Admin.Controllers;
using IoTSensorPortal.DataProvider.Contracts;
using IoTSensorPortal.DataService;
using IoTSensorPortal.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IoTSensorPortal.UnitTests.Areas.Admin.Controllers.AdminControllerTests
{
    [TestClass]
    public class ConstructorShould
    {
        [TestMethod]
        public void CreateInstance_WhenParametersAreCorrect()
        {
            //Arrange
            var applicationUserManager = new Mock<ApplicationUserManager>();
            var context = new Mock<ApplicationDbContext>();
            var service = new Mock<ISensorService>();

            //Act
            var adminController = new AdminController(applicationUserManager.Object, context.Object, service.Object);

            //Assert
            Assert.IsNotNull(adminController);
        }
    }
}
