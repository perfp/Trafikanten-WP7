using System;
using System.Collections.Generic;

namespace TrafikantenApp
{
    public interface IRealtimeStopsService
    {
        void FindStops(string stopToFind);
        event Action<IList<Stop>> StopsFound;
    }
}