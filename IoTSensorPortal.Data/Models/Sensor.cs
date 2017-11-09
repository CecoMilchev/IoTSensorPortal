using System;
using System.Collections.Generic;

namespace IoTSensorPortal.Data.Models
{
    public class Sensor : I
    {
        //fields 
        public Sensor()
        {
         //init    
        }


        public Guid Id { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int RefreshRate { get; set; }
        public Measure Unit { get; set; }
        public string UnitRange { get; set; } // string min-max to reduce complexity

        public Access Access { get; set; }

        public virtual ICollection<RegisteredUser> SharedWith { get; set; }
        public virtual RegisteredUser Owner { get; set; }
        public virtual IDictionary<DateTime, int> MeasuredValues { get; set; } // history datetime is UTC
    }
}
