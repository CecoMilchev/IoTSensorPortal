using IoTSensorPortal.Areas.Admin.Controllers;
using IoTSensorPortal.DataService;
using IoTSensorPortal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace IoTSensorPortal.UnitTests.Areas.Admin.Controllers.AdminControllerTests
{
    [TestClass]
    public class ConstructorShould
    {
        [TestMethod]
        public void CreateInstance_WhenParametersAreCorrect()
        {
            //Arrange
            var user = new Mock<IUserStore<RegisteredUser>>();
            var applicationUserManager = new Mock<ApplicationUserManager>(user.Object);
            var context = new Mock<ApplicationDbContext>();
            var service = new Mock<ISensorService>();

            //Act
            var adminController = new AdminController(applicationUserManager.Object, context.Object, service.Object);

            //Assert
            Assert.IsNotNull(adminController);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenUserManagerIsNull()
        {
            //Arrange
            var context = new Mock<ApplicationDbContext>();
            var service = new Mock<ISensorService>();

            //Act & Asert
            Assert.ThrowsException<ArgumentNullException>(() => new AdminController(null, context.Object, service.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenContextIsNull()
        {
            //Arrange
            var user = new Mock<IUserStore<RegisteredUser>>();
            var applicationUserManager = new Mock<ApplicationUserManager>(user.Object);
            var service = new Mock<ISensorService>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new AdminController(applicationUserManager.Object, null, service.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenSensorServiceIsNull()
        {
            //Arrange
            var user = new Mock<IUserStore<RegisteredUser>>();
            var applicationUserManager = new Mock<ApplicationUserManager>(user.Object);
            var context = new Mock<ApplicationDbContext>();

            //Act and Assert
            Assert.ThrowsException<ArgumentNullException>(() => new AdminController(applicationUserManager.Object, context.Object, null));
        }
    }
}
