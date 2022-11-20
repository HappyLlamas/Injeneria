using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace LamaReader
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp 
        : Page
    {
        private static Dictionary<string, string> _strings
            = new Dictionary<string, string>()
            {
                { "SignInPage", "/Pages/SignIn.xaml" },
                { "MainPage", "/Pages/Main.xaml" },
                { "FBImage", "/Resources/LlamaReaderMockups-7.png" },
                { "GMailImage", "/Resources/LlamaReaderMockups-8.png" },
                { "LinkedInImage", "/Resources/LlamaReaderMockups-9.png" },
            };

        public SignUp()
        {
            InitializeComponent();
            return;
        }

        private void GotoSignInClick(
            object sender, 
            RoutedEventArgs e)
        {
            this.NavigationService.Navigate(
                source: new Uri(
                    uriString: $".{_strings["SignInPage"]}", 
                    uriKind: UriKind.Relative));
            return;
        }

        private void SignUpClick(
            object sender,
            RoutedEventArgs e)
        {
            this.NavigationService.Navigate(
                source: new Uri(
                    uriString: $".{_strings["MainPage"]}",
                    uriKind: UriKind.Relative));
            return;
        }

        private void LoadFBImage(
            object sender, 
            RoutedEventArgs e)
        {
            //this.FBImage.Source = new BitmapImage(
            //    uriSource: new Uri(
            //        uriString: $"..{SignUp._strings["FBImage"]}",
            //        uriKind: UriKind.Relative));
            return;
        }
    }
}
