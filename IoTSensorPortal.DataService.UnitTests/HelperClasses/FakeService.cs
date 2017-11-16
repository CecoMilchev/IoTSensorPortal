using IoTSensorPortal.Data;
using IoTSensorPortal.DataProvider.Contracts;

namespace IoTSensorPortal.DataService.UnitTests.HelperClasses
{
    public class FakeService : SensorService
    {
        private ApplicationDbContext context;
        private ISensorDataProvider provider;

        public FakeService(ApplicationDbContext context, ISensorDataProvider provider) : base(context, provider)
        {
            this.context = context;
            this.provider = provider;
        }

        public ApplicationDbContext Context { get => context; }
        public ISensorDataProvider Provider { get => provider; }
    }
}
