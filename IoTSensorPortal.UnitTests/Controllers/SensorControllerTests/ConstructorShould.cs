using IoTSensorPortal.Controllers;
using IoTSensorPortal.Data;
using IoTSensorPortal.DataProvider.Contracts;
using IoTSensorPortal.DataService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IoTSensorPortal.UnitTests.Controllers.SensorControllerTests
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
            var service = new Mock<ISensorService>();


            //Act
            var controller = new SensorsController(service.Object);

            //Assert
            Assert.IsNotNull(controller);
        }
    }
}
