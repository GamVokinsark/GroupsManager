using System.Windows;

namespace AbitMan
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //CheckUserPrivs();
        }

        private void QueryButton_Click(object sender, RoutedEventArgs e)
        {
            if(!DBUtils.IsAvailable())
            {
                MessageBox.Show("Для данного действия нужно соединение с сервером MySQL!\nВоспользуйтесь \"Подключить к БД\"", "Ошибка");
                return;
            }
            new QueryWindow().Show();
            Close();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            if (!DBUtils.IsAvailable())
            {
                MessageBox.Show("Для данного действия нужно соединение с сервером MySQL!\nВоспользуйтесь \"Подключить к БД\"", "Ошибка");
                return;
            }
            new LogInWindow().Show();
            Close();
        }

        private void RegistryButton_Click(object sender, RoutedEventArgs e)
        {
            if (!DBUtils.IsAvailable())
            {
                MessageBox.Show("Для данного действия нужно соединение с сервером MySQL!\nВоспользуйтесь \"Подключить к БД\"", "Ошибка");
                return;
            }
            new RegistrationWindow().Show();
            Close();
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            new ServerConnect().Show();
            Close();
        }

        private void ManipulateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!DBUtils.IsAvailable())
            {
                MessageBox.Show("Для данного действия нужно соединение с сервером MySQL!\nВоспользуйтесь \"Подключить к БД\"", "Ошибка");
                return;
            }
            new ManipulationsWindow().Show();
            Close();
        }

        private void CheckUserPrivs()
        {
            switch(ProgramData.Privs)
            {
                case 0:
                    MarkLabel.Content = "";
                    UserNameLabel.Content = "Гость";
                    QueryButton.IsEnabled = false;
                    ManipulateButton.IsEnabled = false;
                    break;
                case 1:
                    MarkLabel.Content = "User";
                    UserNameLabel.Content = ProgramData.Login;
                    QueryButton.IsEnabled = true;
                    ManipulateButton.IsEnabled = false;
                    break;
                case 2:
                    MarkLabel.Content = "Admin";
                    UserNameLabel.Content = ProgramData.Login;
                    QueryButton.IsEnabled = true;
                    ManipulateButton.IsEnabled = true;
                    break;
                default:
                    MessageBox.Show("Произошла ошибка привилегий пользователя!", "Ошибка");
                    Close();
                    break;
            }
        }
    }
}
