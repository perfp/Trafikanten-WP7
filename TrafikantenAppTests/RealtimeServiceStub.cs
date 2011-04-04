using System;
using System.Collections.Generic;
using TrafikantenApp;

namespace TrafikantenAppTests
{
    public class RealtimeServiceStub : IRealtimeStopsService
    {
        public event Action<IList<Stop>>  StopsFound;
        public void FindStops(string stopToFind)
        {
            var stops = new List<Stop>{
                new Stop {Name = "Sinsen Kirke"},
                new Stop {Name = "Lørenvangen"},
                new Stop {Name = "Sinsenkrysset"},
                new Stop {Name = "Carl Berner [T]"},
                new Stop {Name = "Torshov"},
                new Stop {Name = "Nationaltheateret"}
            };

            if (StopsFound != null)
                StopsFound(stops);
        }
    }
}
