using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTSensorPortal.Data.DataModels
{
    public class SensorState
    {
        DateTime TimeStamp { get; set; }
        string Value { get; set; }
        string ValueType { get; set; }
    }
}
