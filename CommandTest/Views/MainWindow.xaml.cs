using System.Windows;

namespace CommandTest.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }

        private void CommandTestOneButton_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new CommandOneWindow();
            window.Show();
        }


    }
}
