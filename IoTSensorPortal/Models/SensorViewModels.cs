using IoTSensorPortal.DataService;
using System;
using System.ComponentModel.DataAnnotations;

namespace IoTSensorPortal.Models
{
    public class SensorViewModels : ISensorRegisterModel
    {
        public class SensorViewModel
        {
            [Required]
            [Display(Name = "Name")]

            public string Name { get; set; }

            [Required]
            [Display(Name = "Description")]
            public string Description { get; set; }

            [Required]
            [Display(Name = "Url")]
            public string Url { get; set; }

            [Required]
            [Display(Name = "Polling Interval")]
            public int PollingInterval { get; set; }

            [Required]
            [Display(Name = "Measure Type")]
            public string MeasureType { get; set; }

            [Required]
            [Display(Name = "Public")]
            public bool IsPublic { get; set; }

            [Required]
            [Display(Name = "Last Update")]
            public DateTime LastUpdate { get; set; }

            [Required]
            [Display(Name = "Owner")]
            public RegisteredUser Owner { get; set; }

            [Required]
            [Display(Name = "Value")]
            public string Value { get; set; }

        }

        public class SensorShortViewModel
        {
            public Guid SensorId { get; set; }

            public string OwnerName { get; set; }

            public string SensorName { get; set; }
        }
    }
}
