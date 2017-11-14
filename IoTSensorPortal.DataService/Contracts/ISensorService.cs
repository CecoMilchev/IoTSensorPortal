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

        string ShareTo(Guid registeredUser, Guid sensorId);

        IList<string> GetAllSensorsList(); //admin action

        IList<string> GetPublicList();

        IList<string> GetUserOwn(string userName); //ako e string pestim join-ove v bazata

        IList<string> GetSharedToUser(string userName); //i tuk taka

        IDictionary<DateTime, int> GetHistory(Guid sensorId, TimeSpan period);

        IEnumerable<T> GetSensorSpecifications<T>();

        void Update(int counter); //update to controller to update sensor specification every 30min
    }
}
