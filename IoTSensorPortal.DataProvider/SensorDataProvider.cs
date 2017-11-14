using Bytes2you.Validation;
using IoTSensorPortal.Data;
using IoTSensorPortal.Data.Models;
using IoTSensorPortal.DataProvider.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IoTSensorPortal.DataProvider
{
    public class SensorDataProvider : ISensorDataProvider
    {
        private readonly SensorHttpClient client;
        private readonly ApplicationDbContext context;

        public SensorDataProvider(ApplicationDbContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;
            this.client = new SensorHttpClient();
        }

        public IEnumerable<T> GetAllSensorsInfo<T>()
        {
            var sensorsInfo = new List<T>();

            var response = this.client.GetAsync($"api/sensor/all").Result;
            
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result; 
                sensorsInfo = JsonConvert.DeserializeObject<List<T>>(result);
            }

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
            var sensors = this.context.Sensors.ToList();

            foreach (var sensor in sensors)
            {
                if (DateTime.Now - sensor.LastUpdated >= TimeSpan.FromSeconds(sensor.RefreshRate))
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
        }
    }
}
