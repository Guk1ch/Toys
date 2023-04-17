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
using System.Collections.ObjectModel;
using Toys.DataBase;

namespace Toys.Pages
{
	/// <summary>
	/// Interaction logic for ManePage.xaml
	/// </summary>
	public partial class ManePage : Page
	{
		public static ObservableCollection<Product> products { get; set; }
		public ManePage(User user)
		{
			InitializeComponent();
			products = new ObservableCollection<Product>(BDConnection.connection.Product.ToList());
			DataContext = this;
		}

		private void btnADD_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnBack_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new AuthorisPage());
		}

		private void TbSearch_SelectionChanged(object sender, RoutedEventArgs e)
		{

		}

		private void lvCL_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}
