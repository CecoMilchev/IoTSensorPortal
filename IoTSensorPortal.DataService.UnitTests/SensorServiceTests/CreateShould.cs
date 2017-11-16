using IoTSensorPortal.Data.Models;
using IoTSensorPortal.DataProvider.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace IoTSensorPortal.DataService.UnitTests.SensorServiceTests
{
    [TestClass]
    public class CreateShould
    {
        //[TestMethod]
        //public void AddNewSensorToUser_WhenParametersAreCorrect()
        //{
        //    //Arrange
        //    var context = new Mock<Data.ApplicationDbContext>();
        //    var provider = new Mock<ISensorDataProvider>();
        //    var service = new SensorService(context.Object, provider.Object);

        //    var owner = new RegisteredUser() { UserName = "John Doe" };
        //    var entry = new RegistrationModel
        //    {
        //        Url = Guid.NewGuid().ToString(),
        //        Name = "Test name Sensor",
        //        RefreshRate = 20,
        //        MinValue = 10,
        //        MaxValue = 30,
        //        IsPublic = true
        //    };
        //    //Act
        //    service.CreateSensor(owner.UserName, entry);

        //    //Assert
        //    Assert.AreEqual(context.Object.Sensors.Take(1), entry);
        //}

        //[TestMethod]
        //public void ReturnProper_GuidIdResult()
        //{
        //    // Arrange
        //    var provider = new Mock<ISensorDataProvider>();
        //    var context = new Mock<Data.ApplicationDbContext>();

        //    context.Setup(u => u.SaveChanges()).Returns(1);

        //    var service = new SensorService(context.Object, provider.Object);
        //    var id = Guid.NewGuid();
        //    // Act
        //    var result = service.CreateSensor("Any string", It.IsAny<IRegisterableModel>());

        //    // Assert
        //    Assert.AreEqual(result, id);
        //}
    }
}
