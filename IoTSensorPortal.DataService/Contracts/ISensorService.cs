using IoTSensorPortal.Data.Models;
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

        List<ListItem> GetPublicList();

        IList<ListItem> GetUserOwn(string userName); //ako e string pestim join-ove v bazata

        IList<ListItem> GetSharedToUser(string userName); //i tuk taka

        IDictionary<DateTime, int> GetHistory(Guid sensorId, TimeSpan period);

        IEnumerable<T> GetSensorSpecifications<T>();
        
        void Update(); //update to controller to update sensor specification every 30min
    }
}
