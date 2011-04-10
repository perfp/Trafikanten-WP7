using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TrafikantenApp
{
    public interface IRealtimeStopsService
    {
        void FindStops(string stopToFind);
        event Action<ObservableCollection<Stop>> StopsFound;
    }
}