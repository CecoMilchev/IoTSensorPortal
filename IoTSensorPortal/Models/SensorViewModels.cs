using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IoTSensorPortal.Models
{
    public class SensorViewModels
    {
        public class ProjectCreateViewModel
        {
            public Guid SensorId { get; set; }

            public string Tag { get; set; }

            public string Description { get; set; }

            public int MinPollingIntervalInSeconds { get; set; }

            public string MeasureType { get; set; }

            public DateTime TimeStamp { get; set; }

            public string Value { get; set; }

            public string ValueType { get; set; }
        }

        public class CreateViewModel
        {
            public Guid SensorId { get; set; }

            public string Tag { get; set; }

            public string Description { get; set; }

            public int MinPollingIntervalInSeconds { get; set; }

            public string MeasureType { get; set; }
        }

        public class SensorShortViewModel
        {
            public Guid SensorId { get; set; }

            public IUser User { get; set; }

            public string SensorName { get; set; }
            
        }
    }
}