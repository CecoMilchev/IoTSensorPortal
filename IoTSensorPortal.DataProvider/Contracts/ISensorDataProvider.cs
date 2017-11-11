using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoTSensorPortal.DataProvider.Contracts
{
    public interface ISensorDataProvider
    {
        Task<IEnumerable<T>> Update<T>(string action);

        Task<IRealTimeState> GetRealTimeValue(string id);
    }
}
