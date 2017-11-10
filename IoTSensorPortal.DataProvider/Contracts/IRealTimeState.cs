using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTSensorPortal.DataProvider.Contracts
{
    public interface IRealTimeState
    {
        DateTime TimeStamp { get; set; }
        string Value { get; set; }
        string ValueType { get; set; }
    }
}
