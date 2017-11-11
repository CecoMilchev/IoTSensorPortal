using IoTSensorPortal.DataProvider.Contracts;
using Newtonsoft.Json;
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

        public async Task<IEnumerable<T>> Update<T>(string action)
        {
            var response = await client.GetAsync(action);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<IEnumerable<T>>(result);
            }
            return null; //TO DO: Error handling
        }

        public async Task<IRealTimeState> GetRealTimeValue(string id) //mojem direktno history obekt da mu podadem
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
