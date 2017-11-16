using IoTSensorPortal.DataService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IoTSensorPortal.Models
{
    public class CreateViewModel : IRegisterableModel
    {
        [Required, Display(Name = "Sensor name")]
        public string Name { get; set; }

        [Display(Name = "Source targer")]
        public string Url { get; set; }

        [Required, Display(Name = "Refresh rate")]
        public int RefreshRate { get; set; }

        [Required, Display(Name = "Minimum allowed value")]
        public int MinValue { get; set; }

        [Required, Display(Name = "Maximum allowed value")]
        public int MaxValue { get; set; }

        [Required, Display(Name = "Public")]
        public bool IsPublic { get; set; }
        public string CurrentValue { get; set; }

    }

    public class DetailsViewModel
    {
        public DetailsViewModel(IRegisterableModel registration)
        {
            this.Url = registration.Url;
            this.Name = registration.Name;
            this.RefreshRate = registration.RefreshRate;
            this.MinValue = registration.MinValue;
            this.MaxValue = registration.MaxValue;
            this.IsPublic = registration.IsPublic;
            this.CurrentValue = registration.CurrentValue;
        }

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

    public class EditViewModel : CreateViewModel
    {
        public EditViewModel() { }
        public EditViewModel(Guid id, IRegisterableModel model)
        {
            this.Id = id;
            this.Url = model.Url;
            this.Name = model.Name;
            this.RefreshRate = model.RefreshRate;
            this.MinValue = model.MinValue;
            this.MaxValue = model.MaxValue;
            this.IsPublic = model.IsPublic;
            this.CurrentValue = model.CurrentValue;
        }

        [Required] //hidden in view
        public Guid Id { get; set; }
    }

    public class SpecificationViewModel : ISpecification
    {
        public string SensorId { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
        public int MinPollingIntervalInSeconds { get; set; }
        public string MeasureType { get; set; }
    }

    public class MasterDetailViewModel
    {
        public MasterDetailViewModel(IEnumerable<ListItemModel> sensors)
        {
            this.Sensors = sensors;
        }

        public DetailsViewModel Item { get; set; }
        public IEnumerable<ListItemModel> Sensors { get; set; }
    }
}