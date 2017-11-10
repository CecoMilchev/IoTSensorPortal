using Bytes2you.Validation;
using IoTSensorPortal.Data;
using IoTSensorPortal.Data.Models;
using IoTSensorPortal.DataProvider.Contracts;
using IoTSensorPortal.DataService.Contracts;
using System;
using System.Collections.Generic;

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
        public Guid RegisterSensor(ISensorRegisterModel model)
        {
            var sensor = new Sensor { };
            //this.context.Users.Attach(sensor)
            return sensor.Id;
        }

        //4.3 Modify existing sensor
        public void EditSensor(Guid id, ISensorRegisterModel model)
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
        public IEnumerable<Sensor> GetUserOwn(string userName)
        {
            return null;
        }

        public IEnumerable<Sensor> GetSharedToUser(string userName)
        {
            return null;
        }

        //3.3 View public sensors
        public IEnumerable<Sensor> GetPublic()
        {
            return null;
        }

        //Stored data should be used when showing sensor historical data.
        public IDictionary<DateTime, int> GetHistory(Guid sensorId, TimeSpan period)
        {

            // Should return id for created sensor to redirect detailed view
            return null;
        }

        public IEnumerable<Contracts.ISensorSpecification> Update()
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<ISensorSpecification> Update()
        //{
        //    var result = this.provider.Update();
        //    return null;
        //}
        //4.1 Register new sensor The newly created sensor should have its own:


        //public IEnumerable<Sensor> GetAllSensors()
        //{

        //}

        //4.4 Share a private sensor
        //public void ShareTo(string sharedToUser, Guid sensorId)
        //{

        //}
    }
}
