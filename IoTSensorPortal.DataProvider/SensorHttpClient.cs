using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace IoTSensorPortal.DataProvider
{
    public class SensorHttpClient : HttpClient
    {
        private string baseAddress = @"http://telerikacademy.icb.bg/";
        private string token = "8e4c46fe-5e1d-4382-b7fc-19541f7bf3b0";
        public SensorHttpClient()
        {
            this.BaseAddress = new Uri(this.baseAddress);

            this.DefaultRequestHeaders.Clear();
            //Define request data format  
            this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Define request token
            this.DefaultRequestHeaders.Add("auth-token", this.token);
        }
    }
}
