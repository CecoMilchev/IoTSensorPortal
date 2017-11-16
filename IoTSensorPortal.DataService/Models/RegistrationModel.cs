namespace IoTSensorPortal.DataService
{
    public class RegistrationModel : IRegisterableModel
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public int RefreshRate { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public bool IsPublic { get; set; }
    }
}