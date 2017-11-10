using IoTSensorPortal.Data.Models;
using System;
using System.Collections.Generic;

namespace IoTSensorPortal.DataService.Contracts
{
    public interface ISensorService
    {
        void RegisterSensor(ISensorRegisterModel model);

        void EditSensor(Guid id, ISensorRegisterModel model);

        void DeleteSensor(Guid id);

        void ShareTo(string registeredUser, Guid sensorId);

        IEnumerable<Sensor> GetUserOwn(string username);

        IEnumerable<Sensor> GetSharedToUser(string userName);

        IEnumerable<Sensor> GetPublic();

        IDictionary<DateTime, int> GetHistory(Guid sensorId, TimeSpan period);

        IEnumerable<ISensorSpecification> Update(); //update to controller to update sensor specification every 30min
    }
}
