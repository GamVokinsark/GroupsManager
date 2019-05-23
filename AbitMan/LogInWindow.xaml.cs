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
using System.Windows.Shapes;
using System.Security.Cryptography;

namespace AbitMan
{
    /// <summary>
    /// Логика взаимодействия для LoginWindowxaml.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        public LogInWindow()
        {
            InitializeComponent();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder hashString = new StringBuilder();
            byte[] hash = new SHA512Managed().ComputeHash(Encoding.UTF8.GetBytes(LoginText.Text));
            foreach (byte x in hash)
                hashString.Append(string.Format("{0:x2}", x));
            int priv = DBUtils.CheckUserExist(LoginText.Text, hashString.ToString());
            switch (priv)
            {
                case 0:
                    ProgramData.Login = "Гость";
                    ProgramData.Privs = 0;
                    MessageBox.Show("Неправильно введено логин и\\или пароль. \nПопробуйте еще раз.", "Ошибка");
                    LoginText.Text = "";
                    PasswordText.Password = "";
                    break;
                case 1: case 2:
                    ProgramData.Login = LoginText.Text;
                    ProgramData.Privs = priv;
                    Close();
                    break;
                default:
                    MessageBox.Show("Произошла ошибка привилегий пользователя!", "Ошибка");
                    break;
            }
        }

        private void LogInWind_Closed(object sender, EventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
