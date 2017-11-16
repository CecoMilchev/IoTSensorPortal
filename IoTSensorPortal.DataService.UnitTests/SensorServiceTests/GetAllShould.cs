using IoTSensorPortal.Data.Models;
using IoTSensorPortal.DataProvider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IoTSensorPortal.DataService.UnitTests.SensorServiceTests
{
    [TestClass]
    public class GetAllShould
    {
        [TestMethod]
        public void ReturnAllRegisteredSensors()
        {
            //Arrange
            var sensorOne = new Mock<Sensor>();
            sensorOne.Object.IsPublic = true;
            var sensorTwo = new Mock<Sensor>();
            sensorTwo.Object.IsPublic = false;

            var contextMock = new Mock<Data.ApplicationDbContext>();
            var providerMock = new Mock<SensorDataProvider>();

            contextMock.Object.Sensors.Add(sensorOne.Object);
            contextMock.Object.Sensors.Add(sensorTwo.Object);

            //Act
            var service = new SensorService(contextMock.Object, providerMock.Object);

            //Assert
            Assert.AreEqual(service.GetAllSensorsList().Count, 2);
        }
    }
}
