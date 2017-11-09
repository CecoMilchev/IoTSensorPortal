using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace IoTSensorPortal.DataProvider
{
    internal class SensorHttpClient : HttpClient
    {
        // "http://telerikacademy.icb.bg/"
        //token = "8e4c46fe-5e1d-4382-b7fc-19541f7bf3b0";
        public SensorHttpClient(string url, string token)
        {
            //Passing service base url  
            this.BaseAddress = new Uri(url);
            this.DefaultRequestHeaders.Clear();
            //Define request data format  
            this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Define request token
            this.DefaultRequestHeaders.Add("auth-token",token);
            //Sending request to find web api REST service resource GetAllEmployees using HttpClient 
        }
    }

}
