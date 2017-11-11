using IoTSensorPortal.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoTSensorPortal.DataService
{
    public interface ISensorService
    {
        Task<string> RegisterSensor(string owner, ISensorRegisterModel model);

        void EditSensor(string id, ISensorRegisterModel model);

        void DeleteSensor(string id);

        void ShareTo(string registeredUser, string sensorId);

        IEnumerable<Sensor> GetUserOwn(string username);

        IEnumerable<Sensor> GetSharedToUser(string userName);

        IEnumerable<ISensorShortModel> GetPublic();

        IDictionary<DateTime, int> GetHistory(string sensorId, TimeSpan period);

        //update to controller to update sensor specification every 30min
        Task<IEnumerable<ISensorSpecification>> Update();
    }
}
