using Microsoft.Phone.Controls;
using Microsoft.Silverlight.Testing;

namespace TrafikantenAppTests
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            
            //UnitTestSettings settings = new UnitTestSettings();
            //settings.StartRunImmediately = true;
            //settings.TestAssemblies.Add(typeof(App).Assembly);
            //settings.ShowTagExpressionEditor = false;
            //settings.TestHarness = new Microsoft.Silverlight.Testing.Harness.UnitTestHarness();
            Content = UnitTestSystem.CreateTestPage();
            
            var imtp = (IMobileTestPage)Content ;
            BackKeyPress += (x, xe) => xe.Cancel = imtp.NavigateBack();
            
            
        }
    }
}