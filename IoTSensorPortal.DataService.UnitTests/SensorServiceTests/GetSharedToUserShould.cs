using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IoTSensorPortal.Data.Models;
using Moq;
using IoTSensorPortal.DataProvider.Contracts;

namespace IoTSensorPortal.DataService.UnitTests.SensorServiceTests
{
    [TestClass]
    public class GetSharedToUserShould
    {
        [TestMethod]
        public void ReturnOnlySharedToUserSensors_WhenNotOwner()
        {
            //Arrange
            var userMock = new Mock<RegisteredUser>();
            var ownSensor = new Mock<Sensor>();
            var sharedToHim = new Mock<Sensor>();
            var contextMock = new Mock<Data.ApplicationDbContext>();
            var providerMock = new Mock<ISensorDataProvider>();

            userMock.Object.OwnSensors.Add(ownSensor.Object);
            contextMock.Object.Users.Add(userMock.Object);

            sharedToHim.Object.SharedWithUsers.Add(userMock.Object);
            contextMock.Object.Sensors.Add(sharedToHim.Object);

            //Act
            var result = new SensorService(contextMock.Object, providerMock.Object).GetSharedToUser(userMock.Object.UserName);
            //Assert
            Assert.AreEqual(result.Count, 1);
        }

        [TestMethod]
        public void ReturAll_SharedToUserSensors()
        {
            //Arrange
            var userMock = new Mock<RegisteredUser>();
            var sensorOne = new Mock<Sensor>();
            var sensorTwo = new Mock<Sensor>();
            var contextMock = new Mock<Data.ApplicationDbContext>();
            var providerMock = new Mock<ISensorDataProvider>();

            contextMock.Object.Users.Add(userMock.Object);

            sensorOne.Object.SharedWithUsers.Add(userMock.Object);
            contextMock.Object.Sensors.Add(sensorOne.Object);
            sensorTwo.Object.SharedWithUsers.Add(userMock.Object);
            contextMock.Object.Sensors.Add(sensorTwo.Object);

            //Act
            var result = new SensorService(contextMock.Object, providerMock.Object).GetSharedToUser(userMock.Object.UserName);
            //Assert
            Assert.AreEqual(result.Count, 2);
        }
    }
}
