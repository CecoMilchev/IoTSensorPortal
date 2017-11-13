using IoTSensorPortal.Data.DataModels;
using IoTSensorPortal.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoTSensorPortal.DataProvider.Contracts
{
    public interface ISensorDataProvider
    {
        Dictionary<string, Guid> GetAllSensorsTags();

        IEnumerable<SensorInfo> GetAllSensorsInfo();
        
        History GetRealTimeValue(string URL);

        void Update();
    }
}
