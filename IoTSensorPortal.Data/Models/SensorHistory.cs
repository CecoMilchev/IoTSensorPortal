using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTSensorPortal.Data.Models
{
    public class SensorHistory
    {
        public SensorHistory()
        {
        }

        public Guid Id { get; set; }

        public Guid SensorId { get; set; }

        public virtual Sensor Sensor { get; set; }
        
        public DateTime TimeStamp { get; set; }

        [Required]
        public string Value { get; set; }

        public string ValueType { get; set; }

    }
}
