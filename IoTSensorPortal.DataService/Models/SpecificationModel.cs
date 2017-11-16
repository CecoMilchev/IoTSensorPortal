namespace IoTSensorPortal.DataService
{
    public class SpecificationModel : ISpecification
    {
        public string SensorId { get; set; } //url
        public string Tag { get; set; }
        public string Description { get; set; }
        public int MinPollingIntervalInSeconds { get; set; }
        public string MeasureType { get; set; }
    }
}
