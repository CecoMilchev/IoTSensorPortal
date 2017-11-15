using IoTSensorPortal.Controllers;
using IoTSensorPortal.DataService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTSensorPortal.UnitTests.Controllers.SensorControllerTests
{
    [TestClass]
    public class RunShould
    {
        [TestMethod]
        public void VerifyServiceMethod_IsCalled()
        {
            //Arrange
            var serviceMock = new Mock<ISensorService>();
            var controller = new SensorsController(serviceMock.Object);

            //Act
            controller.Run();

            //Assert
            serviceMock.Verify(m => m.Update(), Times.Once);
        }
    }
}
