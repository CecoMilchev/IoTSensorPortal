using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IoTSensorPortal.Areas.Admin.Models
{
    public class GetAllSensorsViewModel
    {
        public IUser Owner { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public string ValueType { get; set; }
    }
}