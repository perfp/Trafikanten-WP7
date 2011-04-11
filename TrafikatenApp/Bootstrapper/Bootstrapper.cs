using System;
using System.Collections.Generic;
using Caliburn.Micro;
using TrafikantenApp.Services;
using TrafikantenApp.ViewModels;

namespace TrafikantenApp
{
public class Bootstrapper : PhoneBootstrapper
    {

        PhoneContainer container;

        protected override void Configure()
        {
            container = new PhoneContainer(this);
            container.RegisterPerRequest(typeof(IRealtimeStopsService), null, typeof(RealtimeStopsService));
            container.RegisterPerRequest(typeof(StopsViewViewModel), "StopsViewModel", typeof(StopsViewViewModel));
            container.RegisterPerRequest(typeof(RealtimeResultsViewModel), "RealtimeResultsViewModel", typeof(RealtimeResultsViewModel));
            container.RegisterPerRequest(typeof(MainPageViewModel), "MainPageViewModel", typeof(MainPageViewModel));
            container.RegisterInstance(typeof(INavigationService), null, new FrameAdapter(RootFrame));

            
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
    }
}