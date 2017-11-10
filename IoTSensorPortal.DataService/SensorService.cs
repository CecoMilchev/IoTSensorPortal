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
        public void RegisterSensor(ISensorRegisterModel model)
        {

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

        //public IEnumerable<ISensorSpecification> Update()
        //{
        //    var result = this.provider.Update();
        //    return null;
        //}

        public IEnumerable<Sensor> GetAllSensors()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sensor> GetAllSensorsForUser(string username)
        {
            throw new NotImplementedException();
        }

        public Guid RegisterSensor()
        {
            throw new NotImplementedException();
        }

        public void ModifySensor(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAllSensors()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllSensorsType()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contracts.ISensorSpecification> Update()
        {
            throw new NotImplementedException();
        }
    }
}
