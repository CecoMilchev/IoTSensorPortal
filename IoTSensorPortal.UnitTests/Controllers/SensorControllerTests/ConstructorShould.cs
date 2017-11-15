using IoTSensorPortal.Controllers;
using IoTSensorPortal.Data;
using IoTSensorPortal.DataProvider.Contracts;
using IoTSensorPortal.DataService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace IoTSensorPortal.UnitTests.Controllers.SensorControllerTests
{
    [TestClass]
    public class ConstructorShould
    {
        [TestMethod]
        public void CreateInstance_WhenParametersAreCorrect()
        {
            //Arrange
            var serviceMock = new Mock<ISensorService>();


            //Act
            var controller = new SensorsController(serviceMock.Object);

            //Assert
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenServiceIsNull()
        {
            //AAA
            Assert.ThrowsException<ArgumentNullException>(() => new SensorsController(null));
        }
    }
}
