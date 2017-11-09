using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoTSensorPortal.DataProvider
{
    public interface ISensorDataProvider
    {
        Task<IEnumerable<ISensorSpecification>> GetAllSensors();

        Task<IRealTimeState> GetRealTimeValue(Guid sensorId);
    }
}