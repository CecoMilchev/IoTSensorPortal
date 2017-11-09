using IoTSensorPortal.Data;
using System;

namespace IoTSensorPortal.Models
{
    public class SensorViewModels
    {
        public class SensorCreateViewModel
        {
            public string Name { get; set; }

            public string Description { get; set; }

            public string Url { get; set; }

            public int RefreshRate { get; set; }

            public Measure Unit { get; set; }

            public int MinRange { get; set; }

            public int MaxRange { get; set; }

            public bool IsPublic { get; set; }
        }

        public class CreateViewModel
        {
            public Guid SensorId { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }

            public Measure Unit { get; set; }

            public int RefreshRate { get; set; }
        }

        public class SensorShortViewModel
        {
            public Guid SensorId { get; set; }

            public string OwnerName { get; set; }

            public string SensorName { get; set; }

        }
    }
}