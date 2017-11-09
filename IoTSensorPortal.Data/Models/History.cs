using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTSensorPortal.Data.Models
{
    [Table("History")]
    public class History
    {
        public Guid Id { get; set; }

        public Guid SensorId { get; set; }

        public virtual Sensor Sensor { get; set; }
        
        public DateTime UpdateDate { get; set; }
        
        public string Value { get; set; }
    }
}
