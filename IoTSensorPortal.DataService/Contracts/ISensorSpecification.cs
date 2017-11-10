using System;

namespace IoTSensorPortal.DataService.Contracts
{
    public interface ISensorSpecification
    {
        Guid SensorId { get; set; }
        string Tag { get; set; }
        string Description { get; set; }
        int MinPollingIntervalInSeconds { get; set; }
        string MeasureType { get; set; }
    }
}
