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
    /// Interaction logic for ColorChangerDemoWindow.xaml
    /// </summary>
    public partial class ColorChangerDemoWindow : Window
    {
        private ColorChangeHistory history = new ColorChangeHistory();

        public ColorChangerDemoWindow()
        {
            InitializeComponent();
        }

        private void ChangeToGreenButton_OnClick(object sender, RoutedEventArgs e)
        {
            ExecuteCommand(new ChangeToGreenCommand(this));
        }

        private void ChangeToYellowButton_OnClick(object sender, RoutedEventArgs e)
        {
            ExecuteCommand(new ChangeToYellowCommand(this));
        }

        private void ChangeToRedButton_OnClick(object sender, RoutedEventArgs e)
        {
            ExecuteCommand(new ChangeToRedCommand(this));
        }

        private void ChangeToBlackButton_OnClick(object sender, RoutedEventArgs e)
        {
            ExecuteCommand(new ChangeToBlackCommand(this));
        }

        private void ChangeToCustomColorButton_OnClick(object sender, RoutedEventArgs e)
        {
            SelectAndProcessGenericColor();
        }



        private void UndoButton_OnClick(object sender, RoutedEventArgs e)
        {
            Undo();
        }

        private void ExecuteCommand(ColorCommand command)
        {
            if (command.ExecuteColorChange())
            {
                history.PushColorCommand(command);
            }
        }

        private void Undo()
        {
            if (history.IsEmpty())
            {
                return;
            }

            ColorCommand command = history.PopColorCommand();

            command?.Undo();
        }

        private void SelectAndProcessGenericColor()
        {
            var colorSelectorDialog = new ColorSelector { WindowStartupLocation = WindowStartupLocation.CenterScreen };
            var result = colorSelectorDialog.ShowDialog();
            if (result == true)
            {
                ExecuteCommand(new ChangeToGenericColorCommand(this, colorSelectorDialog.SelectedColorBrush));
            }
        }


    }
}
