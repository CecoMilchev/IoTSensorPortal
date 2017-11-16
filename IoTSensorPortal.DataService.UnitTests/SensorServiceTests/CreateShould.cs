using IoTSensorPortal.Data;
using IoTSensorPortal.Data.Models;
using IoTSensorPortal.DataProvider.Contracts;
using IoTSensorPortal.DataService.UnitTests.HelperClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace IoTSensorPortal.DataService.UnitTests.SensorServiceTests
{
    [TestClass]
    public class CreateShould
    {
        [TestMethod]
        public void AddNewSensorToUser_WhenParametersAreCorrect()
        {
            //Arrange
            var context = new Mock<FakeContext>().Object;
            var provider = new Mock<ISensorDataProvider>();
            var service = new SensorService(context, provider.Object);

            var owner = new RegisteredUser() { UserName = "John Doe" };
            var entry = new RegistrationModel
            {
                Url = Guid.NewGuid().ToString(),
                Name = "Test name Sensor",
                RefreshRate = 20,
                MinValue = 10,
                MaxValue = 30,
                IsPublic = true
            };
            //Act
            service.CreateSensor(owner.UserName, entry);

            //Assert
            Assert.AreEqual(context.Sensors.Take(1), entry);
        }
    }
}
