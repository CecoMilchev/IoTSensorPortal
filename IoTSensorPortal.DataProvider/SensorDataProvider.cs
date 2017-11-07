using IoTSensorPortal.DataProvider.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
                var sensorsState = new List<string>(new string[sensorsInfo.Count]);

                for (int i = 0; i < sensorsInfo.Count; i++)
                {
                    sensorsState[i] = i + ". " + await GetSensorById(sensorsInfo[i].SensorId);
                }

                string path = @"C:\Program Files\IcbShceduledJob\Logs\Sensors Current State.txt";

                // This text is added only once to the file.
                // Create a file to write to.
                File.WriteAllLines(path, sensorsState, Encoding.UTF8);
                
            }
        }

        private async Task<string> GetSensorById(Guid id)
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
                SensorState sensorState = new SensorState();

                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var sensorResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    sensorState = JsonConvert.DeserializeObject<SensorState>(sensorResponse);
                }

                return sensorState.ToString();
            }
        }
    }
}
