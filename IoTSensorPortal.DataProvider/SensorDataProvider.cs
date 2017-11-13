using Bytes2you.Validation;
using IoTSensorPortal.Data;
using IoTSensorPortal.Data.DataModels;
using IoTSensorPortal.Data.Models;
using IoTSensorPortal.DataProvider.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IoTSensorPortal.DataProvider
{
    public class SensorDataProvider : ISensorDataProvider
    {
        private readonly SensorHttpClient client;
        private readonly ApplicationDbContext context;
        private int counter;
        public SensorDataProvider(ApplicationDbContext context)
        {
            this.client = new SensorHttpClient();
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;
            counter = 5;
        }

        public IEnumerable<SensorInfo> GetAllSensorsInfo()
        {
            var sensorsInfo = new List<SensorInfo>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();

                client.BaseAddress = new Uri("http://telerikacademy.icb.bg/");

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("auth-token", "8e4c46fe-5e1d-4382-b7fc-19541f7bf3b0");

                var response = this.client.GetAsync($"http://telerikacademy.icb.bg/api/sensor/all").Result;


                if (response.IsSuccessStatusCode)
                {

                    var result = response.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    sensorsInfo = JsonConvert.DeserializeObject<List<SensorInfo>>(result);
                }
            }
            //var sensorSpecifications = new List<History>();

            //var response = await client.GetAsync("api/sensor/all");
            //if (response.IsSuccessStatusCode)
            //{
            //    var result = response.Content.ReadAsStringAsync().Result;
            //    sensorSpecifications = JsonConvert.DeserializeObject<List<History>>(result);
            //}

            return sensorsInfo;
        }


        public History GetRealTimeValue(string URL)
        {
            var response = this.client.GetAsync($"api/sensor/{URL}").Result;
            History sensorState = new History();

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                sensorState = JsonConvert.DeserializeObject<History>(result);
            }
            sensorState.UpdateDate = DateTime.Now;
            sensorState.Id = Guid.NewGuid();

            return sensorState;
        }

        public void Update()
        {
            //var sensorsInfo = GetAllSensorsInfo().ToList();


            var sensors = this.context.Sensors.ToList();

            foreach (var sensor in sensors)
            {
                if (sensor.RefreshRate % counter == 0)
                {
                    var newState = GetRealTimeValue(sensor.Url);
                    newState.SensorId = sensor.Id;
                    newState.Sensor = sensor;
                    sensor.History.Add(newState);
                    sensor.LastUpdated = newState.UpdateDate;
                    sensor.CurrentValue = newState.Value;
                }
            }
            context.SaveChanges();
            counter += 5;
        }
    }
}
