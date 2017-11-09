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
            public ApplicationUser Owner { get; set; }

            [Required]
            [Display(Name = "Value")]
            public string Value { get; set; }
        }

        //public class CreateViewModel
        //{
        //    public Guid SensorId { get; set; }

        //    public string Tag { get; set; }

        //    public string Description { get; set; }

        //    public int MinPollingIntervalInSeconds { get; set; }

        //    public string MeasureType { get; set; }
        //}

        public class SensorShortViewModel
        {
            public ApplicationUser Owner { get; set; }

            public string SensorName { get; set; }

            public string Value { get; set; }

            public string ValueType { get; set; }

        }
    }
}
