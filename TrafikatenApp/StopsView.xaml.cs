using Microsoft.Phone.Controls;

namespace TrafikantenApp
{
    public partial class StopsView : PhoneApplicationPage
    {
        public StopsView()
        {
            InitializeComponent();
        }

        private void StopToFind_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            StopToFind.SelectAll();
        }
    }
}