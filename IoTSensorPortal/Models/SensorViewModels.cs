using IoTSensorPortal.DataService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IoTSensorPortal.Models
{
    public class FullDetailsViewModel : ISensorRegisterModel
    {
        //Registered User Values
        //Registerable
        [Required, Display(Name = "Sensor name")]
        public string Name { get; set; }

        [Required, Display(Name = "Source targer")]
        public string Url { get; set; }

        [Required, Display(Name = "Refresh rate")]
        public int RefreshRate { get; set; }

        [Required, Display(Name = "Minimum allowed value")]
        public int MinValue { get; set; }

        [Required, Display(Name = "Maximum allowed value")]
        public int MaxValue { get; set; }

        [Required, Display(Name = "Publicly visible")]
        public bool IsPublic { get; set; }

        //Sensor Api Spec 
        [Required, Display(Name = "Sensor type")]
        public SpecificationViewModel Type { get; set; }
        //SensorApi Spec

        //Measured values - History
        public TimeSpan Period { get; set; }
        //Vizualizaciq na istoriqta
    }

    public class SensorRegisterViewModel : ISensorRegisterModel
    {
        //Registerable
        [Required]
        [Display(Name = "Sensor name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Source targer")]
        public string Url { get; set; }

        [Required]
        [Display(Name = "Refresh rate")]
        public int RefreshRate { get; set; }

        [Required]
        [Display(Name = "Minimum allowed value")]
        public int MinValue { get; set; }

        [Required]
        [Display(Name = "Maximum allowed value")]
        public int MaxValue { get; set; }

        [Required]
        [Display(Name = "Publicly visible")]
        public bool IsPublic { get; set; }

        //Sensor Api Spec 
        //[Required]
        //[Display(Name = "Sensor type")]
        //public SpecificationViewModel Type { get; set; }
    }

    public class EditViewModel : SensorRegisterViewModel
    {
        [Required]
        [Display(Name = "Sensor Id")]
        public Guid Id { get; set; }
    }

    //public, private/own, sharedToUser
    public class SensorListViewModel
    {
        //                id     owner + user sensor name
        public Dictionary<Guid, string> SensorList { get; set; }
    }

    public class SpecificationViewModel
    {
        public string SensorId { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
        public int MinPollingIntervalInSeconds { get; set; }
        public string MeasureType { get; set; }
    }

    //View historical data for the sensor choosing from and to periods
}