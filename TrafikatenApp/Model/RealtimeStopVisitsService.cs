using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace TrafikantenApp.Model
{
    public class RealtimeStopVisitsService : IRealtimeStopVisitsService
    {
       
        public void GetRealtimeVisitsForStop(Stop stop)
        {
            var client = new WebClient();
            client.DownloadStringCompleted += VisitsReceived;
            client.DownloadStringAsync(new Uri("http://reis.trafikanten.no/siri/sm.aspx?id=" + stop.ID));
        }

        private void VisitsReceived(object sender, DownloadStringCompletedEventArgs e)
        {
            var result = XElement.Parse(e.Result);
            XNamespace ns = "http://www.siri.org.uk/";

            var visits = from visit in result.Descendants(ns + "MonitoredStopVisit")
                         select new StopVisit
                         {
                             LineNumber = visit.Element(ns + "PublishedLineName").Value,
                             DestinationName = visit.Element(ns + "DestinationName").Value,
                             ExpectedDeparture = DateTime.Parse(visit.Element(ns + "ExpectedDepartureTime").Value)
                         };
           
            if (VisitsFound != null) VisitsFound(visits);
        }

        public event Action<IEnumerable<StopVisit>> VisitsFound;
    }
}
