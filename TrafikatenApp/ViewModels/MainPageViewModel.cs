using System;
using Caliburn.Micro;

namespace TrafikantenApp.ViewModels
{
    public class MainPageViewModel : IViewAware 
    {
        private INavigationService _navigationService;
        private MainPage mainPage; 

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void Continue()
        {
            _navigationService.Navigate(new Uri("/StopsView.xaml", UriKind.RelativeOrAbsolute));
        }

        public void AttachView(object view, object context)
        {
            this.mainPage = (MainPage) view;
            this.mainPage.Loaded += (sender, ea) => Continue();
        }

        public object GetView(object context)
        {
            return mainPage;
        }

        public event EventHandler<ViewAttachedEventArgs> ViewAttached;
    }
}
