
using Bytes2you.Validation;
using IoTSensorPortal.DataProvider.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoTSensorPortal.DataService
{

    //The module which gathers data from the registered sensors and store their values for historical reasons.
    //The module should contain also analytics.
    public class SensorDataHubModule
    {
        private ISensorDataProvider provider;
        public SensorDataHubModule(ISensorDataProvider provider)
        {
            Guard.WhenArgument(provider, "provider").IsNull().Throw();
            this.provider = provider;
        }

        //public async Task<IEnumerable<>> GetAllSensorsInfo()
        //{
        //    return null;//await this.provider.GetAllSensorsInfo();
        //}
        //6.1 Sensor Data Polling

        //The module should poll data from sensors based on their pooling interval setting. 
        //Note that a sensor could have pooling interval of 1 minute and another could have pooling interval set to 5 minutes.
        //The data should be stored for historical reasons.

        //Your task is to create controller with action, that implement the logic for data polling and provide it to the service.
        //The provided windows service will invoke the implemented controller action on a configurable interval.
        //It’s the controller action responsibility to decide whether and which sensors data to poll.
    }
}
//roller action responsibility to decide whether and which sensors data to poll.


