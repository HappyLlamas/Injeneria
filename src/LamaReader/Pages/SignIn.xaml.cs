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
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn 
        : Page
    {
        private static Dictionary<string, string> _strings
           = new Dictionary<string, string>()
           {
                { "SignUpPage", "/Pages/SignUp.xaml" },
                { "MainPage", "/Pages/Main.xaml" },
           };

        public SignIn()
        {
            InitializeComponent();
            return;
        }

        private void GotoSignUpClick(
            object sender, 
            RoutedEventArgs e)
        {
            this.NavigationService.Navigate(
                source: new Uri(
                    uriString: $".{_strings["SignUpPage"]}", 
                    uriKind: UriKind.Relative));
            return;
        }

        private void SignInClick(
            object sender,
            RoutedEventArgs e)
        {
            this.NavigationService.Navigate(
                source: new Uri(
                    uriString: $".{_strings["MainPage"]}",
                    uriKind: UriKind.Relative));
            return;
        }
    }
}
