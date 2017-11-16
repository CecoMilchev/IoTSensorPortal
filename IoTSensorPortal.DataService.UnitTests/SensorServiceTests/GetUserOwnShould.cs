using IoTSensorPortal.Data.Models;
using IoTSensorPortal.DataProvider.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IoTSensorPortal.DataService.UnitTests.SensorServiceTests
{
    [TestClass]
    public class GetUserOwnShould
    {
        //[TestMethod]
        //public void ReturnAllSensors_ForOwner()
        //{
        //    //Arrange
        //    var userMock = new Mock<RegisteredUser>();
        //    var oneMock = new Mock<Sensor>();
        //    var twoMock = new Mock<Sensor>();
        //    var contextMock = new Mock<Data.ApplicationDbContext>();
        //    var providerMock = new Mock<ISensorDataProvider>();

        //    userMock.Object.OwnSensors.Add(oneMock.Object);
        //    userMock.Object.OwnSensors.Add(twoMock.Object);

        //    contextMock.Object.Users.Add(userMock.Object);

        //    //Act
        //    var service = new SensorService(contextMock.Object, providerMock.Object);
        //    //Assert
        //    Assert.AreEqual(service.GetUserOwn(userMock.Object.UserName).Count, 1);
        //}
    }
}