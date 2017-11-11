namespace IoTSensorPortal.DataService
{
    public interface ISensorRegisterModel
    {
        string Url { get; set; } //sensor type user defined ( NOT free will )

        string Name { get; set; } //can the user input a name or it comes from sensorInformation

        int RefreshRate { get; set; } //user defined

        int MinValue { get; set; } //user defined

        int MaxValue { get; set; } //user defined

        bool IsPublic { get; set; } //user defined
    }
}