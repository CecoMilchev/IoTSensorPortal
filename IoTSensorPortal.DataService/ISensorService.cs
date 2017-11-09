using IoTSensorPortal.Data.Models;
using System;
using System.Collections.Generic;

namespace IoTSensorPortal.DataService
{
    public interface ISensorService
    {
        IEnumerable<Sensor> GetAllSensors();

        IEnumerable<Sensor> GetAllSensorsForUser(string username);
        
        Guid RegisterSensor(SensorRegisterModel model); //new data

        void ModifySensor(Guid id); //+new data

        void DeleteSensor(Guid id); //drop tables + api delete
    }
}
