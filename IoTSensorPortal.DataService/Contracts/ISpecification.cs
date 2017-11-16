namespace IoTSensorPortal.DataService
{
    public interface ISpecification
    {
        string SensorId { get; set; } //url
        string Tag { get; set; }
        string Description { get; set; }
        int MinPollingIntervalInSeconds { get; set; }
        string MeasureType { get; set; }
    }
}