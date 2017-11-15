using IoTSensorPortal.Data;
using IoTSensorPortal.DataProvider.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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
    }
}
