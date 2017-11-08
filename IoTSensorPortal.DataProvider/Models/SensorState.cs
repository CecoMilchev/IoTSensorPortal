using System;

namespace IoTSensorPortal.DataProvider.Models
{
    public class SensorState : ISensorState
    {
        public DateTime TimeStamp { get; set; }
        public string Value { get; set; }
        public string ValueType { get; set; }

        public override string ToString()
        {
            return this.TimeStamp.ToLongDateString() + " " + this.Value + " " + this.ValueType;
        }
    }
}
