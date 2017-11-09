using IoTSensorPortal.Data;
using IoTSensorPortal.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoTSensorPortal.DataService
{
    public interface ISensorService
    {
        //void DeleteSensor(Guid id); //drop tables + api delete

        bool CreateSensor(string ownerName, string name, string description, string url,
            int refreshRate, Measure unit, string unitRange, bool isPublic);

        IEnumerable<Sensor> GetAllSensors(string userName, bool isOwner = true);

        bool EditSensor(Guid id, string name, string description, string url, int refreshRate, Measure unit, string unitRange);

        void ShareTo(string registeredUser, Guid sensorId);

        Task<IEnumerable<Sensor>> GetAllSensors();

        IDictionary<DateTime, int> GetHistory(Guid sensorId, TimeSpan period);
    }
}
