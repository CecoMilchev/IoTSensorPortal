using IoTSensorPortal.Data.Models;
using System;
using System.Collections.Generic;

namespace IoTSensorPortal.DataService
{
    public interface ISensorService
    {
        IEnumerable<Sensor> GetAllSensors(int count);

        IEnumerable<Sensor> GetAllSensorsForUser(string username);
        
        void AddSensor(); //new data

        void ModifySensor(Guid id); //+new data

        void DeleteSensor(Guid id); //drop tables + api delete
    }
}
