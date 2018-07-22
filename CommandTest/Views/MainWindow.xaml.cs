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

        private void CalculatorCommandDemoButton_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new CalculatorCommandDemoWindow();
            window.Show();
        }


        private void ColorCommandDemoButton_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new ColorChangerDemoWindow();
            window.Show();
        }
    }
}
