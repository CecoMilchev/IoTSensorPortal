using IoTSensorPortal.DataProvider.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IoTSensorPortal.DataProvider
{
    public class SensorDataProvider
    {
        private readonly string baseUrl;
        public SensorDataProvider()
        {
            this.baseUrl = "http://telerikacademy.icb.bg/";
        }

        public async Task GetAllSensors()
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();

                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Define request token
                client.DefaultRequestHeaders.Add("auth-token", "8e4c46fe-5e1d-4382-b7fc-19541f7bf3b0");

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/sensor/all");

                var sensorsInfo = new List<SensorInfo>();
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var sensorResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    sensorsInfo = JsonConvert.DeserializeObject<List<SensorInfo>>(sensorResponse);
                }

                foreach (var s in sensorsInfo)
                {
                    await GetSensorById(s.SensorId);
                }
            }
        }

        private async Task GetSensorById(Guid id)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Define request token
                client.DefaultRequestHeaders.Add("auth-token", "8e4c46fe-5e1d-4382-b7fc-19541f7bf3b0");

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync($"api/sensor/{id}");

                //Checking the response is successful or not which is sent using HttpClient  
                SensorState sensorState;

                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var sensorResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    sensorState = JsonConvert.DeserializeObject<SensorState>(sensorResponse);
                }
            }
        }
    }
}
