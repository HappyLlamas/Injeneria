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
		public MainWindow()
		{
			InitializeComponent();

			NavigationWindow window = new NavigationWindow();
			window.Source = new Uri(
				uriString: "./Pages/SignIn.xaml", 
				uriKind: UriKind.Relative);
            window.ShowsNavigationUI = false;
			window.Closed += Window_Closed;
			window.Show();

			this.Visibility = Visibility.Hidden;
			return;
		}

		private void Window_Closed(
			object? sender, 
			EventArgs e)
		{
			this.Close();
			return;
		}
	}
}
