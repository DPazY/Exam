using System.Windows;
using System.Windows.Controls;

namespace Exam
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        private DbService dbService = new DbService();
        public RegWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = new User
            {
                FirstName = FirstNameTextBox.Text,
                MiddleName = MiddleNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                Login = LoginTextBox.Text,
                Password = PasswordBox.Password,
                Age = AgeTextBox.Text
            };

            try
            {
                dbService.AddUser(user);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            catch (Exception ex)
            {
                ErrorTextBlock.Text = $"Registration failed: {ex.Message}";
            }
        }
    }
}
