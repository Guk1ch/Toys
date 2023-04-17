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
	/// Interaction logic for AuthorisPage.xaml
	/// </summary>
	public partial class AuthorisPage : Page
	{
		public static User user;
		public AuthorisPage()
		{
			InitializeComponent();
		}

		private void btnEnter_Click(object sender, RoutedEventArgs e)
		{
			string login = tbLog.Text.Trim();
			string password = tbPass.Password.Trim();
			user = AuthorizationUser(login, password);
			if (user != null)
			{

				NavigationService.Navigate(new ManePage(user));
			}
			else
			{ 
				MessageBox.Show("Неверный логин или пароль", "error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void btnReg_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new RegPage());
		}
		public static ObservableCollection<User> users { get; set; }
		public static User AuthorizationUser(string login, string password)
		{
			users = new ObservableCollection<User>(BDConnection.connection.User.ToList());
			var userExists = users.Where(user => user.Login == login && user.Password == password).FirstOrDefault();
			if (userExists != null)
			{
				return userExists;
			}
			else
			{
				return userExists;
			}
		}
	}
}
