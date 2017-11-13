using System;
using System.Collections.Generic;

namespace IoTSensorPortal.DataService
{
    public interface ISensorService
    {
        //C
        Guid CreateSensor(string owner, ISensorRegisterModel model);
        //R
        string ReadSensor(Guid id); //json
        //U
        Guid UpdateSensor(Guid id, ISensorRegisterModel model);
        //D
        string DeleteSensor(Guid id);

        string ShareTo(string registeredUser, Guid sensorId);

        IDictionary<Guid, string> GetAllSensorsList(); //admin action

        IDictionary<Guid, string> GetPublicList();

        IDictionary<Guid, string> GetUserOwn(string userName);

        IDictionary<Guid, string> GetSharedToUser(string userName);

        IDictionary<DateTime, int> GetHistory(Guid sensorId, TimeSpan period);

        IEnumerable<T> GetSensorSpecifications<T>();

        void Update(); //update to controller to update sensor specification every 30min
    }
}
