using System;

namespace IoTSensorPortal.Data.DataModels
{
    public class SensorInfo
    {
        public Guid SensorId { get; set; }

        public string Tag { get; set; }

        public string Description { get; set; }

        public int MinPollingIntervalInSeconds { get; set; }

        public string MeasureType { get; set; }
    }
}
