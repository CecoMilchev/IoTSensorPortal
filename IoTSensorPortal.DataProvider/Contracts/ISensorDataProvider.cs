using IoTSensorPortal.Data.DataModels;
using IoTSensorPortal.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoTSensorPortal.DataProvider.Contracts
{
    public interface ISensorDataProvider
    {
        //Dictionary<string, Guid> GetAllSensorsTags();

        IEnumerable<T> GetAllSensorsInfo<T>();
        
        History GetRealTimeValue(string URL);

        void Update(int counter);
    }
}
