using Bytes2you.Validation;
using IoTSensorPortal.Data;
using IoTSensorPortal.Data.Models;
using IoTSensorPortal.DataProvider.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTSensorPortal.DataService
{
    public class SensorService : ISensorService
    {
        private ApplicationDbContext context;
        private ISensorDataProvider provider;

        public SensorService(ApplicationDbContext context, ISensorDataProvider provider)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;
            Guard.WhenArgument(provider, "provider").IsNull().Throw();
            this.provider = provider;
        }

        //4.1 Register new sensor The newly created sensor should have its own:
        public async Task<string> RegisterSensor(string owner, ISensorRegisterModel model)
        {
            var legitOwner = this.context.Users.First(x => x.UserName == owner); //possible null ref

            var sensor = new Sensor //possible entity error when we have validation
            {
                Url = model.Url,
                Name = model.Name,
                RefreshRate = model.RefreshRate,
                MinValue = model.MinValue,
                MaxValue = model.MaxValue,
                IsPublic = model.IsPublic
            };

            var history = new History { Sensor = sensor };

            var valueCheck = await provider.GetRealTimeValue(model.Url); //possible network error
            history.UpdateDate = valueCheck.TimeStamp;
            history.Value = valueCheck.Value;

            legitOwner.OwnSensors.Add(sensor);
            sensor.LastUpdated = DateTime.UtcNow; //mai trqbva da si otide tova prop
            await this.context.SaveChangesAsync(); //posible sql validation error

            return sensor.Id.ToString();
        }

        //4.3 Modify existing sensor
        public void EditSensor(string id, ISensorRegisterModel model)
        {

        }

        public void DeleteSensor(string id)
        {

        }

        //4.4 Share a private sensor
        public void ShareTo(string sharedToUser, string sensorId)
        {

        }

        //4.2 View list of own sensors 
        public IEnumerable<Sensor> GetUserOwn(string userName)
        {
            return null;
        }

        public IEnumerable<Sensor> GetSharedToUser(string userName)
        {
            return null;
        }

        //3.3 View public sensors
        public IEnumerable<ISensorShortModel> GetPublic()
        {
            return null; //NULL REF
        }

        //Stored data should be used when showing sensor historical data.
        public IDictionary<DateTime, int> GetHistory(string sensorId, TimeSpan period)
        {

            // Should return id for created sensor to redirect detailed view
            return null;
        }

        public async Task<IEnumerable<ISensorSpecification>> Update()
        {
            var result = await this.provider.Update<ISensorSpecification>("api/sensor/all");
            return result;
        }

    }
}
