using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace TrafikantenApp.Services
{
    public class RealtimeStopsService : IRealtimeStopsService
    {    
        private ObservableCollection<Stop> _items = new ObservableCollection<Stop>();
        private WebClient _client;

        public void FindStops(string stopToFind)
        {
            RetrieveStops(stopToFind);
        }

        public event Action<ObservableCollection<Stop>> StopsFound;

        private void RetrieveStops(string name)
        {
            _client = new WebClient();
            _client.DownloadStringCompleted += StopReceived;
            _client.DownloadStringAsync(new Uri("http://reis.trafikanten.no/siri/checkrealtimestop.aspx?name=" + name));
            
       }

        private void StopReceived(object sende, DownloadStringCompletedEventArgs eventArgs)
        {            
            var result = XElement.Parse(eventArgs.Result);
            var stops = from stop in result.Descendants("Place")
                        select
                            new Stop { Name = stop.Element("Name").Value, ID = stop.Element("ID").Value };

            stops.ToList().ForEach(s=>_items.Add(s));

            StopsFound(_items);
        }

    }
}
