using System.Collections.Generic;
using System.Linq;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrafikantenApp;
using TrafikantenApp.Model;
using TrafikantenApp.Services;

namespace TrafikantenAppTests
{
    [TestClass]  
    [Tag("Integration")]
    public class GivenIHaveARealtimeService : SilverlightTest
    {
     
      
        [TestMethod]
        [Asynchronous]
        public void WhenICallTheService_IShouldGetResponse()
        {
          
            var realtimeStopsService = new RealtimeStopsService();
            realtimeStopsService.StopsFound += (stops) =>
            {
                Assert.IsTrue(stops.First().Name == "Sinsen [T-bane]");
                EnqueueTestComplete();
            };

            realtimeStopsService.FindStops("Sinsen");

        }

        [TestMethod]
        [Asynchronous]
        public void WhenICallTheVisitsService_IShouldGetResponse()
        {

            var realtimeStopsService = new RealtimeStopVisitsService();
            realtimeStopsService.VisitsFound += (visits) =>
            {
                Assert.IsTrue(visits.First().LineNumber == "23");
                EnqueueTestComplete();
            };

            realtimeStopsService.GetRealtimeVisitsForStop(new Stop {ID="3012087"});

        }

    }
}
