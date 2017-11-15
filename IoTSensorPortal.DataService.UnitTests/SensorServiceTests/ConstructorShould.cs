using IoTSensorPortal.Data;
using IoTSensorPortal.DataProvider.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace IoTSensorPortal.DataService.UnitTests.SensorServiceTests
{
    [TestClass]
    public class ConstructorShould
    {
        [TestMethod]
        public void CreateInstance_WhenParametersAreCorrect()
        {
            //Arrange
            var context = new Mock<ApplicationDbContext>();
            var provider = new Mock<ISensorDataProvider>();

            //Act
            var service = new SensorService(context.Object, provider.Object);

            //Assert
            Assert.IsNotNull(service);
        }

        [TestMethod]
        public void ThrowNullArgumetException_WhenContextIsNull()
        {
            //Arrange
            var provider = new Mock<ISensorDataProvider>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new SensorService(null, provider.Object));

        }

        [TestMethod]
        public void ThrowNullArgumetException_WhenDataProviderIsNull()
        {
            //Arrange
            var context = new Mock<ApplicationDbContext>();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new SensorService(context.Object, null));
        }
    }
}
