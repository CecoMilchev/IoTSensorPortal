using System;

namespace IoTSensorPortal.DataService
{
    public class RealTimeState
    {
        public DateTime TimeStamp { get; set; }
        public string Value { get; set; }
        public string ValueType { get; set; }
    }
}
