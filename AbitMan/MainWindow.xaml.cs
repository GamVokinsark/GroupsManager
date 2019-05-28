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
            CheckUserPrivs();
            CheckDbAvailable();
        }

        public void Appear()
        {
            CheckUserPrivs();
            CheckDbAvailable();
            Show();
        }

        private void QueryButton_Click(object sender, RoutedEventArgs e)
        {
            if(!DBUtils.IsAvailable())
            {
                MessageBox.Show("Для данного действия нужно соединение с сервером MySQL!\nВоспользуйтесь \"Подключить к БД\"", "Ошибка");
                return;
            }
            new QueryWindow(this).Show();
            Hide();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            if (!DBUtils.IsAvailable())
            {
                MessageBox.Show("Для данного действия нужно соединение с сервером MySQL!\nВоспользуйтесь \"Подключить к БД\"", "Ошибка");
                return;
            }
            new LogInWindow(this).Show();
            Hide();
        }

        private void RegistryButton_Click(object sender, RoutedEventArgs e)
        {
            if (!DBUtils.IsAvailable())
            {
                MessageBox.Show("Для данного действия нужно соединение с сервером MySQL!\nВоспользуйтесь \"Подключить к БД\"", "Ошибка");
                return;
            }
            new RegistrationWindow(this).Show();
            Hide();
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            new ServerConnect(this).Show();
            Hide();
        }

        private void ManipulateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!DBUtils.IsAvailable())
            {
                MessageBox.Show("Для данного действия нужно соединение с сервером MySQL!\nВоспользуйтесь \"Подключить к БД\"", "Ошибка");
                return;
            }
            new ManipulationsWindow(this).Show();
            Hide();
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

        private void CheckDbAvailable()
        {
            if(!DBUtils.IsAvailable())
            {
                LogInButton.IsEnabled = false;
                RegistryButton.IsEnabled = false;
                QueryButton.IsEnabled = false;
                ManipulateButton.IsEnabled = false;
            }
            else
            {
                LogInButton.IsEnabled = true;
                RegistryButton.IsEnabled = true;
            }
        }
    }
}
