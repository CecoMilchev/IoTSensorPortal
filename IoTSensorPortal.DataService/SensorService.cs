using Bytes2you.Validation;
using IoTSensorPortal.Data;
using IoTSensorPortal.Data.DataModels;
using IoTSensorPortal.Data.Models;
using IoTSensorPortal.DataProvider.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Guid CreateSensor(string owner, ISensorRegisterModel model)
        {
            RegisteredUser user = this.GetUser(owner);
            DateTime createDate = DateTime.Now;
            List<History> history = new List<History> { new History() { Id = Guid.NewGuid(), UpdateDate = createDate } };
            Sensor sensor = new Sensor
            {
                Id = Guid.NewGuid(),
                History = history,
                IsPublic = model.IsPublic,
                LastUpdated = createDate,
                MaxValue = model.MaxValue,
                MinValue = model.MinValue,
                Name = model.Name,
                RefreshRate = model.RefreshRate,
                Url = model.Url,
                CurrentValue = "25"
            };
            user.OwnSensors.Add(sensor);
            this.context.SaveChanges();

            return sensor.Id;
        }
        public string ReadSensor(Guid id)
        {
            Sensor sensor =  this.context.Sensors.Find(id);
            return JsonConvert.SerializeObject(sensor);

        }
        public Guid UpdateSensor(Guid id, ISensorRegisterModel model)
        {
            return id;
        }
        public string DeleteSensor(Guid id)
        {
            return "fafaf";
        }

        public string ShareTo(string sharedToUser, Guid sensorId)
        {
            return "  ";
        }
        
        public IDictionary<Guid, string> GetPublicList()
        {
            //return this.context.Sensors.Where(s => s.IsPublic == true).ToList();

            return null;
        }
        public IDictionary<Guid, string> GetUserOwn(string userName)
        {
            return null;
        }
        public IDictionary<Guid, string> GetSharedToUser(string userName)
        {
            //RegisteredUser user = this.GetUser(username);

            //return this.context.Sensors.Where(s => s.OwnerId == user.Id)
            //    .Select(s => new SensorModel()
            //    {
            //        //URL = s.Url,
            //        //Tag = s.Name
            //    }).ToList();
            return null;
        }
        

        public IDictionary<Guid, string> GetAllSensorsList()
        {
            return null;
        } //Admin only action
       
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
        public IEnumerable<T> GetSensorSpecifications<T>()
        {
            return this.provider.GetAllSensorsInfo<T>();
        }

        //4.1 Register new sensor The newly created sensor should have its own:


        //public async Task<IEnumerable<string>> GetAllSensors()
        //{
        //    return await this.provider.GetAllSensorsInfo();
        //}

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
