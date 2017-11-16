using System;
using System.Collections.Generic;

namespace IoTSensorPortal.DataService
{
    public interface ISensorService
    {
        //CRUD
        Guid CreateSensor(string owner, IRegisterableModel model);
        IRegisterableModel ReadSensor(Guid id);
        Guid UpdateSensor(Guid id, IRegisterableModel model);
        string DeleteSensor(Guid id);

        //Sharing
        string ShareTo(Guid registeredUser, Guid sensorId);

        //Listing
        IList<string> GetAllSensorsList(); //admin action
        List<ListItemModel> GetPublicList();
        List<ListItemModel> GetUserOwn(string userName);
        List<ListItemModel> GetSharedToUser(string userName);

        //History
        IDictionary<DateTime, int> GetHistory(Guid sensorId, TimeSpan period);

        //Other
        IEnumerable<SpecificationModel> GetSensorSpecifications();
        void Update(); //update to controller to update sensor specification every 30min
    }
}
