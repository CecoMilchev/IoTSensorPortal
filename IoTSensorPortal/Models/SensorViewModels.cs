using IoTSensorPortal.DataService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IoTSensorPortal.Models
{
    //Crud create
    public class CreateViewModel : ISensorRegisterModel
    {
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

        [Required, Display(Name = "Public")]
        public bool IsPublic { get; set; }
    }

    //cRud read
    public class DetailsViewModel
    {
        //hidden
        public Guid Id { get; set; }

        [Display(Name = "Sensor name")]
        public string Name { get; set; }

        [Display(Name = "Source targer")]
        public string Url { get; set; }

        [Display(Name = "Refresh rate")]
        public int RefreshRate { get; set; }

        [Display(Name = "Minimum allowed value")]
        public int MinValue { get; set; }

        [Display(Name = "Maximum allowed value")]
        public int MaxValue { get; set; }

        [Display(Name = "Public")]
        public bool IsPublic { get; set; }

        [Display(Name = "Current value")]
        public string CurrentValue { get; set; }
    }

    //crUd update
    public class EditViewModel : CreateViewModel
    {
        [Required] //hidden in view
        public Guid Id { get; set; }
    }

    //cruD delete = only delete Button in Details

    //ICB api - sensor type
    public class SpecificationViewModel
    {
        public string SensorId { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
        public int MinPollingIntervalInSeconds { get; set; }
        public string MeasureType { get; set; }
    }

    public class MasterDetailViewModel
    {
        public DetailsViewModel Selection { get; set; }
        public Guid SelectedItem { get; set; }
        public List<string> Sensors { get; set; }
    }
}