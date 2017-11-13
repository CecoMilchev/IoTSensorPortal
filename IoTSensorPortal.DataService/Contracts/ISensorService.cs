using IoTSensorPortal.Data.DataModels;
using IoTSensorPortal.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoTSensorPortal.DataService
{
    public interface ISensorService
    {
        //IList<SensorModel> GetAllSensors();

        void RegisterSensor(string username);

        void EditSensor(Guid id, SensorModel model);

        void DeleteSensor(Guid id);

        void ShareTo(string registeredUser, Guid sensorId);

        IEnumerable<SensorModel> GetUserOwn(string username);

        IEnumerable<SensorModel> GetAllSensorsForUser(string username);

        IEnumerable<SensorModel> GetSharedToUser(string userName);

        IDictionary<DateTime, int> GetHistory(Guid sensorId, TimeSpan period);

        void Update(); //update to controller to update sensor specification every 30min
    }
}
