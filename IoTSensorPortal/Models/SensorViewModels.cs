
using IoTSensorPortal.DataService;
using IoTSensorPortal.DataService.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace IoTSensorPortal.Models
{
    public class SensorViewModels
    {
        public class SensorViewModel
        {
            public Guid Id { get; set; }

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
            [Display(Name = "Value")]
            public string Value { get; set; }

            [Required]
            public static Expression<Func<SensorService, SensorViewModel>> SensorTags
            {
                get
                {
                    return s => new SensorViewModel()
                    {
                        Id = new Guid(),
                        //Url = s.GetAllSensors(),

                    };
                }
            }

            //public IList<SensorSpecifications> SensorUrls { get; set; }

            public string Owner { get; set; }
            //IList<string> ISensorRegisterModel.SensorUrls { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        }

        public class SensorShortViewModel
        {
            public Guid SensorId { get; set; }

            public string OwnerName { get; set; }

            public string SensorName { get; set; }
        }
    }


    //[Required]
    //[Display(Name = "Maximum Range")]
    //public int MaxValue { get; set; }

    //public IEnumerable<SelectListItem> DropDownValues { get; set; }

    public class SensorShortViewModel
    {
        public string Id { get; set; }

        public string Owner { get; set; }

        public string Name { get; set; }
    }


}