using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoTSensorPortal.DataProvider
{
    public interface ISensorDataProvider
    {
        Task<IEnumerable<ISensorSpecification>> Update();

        Task<IRealTimeState> GetRealTimeValue(Guid sensorId);
    }
}