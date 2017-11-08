using System;

namespace IoTSensorPortal.DataProvider.Models
{
    public interface ISensorState
    {
        DateTime TimeStamp { get; set; }
        string Value { get; set; }
        string ValueType { get; set; }
    }
}
