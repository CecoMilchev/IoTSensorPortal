using Bytes2you.Validation;
using IoTSensorPortal.Data;
using IoTSensorPortal.Data.Models;
using System;
using System.Collections.Generic;

namespace IoTSensorPortal.DataService
{
    public class SensorService : ISensorService
    {
        private ApplicationDbContext applicationDbContext;

        public SensorService(ApplicationDbContext applicationDbContext)
        {
            Guard.WhenArgument(applicationDbContext, "applicationDbContext").IsNull().Throw();

            this.applicationDbContext = applicationDbContext;
        }
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

        public void DeleteSensor(Guid id)
        {
            throw new NotImplementedException();
        }

        public void ModifySensor(Guid id) //+the new data
        {
            throw new NotImplementedException();
        }

        //Public sensors
        public IEnumerable<Sensor> GetAllSensors()
        {
            throw new NotImplementedException();
        }

        //for registred user
        public IEnumerable<Sensor> GetAllSensorsForUser(string username)
        {
            throw new NotImplementedException();
        }

        public Guid CreateSensor(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
