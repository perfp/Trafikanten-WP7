using System.Collections.Generic;

namespace TrafikantenApp.ViewModels
{
    public class StopsViewModel
    {
        private IRealtimeStopsService _realtimeStopsService;
        public StopsViewModel(IRealtimeStopsService realtimeStopsService)
        {
            ListOfStops = new List<Stop>();
            _realtimeStopsService = realtimeStopsService;
        }

        public string StopToFind { get; set; }

        public IList<Stop> ListOfStops { get; private set; }

        public void FindStops()
        {
            _realtimeStopsService.StopsFound += StopsFound;

            _realtimeStopsService.FindStops(StopToFind);
            
        }

        private void StopsFound(IList<Stop> stops)
        {
            ListOfStops = stops;
        }
    }
}
