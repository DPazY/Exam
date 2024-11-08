using System.Windows;

namespace Exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext =new MainViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegWindow reg = new RegWindow();
            reg.Show();
            Close();
        }
    }
}