using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTSensorPortal.DataProvider.Models
{
    public class SensorState
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
