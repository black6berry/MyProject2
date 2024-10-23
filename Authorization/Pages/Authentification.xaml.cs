using Authorization.Helpers;
using Authorization.Pages.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
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

namespace Authorization.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authentification.xaml
    /// </summary>
    public partial class Authentification : Page
    {
        private string _txbLogin;
        private string _psbPassword;

        public Authentification()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Кнопка входа в приложение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {

            _txbLogin = TxbLogin.Text;
            _psbPassword = PsbPassword.Password;
            // Обращение к БД
            var data = Connecting.conn.User.FirstOrDefault(x => x.Login == _txbLogin && x.Password == _psbPassword);

            if (data != null)
            {
                switch (data.RoleId)
                {
                    case 1:
                        MessageBox.Show($"Здравствуйте {data.Lastname} {data.Firstname} {data.Patronymic}.\nВы вошли как {data.Role.Name}", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        Navigating.nav.Navigate(new PageManager());
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;

                    default:
                        MessageBox.Show("Извините, ваша раоль не определена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;

                    
                }

            }
            else
            {
                MessageBox.Show("Неправильный логин и пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
