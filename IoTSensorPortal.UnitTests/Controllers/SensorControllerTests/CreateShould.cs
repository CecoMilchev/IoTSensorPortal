using IoTSensorPortal.Controllers;
using IoTSensorPortal.DataService;
using IoTSensorPortal.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TestStack.FluentMVCTesting;

namespace IoTSensorPortal.UnitTests.Controllers.SensorControllerTests
{
    [TestClass]
    public class CreateShould
    {
        [TestMethod]
        public void ReturnDefaultViewWithCorrectViewModel()
        {
            //Arrange
            var serviceMock = new Mock<ISensorService>();
            var controller = new SensorsController(serviceMock.Object);

            //Act & Assert
            controller
                .WithCallTo(x => x.Create())
                .ShouldRenderDefaultView();
        }

        //[TestMethod]
        //public void RedirectToDetailsView_WhenModelStateIsValid()
        //{
        //    //Arrange
        //    var serviceMock = new Mock<ISensorService>();
        //    var controller = new SensorsController(serviceMock.Object);

        //    var idMock = Guid.NewGuid();
        //    var userIdMock = "123";

        //    var sensorViewModelMock = new CreateViewModel()
        //    {
        //        Name = "Name",
        //        Url = "Url",
        //        RefreshRate = 10,
        //        IsPublic = true,
        //        MinValue = 8,
        //        MaxValue = 12
        //    };

        //    serviceMock.SetupGet(x => x.CreateSensor(userIdMock, sensorViewModelMock)).Returns(idMock);
            
        //    //Act & Assert
        //    controller.WithCallTo(x => x.Create(sensorViewModelMock))
        //        .ShouldRedirectToRoute($"Details/{idMock}");
        //}

    }
}
