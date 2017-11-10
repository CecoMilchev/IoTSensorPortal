using System;

﻿namespace IoTSensorPortal.Data.Models
{
    public class History
    {
        public Guid Id { get; set; }

        public Guid SensorId { get; set; }
        
        public DateTime UpdateDate { get; set; }
        
        public string Value { get; set; }

        public virtual Sensor Sensor { get; set; }
    }
}