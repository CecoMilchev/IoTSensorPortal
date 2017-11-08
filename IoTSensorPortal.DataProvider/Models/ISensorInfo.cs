using System;

namespace IoTSensorPortal.DataProvider.Models
{
    public interface ISensorInfo
    {
        Guid SensorId { get; set; }
        string Tag { get; set; }
        string Description { get; set; }
        int MinPollingIntervalInSeconds { get; set; }
        string MeasureType { get; set; }
    }
}
