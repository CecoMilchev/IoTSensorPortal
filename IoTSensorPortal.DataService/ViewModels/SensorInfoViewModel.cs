﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTSensorPortal.DataService.ViewModels
{
    public class SensorInfoViewModel
    {
        public string SensorId { get; set; }

        public string Tag { get; set; }

        public string Description { get; set; }

        public int MinPollingIntervalInSeconds { get; set; }

        public string MeasureType { get; set; }
    }
}
