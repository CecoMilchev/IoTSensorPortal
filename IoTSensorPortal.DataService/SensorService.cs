using Bytes2you.Validation;
using IoTSensorPortal.Data;
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
            RegisteredUser user = this.context.Users.First(x => x.UserName == owner);
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
                CurrentValue = null
            };
            user.OwnSensors.Add(sensor);
            this.context.SaveChanges();

            return sensor.Id;
        }

        public string ReadSensor(Guid id)
        {
            Sensor sensor = this.context.Sensors.Find(id);
            return JsonConvert.SerializeObject(sensor, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

        }

        public Guid UpdateSensor(Guid id, ISensorRegisterModel model)
        {
            var sensor = this.context.Sensors.Find(id);
            sensor.Url = model.Url; //proverka dali se e smenil typa ako da create sensor i tiq danni
            sensor.Name = model.Name;
            sensor.RefreshRate = model.RefreshRate;
            sensor.MinValue = model.MinValue;
            sensor.MaxValue = model.MaxValue;
            sensor.IsPublic = model.IsPublic;
            this.context.SaveChanges();

            return id;
        }

        public string DeleteSensor(Guid id)
        {
            var sensor = this.context.Sensors.Find(id);
            this.context.Sensors.Remove(sensor);
            this.context.SaveChanges();
            return $"Sensor was removed";
        }

        public string ShareTo(Guid sharedToUser, Guid sensorId)
        {
            var user = GetUser(sharedToUser);
            this.context.Sensors.Find(sensorId).SharedWithUsers.Add(user);
            this.context.SaveChanges();
            return $"Shared to {user.UserName}";
        }

        public List<ListItem> GetPublicList()
        {
            var result = this.context.Sensors.
                Where(x => x.IsPublic == true).
                Select(x => new ListItem { Id = x.Id, Title = x.Owner.UserName + "`s " + x.Name }).
                ToList();

            return result;
        }

        public List<ListItem> GetUserOwn(string userName)
        {
            var result = this.context.Users.
                First(x => userName == x.UserName).
                OwnSensors.
                Select(x => new ListItem { Id = x.Id, Title = x.Owner.UserName + "`s " + x.Name }).
                ToList();

            return result;
        }

        public List<ListItem> GetSharedToUser(string userName)
        {
            var result = this.context.Users.
                First(x => userName == x.UserName).
                SharedSensors.
                Select(x => new ListItem { Id = x.Id, Title = x.Owner.UserName + "`s " + x.Name }).
                ToList();

            return result;
        }

        //Admin only action
        public IList<string> GetAllSensorsList()
        {
            var result = this.context.Sensors.Select(x => x.Id + " " + x.Name + " " + x.LastUpdated + " " + (x.IsPublic?"Public":"Private") + " " + x.RefreshRate).ToArray();
            return result;
        }

        public IDictionary<DateTime, int> GetHistory(Guid sensorId, TimeSpan period)
        {
            return null;
        }

        public IEnumerable<T> GetSensorSpecifications<T>()
        {
            var allTypes = this.provider.GetAllSensorsInfo<T>();
            return allTypes;
        }

        private RegisteredUser GetUser(Guid userId)
        {
            var user = this.context.Users.Find(userId);

            if (user == null)
            {
                throw new ArgumentNullException($"There is no user with key {userId}!");
            }

            return user;
        }

        public void Update()
        {
            this.provider.Update();
        }
    }
}
