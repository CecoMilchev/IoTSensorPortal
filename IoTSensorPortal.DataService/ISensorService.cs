using IoTSensorPortal.Data.Models;
using IoTSensorPortal.DTOs;
using System;
using System.Collections.Generic;

namespace IoTSensorPortal.DataService
{
    public interface ISensorService
    {
        IEnumerable<Sensor> GetAllSensors();

        IEnumerable<Sensor> GetAllSensorsForUser(string username);
        
        Guid CreateSensor(SensorDto sensorDto, string userId); //new data

        void ModifySensor(Guid id); //+new data

        void DeleteSensor(Guid id); //drop tables + api delete
    }
}
