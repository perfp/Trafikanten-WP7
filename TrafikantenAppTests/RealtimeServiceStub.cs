using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TrafikantenApp;

namespace TrafikantenAppTests
{
    public class RealtimeServiceStub : IRealtimeStopsService
    {
        public event Action<ObservableCollection<Stop>>  StopsFound;
        public void FindStops(string stopToFind)
        {
            var stops = new ObservableCollection<Stop>{
                new Stop {Name = "Sinsen Kirke"},
                new Stop {Name= "Lørenvangen"},
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
