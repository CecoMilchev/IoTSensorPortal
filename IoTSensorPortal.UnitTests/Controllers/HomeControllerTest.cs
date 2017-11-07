using IoTSensorPortal.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace IoTSensorPortal.UnitTests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
           // ViewResult result = controller.About() as ViewResult;

            // Assert
          //  Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ViewPublicSensors()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.ViewPublicSensors() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
