using Bytes2you.Validation;
using IoTSensorPortal.Data;
using IoTSensorPortal.Data.Models;
<<<<<<< HEAD
using IoTSensorPortal.DataProvider;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
=======
using System;
using System.Collections.Generic;
>>>>>>> 80ed9acb03256809300c40694b0153580778031a

namespace IoTSensorPortal.DataService
{
    public class SensorService : ISensorService
    {
        private IdentityDbContext<IdentityUser> context;
        private ISensorDataProvider sensorDataProvider;

        internal SensorService(IdentityDbContext<IdentityUser> context, ISensorDataProvider sensorDataProvider)
        {
            Guard.WhenArgument(context, "applicationDbContext").IsNull().Throw();
            this.context = context;
            Guard.WhenArgument(sensorDataProvider, "SensorDataProvider").IsNull().Throw();
            this.context = context;
        }
<<<<<<< HEAD


        //The Application should have a private section which is accessible only for logged users.
        //4 Private part. This section should support the following functionality:

        //4.1 Register new sensor The newly created sensor should have its own:
        public bool CreateSensor(string ownerName, string name, string description, string url,
            int refreshRate, Measure unit, string unitRange, bool access)
        {
            return true;
        }
=======
        //public Guid CreateSensor(string userId) //+data
        //{
        //    Guard.WhenArgument(userId, "userId").IsNull().Throw();

        //    //var sensor = new Sensor()
        //    //{
        //    //    Id = Guid.NewGuid(),
        //    //    ApplicationUserId = sensorDto.OwnerId, //this is the owner of the sensor
        //    //    Description = sensorDto.Description,
        //    //    MinPollingIntervalInSeconds = sensorDto.MinPollingIntervalInSeconds,
        //    //    MeasureType = sensorDto.MeasureType,
        //    //    Tag = sensorDto.Tag                
        //    //};

        //    //this.applicationDbContext.Sensors.Add(sensor);
        //    //return sensor.Id;
        //}
>>>>>>> 80ed9acb03256809300c40694b0153580778031a

        //4.2 View list of own sensors  //bool isOwner = true => return OwnSensors; False => return sharedToHim
        //Must see 
        public IEnumerable<Sensor> GetAllSensors(string userName, bool isOwner = true)
        {
            var userSensors = new List<Sensor>();

            return userSensors;
        }

        //4.3 Modify existing sensor
        public bool EditSensor(Guid id, string name, string description, string url,
            int refreshRate, Measure unit, string unitRange)
        {
            return true;
        }

        //4.4 Share a private sensor
        public void ShareTo(string sharedToUser, Guid sensorId)
        {
            //edit in sql table
        }

        //3.3 View public sensors
        public Task<IEnumerable<Sensor>> GetAllSensors()
        {
            var publicSensors = new List<Sensor>();
            this.sensorDataProvider.GetAllSensors();

            //Tuk veche si izbirame kakvo da vrushtame kato obekt
        }

<<<<<<< HEAD
        //Stored data should be used when showing sensor historical data.
        public IDictionary<DateTime, int> GetHistory(Guid sensorId, TimeSpan period)
        {
            return null;
=======
        public Guid RegisterSensor(Sensor sensor)
        {
            var s = new Sensor
            {
                Name = sensor.Name,
                Description = s.Description,
                Url = s.Url,
                MinPollingIntervalInSeconds = s.PollingInterval,
                MeasureType = s.MeasureType,
                IsPublic = s.IsPublic,
                LastUpdated = System.DateTime.Now,
                Owner = s.Users.First(u => u.UserName == this.User.Identity.Name),
                CurrentValue = "555555"
            };

            dbContext.Sensors.Add(sensor);
            dbContext.SaveChanges();

            return = "";
            // Should return id for created sensor to redirect detailed view
>>>>>>> 80ed9acb03256809300c40694b0153580778031a
        }
    }
}
