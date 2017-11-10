using IoTSensorPortal.DataProvider.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IoTSensorPortal.DataProvider
{
    public class SensorDataProvider : ISensorDataProvider
    {
        private readonly HttpClient client;
        public SensorDataProvider(HttpClient sensorHttpClient)
        {
            this.client = sensorHttpClient;
        }

        public async Task<IEnumerable<ISensorSpecification>> Update()
        {
            var response = await client.GetAsync("api/sensor/all");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<IEnumerable<ISensorSpecification>>(result);
            }
            return null; //TO DO: Error handling
        }

        public async Task<IRealTimeState> GetRealTimeValue(Guid id)
        {
            var response = await this.client.GetAsync($"api/sensor/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<IRealTimeState>(result);
            }
            return null; //TO DO: Error handling
        }
    }
}
