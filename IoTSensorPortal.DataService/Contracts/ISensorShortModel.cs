using System;

namespace IoTSensorPortal.DataService
{
    public interface ISensorShortModel
    {
        Guid SensorId { get; set; }

        string Owner { get; set; }

        string Name { get; set; }
    }
}