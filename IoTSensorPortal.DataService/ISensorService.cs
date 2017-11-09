<<<<<<< HEAD
﻿using IoTSensorPortal.Data;
using IoTSensorPortal.Data.Models;
=======
﻿using IoTSensorPortal.Data.Models;
>>>>>>> 80ed9acb03256809300c40694b0153580778031a
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoTSensorPortal.DataService
{
    public interface ISensorService
    {
        //void DeleteSensor(Guid id); //drop tables + api delete

<<<<<<< HEAD
        bool CreateSensor(string ownerName, string name, string description, string url,
            int refreshRate, Measure unit, string unitRange, bool isPublic);
=======
        IEnumerable<Sensor> GetAllSensorsForUser(string username);
        
        Guid RegisterSensor(SensorRegisterModel model); //new data
>>>>>>> 80ed9acb03256809300c40694b0153580778031a

        IEnumerable<Sensor> GetAllSensors(string userName, bool isOwner = true);

        bool EditSensor(Guid id, string name, string description, string url, int refreshRate, Measure unit, string unitRange);

        void ShareTo(string registeredUser, Guid sensorId);

        Task<IEnumerable<Sensor>> GetAllSensors();

        IDictionary<DateTime, int> GetHistory(Guid sensorId, TimeSpan period);
    }
}
