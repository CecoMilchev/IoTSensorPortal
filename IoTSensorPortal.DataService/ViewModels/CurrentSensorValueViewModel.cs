using System;

namespace IoTSensorPortal.DataService.ViewModels
{
    public class CurrentSensorValueViewModel
    {
        public DateTime TimeStamp { get; set; }
        public string Value { get; set; }
        public string ValueType { get; set; }
    }
}
