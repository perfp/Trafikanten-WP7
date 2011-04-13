using System;
using System.Collections.Generic;

namespace TrafikantenApp.Model
{
    public interface IRealtimeStopVisitsService
    {
        void GetRealtimeVisitsForStop(Stop stop);
        event Action<IEnumerable<StopVisit>> VisitsFound;
    }
}