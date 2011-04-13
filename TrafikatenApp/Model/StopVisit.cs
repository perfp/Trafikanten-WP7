 using System;
 using System.Windows;

namespace TrafikantenApp.Model
{
    public class StopVisit
    {
        public string LineNumber { get; set; }
        public string DestinationName { get; set; }
        public DateTime ExpectedDeparture { get; set; }
        public TimeSpan Delay { get; set; }
    }
}
