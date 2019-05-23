using System;
using System.Windows;

namespace AbitMan
{
    /// <summary>
    /// Логика взаимодействия для ServerConnect.xaml
    /// </summary>
    public partial class ServerConnect : Window
    {
        public ServerConnect()
        {
            InitializeComponent();
            SetFieldValues();
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            DBUtils.SetConnection(HostTB.Text, PortTB.Text,
                SchemaTB.Text, UserTB.Text, PasswordTB.Password);

            MarkerLabel.Content = DBUtils.IsAvailable() ? "Подключено." : "Ошибка!";
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            new MainWindow().Show();
        }

        private void SetFieldValues()
        {
            HostTB.Text = ProgramData.Host;
            PortTB.Text = ProgramData.Port;
            UserTB.Text = ProgramData.User;
            PasswordTB.Password = ProgramData.Pswd;
            SchemaTB.Text = ProgramData.Schema;
        }
    }
}
