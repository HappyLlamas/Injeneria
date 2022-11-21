using LamaReader.Data;
using LamaReader.MainLogic;
using LamaReader.Pages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace LamaReader
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn 
        : Window
    {
        private readonly IAuth _auth;
        private readonly LlamaReaderDbContext dbContext;
        private static Dictionary<string, string> _strings
           = new Dictionary<string, string>()
           {
                { "SignUpPage", "/Pages/SignUp.xaml" },
                { "MainPage", "/Pages/Main.xaml" },
           };

        public SignIn(IAuth auth, LlamaReaderDbContext dbContext)
        {
            InitializeComponent();
            _auth = auth;
            this.dbContext = dbContext;
        }

        private void GotoSignUpClick(
            object sender, 
            RoutedEventArgs e)
        {
            SignUp signUp = new SignUp(_auth, dbContext);
            signUp.Show();
            Hide();
            return;
        }

        private void SignInClick(
            object sender,
            RoutedEventArgs e)
        {

            var email = Email.Text.ToString();
            var password = Password.Text.ToString();
            _auth.Login(email, password);
            Main main = new Main(_auth,dbContext);
            main.Show();
            Hide();
            //main.NavigationService.Navigate(
            //    source: new Uri(
            //        uriString: $".{_strings["MainPage"]}",
            //        uriKind: UriKind.Relative));
            return;
        }
    }
}
