using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTSensorPortal.DataService.ViewModels
{
    public class CurrentSensorValueViewModel
    {
        public DateTime TimeStamp { get; set; }
        public string Value { get; set; }
        public string ValueType { get; set; }
    }
}
