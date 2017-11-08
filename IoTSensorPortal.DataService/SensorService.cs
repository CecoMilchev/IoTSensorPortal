using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoTSensorPortal.Data.Models;
using IoTSensorPortal.Data;
using Bytes2you.Validation;

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
        public void AddSensor() //+data
        {
            throw new NotImplementedException();
        }

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

    }
}
