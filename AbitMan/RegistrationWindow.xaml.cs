using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace AbitMan
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            if (ProgramData.Privs == 2)
                IsAdminChB.IsEnabled = true;
            else
                IsAdminChB.IsEnabled = false;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder hashString = new StringBuilder();
            byte[] hash = new SHA512Managed().ComputeHash(Encoding.UTF8.GetBytes(PasswordText.Password));
            foreach (byte x in hash)
                hashString.Append(string.Format("{0:x2}", x));
            string result;
            if (ProgramData.Privs == 2)
                result = DBUtils.AddUser(LoginText.Text, hashString.ToString(), IsAdminChB.IsChecked.Value ? "True" : "False");
            else
                result = DBUtils.AddUser(LoginText.Text, hashString.ToString(), "False");
            if (result == "Успешно добавлено нового пользователя.")
            {
                MessageBox.Show(result, "Успех");
                Close();
            }
            else
                MessageBox.Show(result, "Неудача");
            LoginText.Text = "";
            PasswordText.Password = "";
        }

        private void RegistrationWindow1_Closed(object sender, EventArgs e)
        {
            new MainWindow().Show();
        }
    }
}
