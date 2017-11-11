namespace IoTSensorPortal.DataService
{
    public interface ISensorSpecification
    {
        string SensorId { get; set; } //aka url in sensor model object never used as guid
        string Tag { get; set; }
        string Description { get; set; }
        int MinPollingIntervalInSeconds { get; set; }
        string MeasureType { get; set; }
    }
}
