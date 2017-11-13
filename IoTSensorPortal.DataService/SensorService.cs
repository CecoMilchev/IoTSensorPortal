using Bytes2you.Validation;
using IoTSensorPortal.Data;
using IoTSensorPortal.Data.DataModels;
using IoTSensorPortal.Data.Models;
using IoTSensorPortal.DataProvider;
using IoTSensorPortal.DataProvider.Contracts;
using IoTSensorPortal.DataService.Contracts;
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

        public IList<Dictionary<string, string>> GetAllSensors()
        {
            return this.provider.GetAllSensorsInfo();
        }

        public void RegisterSensor(string username)
        {
            RegisteredUser user = this.GetUser(username);
            DateTime createDate = DateTime.Now;
            List<History> history = new List<History> { new History() { Id = Guid.NewGuid(), UpdateDate = createDate } };

            Sensor sensor = new Sensor
            {
                Id = Guid.NewGuid(),
                History = history,
                IsPublic = true,
                LastUpdated = createDate,
                MaxValue = 20,
                MinValue = 13,
                Name = "Sensor 1",
                Owner = user,
                OwnerId = user.Id,
                RefreshRate = 10,
                SharedWithUsers = new List<RegisteredUser>(),
                Url = "f1796a28-642e-401f-8129-fd7465417061",
                CurrentValue = "25"
            };

            this.context.Sensors.Add(sensor);

            this.context.SaveChanges();
        }

        //4.3 Modify existing sensor
        public void EditSensor(Guid id, SensorModel model)
        {

        }

        public void DeleteSensor(Guid id)
        {

        }

        //4.4 Share a private sensor
        public void ShareTo(string sharedToUser, Guid sensorId)
        {

        }

        //4.2 View list of own sensors 
        public IEnumerable<SensorModel> GetUserOwn(string userName)
        {
            return null;
        }

        public IEnumerable<SensorModel> GetSharedToUser(string userName)
        {
            return null;
        }

        //3.3 View public sensors
        public List<Sensor> GetAllPublicSensors()
        {
            return this.context.Sensors.Where(s => s.IsPublic == true).ToList();
        }

        //Stored data should be used when showing sensor historical data.
        public IDictionary<DateTime, int> GetHistory(Guid sensorId, TimeSpan period)
        {

            // Should return id for created sensor to redirect detailed view
            return null;
        }

        public void Update()
        {
            this.provider.Update();
        }

        //4.1 Register new sensor The newly created sensor should have its own:


        //public async Task<IEnumerable<string>> GetAllSensors()
        //{
        //    return await this.provider.GetAllSensorsInfo();
        //}

        public IEnumerable<SensorModel> GetAllSensorsForUser(string username)
        {
            RegisteredUser user = this.GetUser(username);

            return this.context.Sensors.Where(s => s.OwnerId == user.Id)
                .Select(s => new SensorModel()
                {
                    //URL = s.Url,
                    //Tag = s.Name
                }).ToList();
        }

        private RegisteredUser GetUser(string username)
        {
            var user = this.context.Users.First(u => u.UserName == username);

            if (user == null)
            {
                throw new ArgumentNullException($"There is no user with username {username}!");
            }

            return user;
        }

    }
}
