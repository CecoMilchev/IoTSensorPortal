namespace IoTSensorPortal.DataService
{
    //The module which gathers data from the registered sensors and store their values for historical reasons.
    //The module should contain also analytics.
    class SensorDataHubModule 
    {
        //6.1 Sensor Data Polling

        //The module should poll data from sensors based on their pooling interval setting. 
        //Note that a sensor could have pooling interval of 1 minute and another could have pooling interval set to 5 minutes.
        //The data should be stored for historical reasons.

        //Your task is to create controller with action, that implement the logic for data polling and provide it to the service.
        //The provided windows service will invoke the implemented controller action on a configurable interval.
        //It’s the controller action responsibility to decide whether and which sensors data to poll.

    }
}







//var sensorsInfo = new List<SensorInfo>(); 
//                //Checking the response is successful or not which is sent using HttpClient  
//                if (Res.IsSuccessStatusCode)
//                {
//                    //Storing the response details recieved from web api   
//                    var sensorResponse = Res.Content.ReadAsStringAsync().Result;
////Deserializing the response recieved from web api and storing into the Employee list  
//sensorsInfo = JsonConvert.DeserializeObject<List<SensorInfo>>(sensorResponse);
//                }
//                var sensorsState = new List<string>(new string[sensorsInfo.Count]);
//
//                for (int i = 0; i<sensorsInfo.Count; i++)
//                {
//                    sensorsState[i] = i + ". " + await GetSensorById(sensorsInfo[i].SensorId);
//                }
//
//                string path = @"C:\Program Files\IcbShceduledJob\Logs\Sensors Current State.txt";
//
//// This text is added only once to the file.
//// Create a file to write to.
//File.WriteAllLines(path, sensorsState, Encoding.UTF8);             
