using IoTSensorPortal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTSensorPortal.Data.DataModels
{
    public class SensorModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public int PollingInterval { get; set; }

        public string MeasureType { get; set; }

        public bool IsPublic { get; set; }

        public DateTime LastUpdate { get; set; }

        public string Value { get; set; }

        public string Owner { get; set; }

        public ICollection<History> History { get; set; }

    }
}
