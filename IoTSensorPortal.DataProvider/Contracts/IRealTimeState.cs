using System;

namespace IoTSensorPortal.DataProvider
{
    public interface IRealTimeState
    {
        DateTime TimeStamp { get; set; }
        string Value { get; set; }
        string ValueType { get; set; }
    }
}
