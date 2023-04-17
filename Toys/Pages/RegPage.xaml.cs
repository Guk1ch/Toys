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
	/// Interaction logic for RegPage.xaml
	/// </summary>
	public partial class RegPage : Page
	{
		public static ObservableCollection<User> users { get; set; }
		public RegPage()
		{
			InitializeComponent();
		}

		private void btnBack_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new AuthorisPage());
		}

		private void btnReg_Click(object sender, RoutedEventArgs e)
		{
            string nickName = tbName.Text.Trim();
            string login = tbLog.Text.Trim();
            string pass = tbPass.Password.Trim();
            if (UniqueLogin(login))
            {
                if (nickName != "" && login != "" && pass != "")
                {
                    RegistrationUser(nickName, login, pass);

                    System.Windows.MessageBox.Show("Аккаунт успешно создан!");
                    NavigationService.Navigate(new AuthorisPage());
                }
                else
                {
                    System.Windows.MessageBox.Show("Заполните все поля!");
                }
            }
            else
            {
                tbLog.Text = "";
                System.Windows.MessageBox.Show("Придумайте другой логин");
            }
           
		}
        public static void RegistrationUser(string nick, string login, string password)
        {
            User newUser = new User();

            newUser.Name = nick;
            newUser.Login = login;
            newUser.Password = password;

            BDConnection.connection.User.Add(newUser);
            BDConnection.connection.SaveChanges();
          

        }
        public static bool UniqueLogin(string login)
        {
            users = new ObservableCollection<User>(BDConnection.connection.User.ToList());
            bool LoginUnic = true;
            foreach (var i in users)
            {
                if (i.Login == login)
                {
                    LoginUnic = false;
                }
            }
            return LoginUnic;
        }
    }
}
