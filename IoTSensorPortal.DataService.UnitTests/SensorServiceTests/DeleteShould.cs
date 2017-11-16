using IoTSensorPortal.Data;
using IoTSensorPortal.Data.Models;
using IoTSensorPortal.DataProvider.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace IoTSensorPortal.DataService.UnitTests.SensorServiceTests
{
    [TestClass]
    public class DeleteShould
    {
        [TestMethod]
        public void NotRemoveEntry_WhenNotExistantGuidKey()
        {
            //Arrange
            var sOne = new Mock<Sensor>();
            var sTwo = new Mock<Sensor>();
            var contextMock = new Mock<ApplicationDbContext>();
            var providerMock = new Mock<ISensorDataProvider>();

            contextMock.Object.Sensors.Add(sOne.Object);
            contextMock.Object.Sensors.Add(sTwo.Object);

            //Act
            var service = new Mock<SensorService>(contextMock.Object, providerMock.Object);
            service.Object.DeleteSensor(Guid.NewGuid());
            //Assert
            Assert.AreEqual(contextMock.Object.Sensors.Count(), 2);
        }
    }
}
