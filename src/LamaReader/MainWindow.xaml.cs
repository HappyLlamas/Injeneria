using LamaReader.Data;
using LamaReader.MainLogic;
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
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow 
		: Window
	{
        private readonly IAuth _auth;
        public MainWindow(IAuth auth, LlamaReaderDbContext dbContext)
		{
			InitializeComponent();
			_auth = auth;
			SignIn signIn = new SignIn ( _auth,dbContext  );
			signIn.Show();
			Hide();

			//NavigationWindow window = new NavigationWindow();
			//window.Source = new Uri(
			//	uriString: "./Pages/SignIn.xaml", 
			//	uriKind: UriKind.Relative);
   //         window.ShowsNavigationUI = false;
			//window.Closed += Window_Closed;
			//window.Show();

			//this.Visibility = Visibility.Hidden;
			return;
		}

		//private void Window_Closed(
		//	object? sender, 
		//	EventArgs e)
		//{
		//	this.Close();
		//	return;
		//}
	}
}
