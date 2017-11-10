﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTSensorPortal.DataProvider.Contracts
{
    public interface ISensorDataProvider
    {
        Task<IEnumerable<ISensorSpecification>> Update();

        Task<IRealTimeState> GetRealTimeValue(Guid sensorId);
    }
}