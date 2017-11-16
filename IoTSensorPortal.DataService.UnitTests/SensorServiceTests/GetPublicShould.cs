using IoTSensorPortal.Data.Models;
using IoTSensorPortal.DataProvider.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IoTSensorPortal.DataService.UnitTests.SensorServiceTests
{
    [TestClass]
    public class GetPublicShould
    {
        //[TestMethod]
        //public void ReturnOnlyPublicSensors()
        //{
        //    //Arrange
        //    var publicSensor = new Sensor { IsPublic = true };
        //    var privateSensor = new Sensor { IsPublic = false };
        //    var contextMock = new Mock<Data.ApplicationDbContext>();
        //    var providerMock = new Mock<ISensorDataProvider>();
        //    contextMock.Object.Sensors.Add(publicSensor);
        //    contextMock.Object.Sensors.Add(privateSensor);

        //    //Act
        //    var result = new SensorService(contextMock.Object, providerMock.Object).GetPublicList();
        //    //Assert
        //    Assert.AreEqual(result.Count, 1);
        //}
    }
}
