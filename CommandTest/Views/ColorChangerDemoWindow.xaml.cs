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
using CommandTest.Classes;
using CommandTest.Classes.ColorChangeDemoClasses;
using Xceed.Wpf.Toolkit;
using WindowStartupLocation = System.Windows.WindowStartupLocation;

namespace CommandTest.Views
{
    /// <summary>
    /// This is another example of using the command pattern using WPF. Instead of being a calculator, we are changing the window.
    /// The window in this example is again, the client.
    /// </summary>
    public partial class ColorChangerDemoWindow : Window
    {
        private ColorChangeInvoker _colorChangeInvoker = new ColorChangeInvoker();

        public ColorChangerDemoWindow()
        {
            InitializeComponent();
        }

        private void ChangeToGreenButton_OnClick(object sender, RoutedEventArgs e)
        {
            _colorChangeInvoker.SetCommand(new ChangeToGreenCommand(this));
            _colorChangeInvoker.ExecuteCommand();
        }

        private void ChangeToYellowButton_OnClick(object sender, RoutedEventArgs e)
        {
            _colorChangeInvoker.SetCommand(new ChangeToYellowCommand(this));
            _colorChangeInvoker.ExecuteCommand();
        }

        private void ChangeToRedButton_OnClick(object sender, RoutedEventArgs e)
        {
            _colorChangeInvoker.SetCommand(new ChangeToRedCommand(this));
            _colorChangeInvoker.ExecuteCommand();
        }

        private void ChangeToBlackButton_OnClick(object sender, RoutedEventArgs e)
        {
            _colorChangeInvoker.SetCommand(new ChangeToBlackCommand(this));
            _colorChangeInvoker.ExecuteCommand();

        }

        private void ChangeToCustomColorButton_OnClick(object sender, RoutedEventArgs e)
        {
            SelectAndProcessGenericColor();
        }



        private void UndoButton_OnClick(object sender, RoutedEventArgs e)
        {
            Undo();
        }

        private void Undo()
        {
            _colorChangeInvoker.Undo();
        }

        private void SelectAndProcessGenericColor()
        {
            var colorSelectorDialog = new ColorSelector { WindowStartupLocation = WindowStartupLocation.CenterScreen };
            var result = colorSelectorDialog.ShowDialog();
            if (result == true)
            {
                _colorChangeInvoker.SetCommand(new ChangeToGenericColorCommand(this, colorSelectorDialog.SelectedColorBrush));
                _colorChangeInvoker.ExecuteCommand();
            }
        }


    }
}
