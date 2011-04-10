using System.Collections.Generic;
using System.Linq;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrafikantenApp;
using TrafikantenApp.Services;

namespace TrafikantenAppTests
{
    [TestClass]  
    [Tag("Integration")]
    public class GivenIHaveARealtimeService : SilverlightTest
    {
        private IRealtimeStopsService _realtimeService;
        private bool _found;


        [TestMethod]
        [Asynchronous]
        public void WhenICallTheService_IShouldGetResponse()
        {
          

            _found = false;
            _realtimeService = new RealtimeStopsService();
            _realtimeService.StopsFound += (stops) =>
            {
                Assert.IsTrue(stops.First().Name == "Sinsen [T-bane]");
                EnqueueTestComplete();
            };

            _realtimeService.FindStops("Sinsen");

        }
    }
}
