using IoTSensorPortal.Data;
using IoTSensorPortal.Data.Models;
using Moq;
using System.Data.Entity;

namespace IoTSensorPortal.DataService.UnitTests.HelperClasses
{
    public class FakeContext : ApplicationDbContext
    {
        private IDbSet<Sensor> sensors;

        public FakeContext()
        {
            var contextMock = new Mock<ApplicationDbContext>();
            var sensorsMock = new Mock<IDbSet<Sensor>>();

            this.sensors = sensorsMock.Object;
            
        }

        public new IDbSet<Sensor> Sensors { get => sensors; }
    }
}
