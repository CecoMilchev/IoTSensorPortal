using IoTSensorPortal.Data;
using System;

namespace IoTSensorPortal.Models
{
    public class SensorViewModels
    {
        public class SensorViewModel
        {
<<<<<<< HEAD
=======
            [Required]
            [Display(Name = "Name")]
>>>>>>> 80ed9acb03256809300c40694b0153580778031a
            public string Name { get; set; }

            [Required]
            [Display(Name = "Description")]
            public string Description { get; set; }

<<<<<<< HEAD
            public string Url { get; set; }

            public int RefreshRate { get; set; }

            public Measure Unit { get; set; }

            public int MinRange { get; set; }

            public int MaxRange { get; set; }

            public bool IsPublic { get; set; }
=======
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
>>>>>>> 80ed9acb03256809300c40694b0153580778031a
        }

        //public class CreateViewModel
        //{
        //    public Guid SensorId { get; set; }

<<<<<<< HEAD
            public string Name { get; set; }
=======
        //    public string Tag { get; set; }
>>>>>>> 80ed9acb03256809300c40694b0153580778031a

        //    public string Description { get; set; }

<<<<<<< HEAD
            public Measure Unit { get; set; }

            public int RefreshRate { get; set; }
        }

        public class SensorShortViewModel
        {
            public Guid SensorId { get; set; }

            public string OwnerName { get; set; }

            public string SensorName { get; set; }

=======
        //    public int MinPollingIntervalInSeconds { get; set; }

        //    public string MeasureType { get; set; }
        //}

        public class SensorShortViewModel
        {
            public ApplicationUser Owner { get; set; }

            public string SensorName { get; set; }

            public string Value { get; set; }

            public string ValueType { get; set; }

>>>>>>> 80ed9acb03256809300c40694b0153580778031a
        }
    }
}
