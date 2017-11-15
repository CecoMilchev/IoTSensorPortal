﻿using IoTSensorPortal.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IoTSensorPortal.DataProvider.UnitTests.SensorDataProviderTests
{
    [TestClass]
    public class ConstructorShould
    {
        [TestMethod]
        public void CreateInstance_WhenParametersAreCorrect()
        {
            //Arrange
            var context = new Mock<ApplicationDbContext>();

            //Act
            var provider = new SensorDataProvider(context.Object);

            //Assert
            Assert.IsNotNull(provider);
        }

    }
}
