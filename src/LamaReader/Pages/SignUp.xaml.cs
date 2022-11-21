using LamaReader.Data;
using LamaReader.MainLogic;
using LamaReader.Pages;
using Microsoft.EntityFrameworkCore;
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
        : Window
    {
        private readonly IAuth _auth;
        private readonly LlamaReaderDbContext dbContext;
        private static Dictionary<string, string> _strings
            = new Dictionary<string, string>()
            {
                { "SignInPage", "/Pages/SignIn.xaml" },
                { "MainPage", "/Pages/Main.xaml" },
                { "FBImage", "/Resources/LlamaReaderMockups-7.png" },
                { "GMailImage", "/Resources/LlamaReaderMockups-8.png" },
                { "LinkedInImage", "/Resources/LlamaReaderMockups-9.png" },
            };

        public SignUp(IAuth auth, LlamaReaderDbContext dbContext)
        {
            InitializeComponent();
            //_auth = new Auth(new AuthService(new LlamaReaderDbContext(new DbContextOptions<LlamaReaderDbContext>())));
            _auth = auth;
            this.dbContext = dbContext;
        }

        private void GotoSignInClick(
            object sender, 
            RoutedEventArgs e)
        {
            SignIn signIn = new SignIn(_auth, dbContext);
            signIn.Show();
            Hide();
            //this.NavigationService.Navigate(
            //    source: new Uri(
            //        uriString: $".{_strings["SignInPage"]}", 
            //        uriKind: UriKind.Relative));
            return;
        }

        private void SignUpClick(
            object sender,
            RoutedEventArgs e)
        {
            var email = Email.Text.ToString();
            var password = Password.Text.ToString();
            _auth.Registration("Bill", email, password);

            Main main = new Main(_auth, dbContext);
            main.Show();
            Hide();


            //main.NavigationService.Navigate(
            //    source: new Uri(
            //        uriString: $".{_strings["MainPage"]}",
            //        uriKind: UriKind.Relative));
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
