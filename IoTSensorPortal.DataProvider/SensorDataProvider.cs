using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IoTSensorPortal.DataProvider
{
    internal class SensorDataProvider : ISensorDataProvider
    {
<<<<<<< HEAD
        private readonly HttpClient client;
        public SensorDataProvider(HttpClient sensorHttpClient)
=======
        private readonly string baseUrl;
        public SensorDataProvider(ISensorService sensorService)
>>>>>>> 80ed9acb03256809300c40694b0153580778031a
        {
            this.client = sensorHttpClient;
        }

<<<<<<< HEAD
        public async Task<IEnumerable<ISensorSpecification>> GetAllSensors()
=======
        public async Task Update()
>>>>>>> 80ed9acb03256809300c40694b0153580778031a
        {
            var response = await client.GetAsync("api/sensor/all");
            //Checking the response is successful or not which is sent using HttpClient  
            if (response.IsSuccessStatusCode)
            {
<<<<<<< HEAD
                //Deserializing the response recieved from web api and return the object
                var result = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<IEnumerable<ISensorSpecification>>(result);
=======
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




                //for (int i = 0; i < sensorsInfo.Count; i++)
                //{
                //    var sensorsToCheck = applicationDbContext.Sensors.Select(s => s.Id);
                //    foreach (var sensor in sensorsToCheck)
                //    {
                //        if (sensor.PollingInterval % intervalCounter == 0)
                //        {
                //            var curentState = await GetSensorById(sensorsInfo[i].SensorId);
                //            sensor.SensorH.Add(new SensorHistory()
                //            {
                //                ID = new Guid(),
                //                DateTime = DateTime.Now,
                //                Value = curentState.value,
                //                ValueType = curentState.valueType
                //            });
                //            Edit sensor last updated on SensorHistory DateTime;

                //            applicationDbContext.SaveChanges();

                //        }
                //    }
                //}
                //intervalCounter += 5;


>>>>>>> 80ed9acb03256809300c40694b0153580778031a
            }
            return null;
        }

        public async Task<IRealTimeState> GetRealTimeValue(Guid id)
        {
            var response = await this.client.GetAsync($"api/sensor/{id}");
            //Checking the response is successful or not which is sent using HttpClient  
            if (!response.IsSuccessStatusCode)
            {
                //Deserializing the response recieved from web api and return the object
                var result = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<IRealTimeState>(result);
            }
            return null;
        }
    }
}
