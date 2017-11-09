using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IoTSensorPortal.DataProvider
{
    internal class SensorDataProvider : ISensorDataProvider
    {
        private readonly HttpClient client;
        public SensorDataProvider(HttpClient sensorHttpClient)
        {
            this.client = sensorHttpClient;
        }

        public async Task<IEnumerable<ISensorSpecification>> GetAllSensors()
        {
            var response = await client.GetAsync("api/sensor/all");
            //Checking the response is successful or not which is sent using HttpClient  
            if (response.IsSuccessStatusCode)
            {
                //Deserializing the response recieved from web api and return the object
                var result = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<IEnumerable<ISensorSpecification>>(result);
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
