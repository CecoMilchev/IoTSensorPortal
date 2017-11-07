using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoTSensorPortal.Data.Models;

namespace IoTSensorPortal.DataService
{
    public class SensorService : ISensorService
    {
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
        public IEnumerable<Sensor> GetAllSensors(int count)
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
