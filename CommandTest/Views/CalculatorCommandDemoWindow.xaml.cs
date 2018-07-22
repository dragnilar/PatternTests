using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using CommandTest.Classes.CalculatorDemoClasses;

namespace CommandTest.Views
{
    /// <summary>
    /// This is a simple demonstration of using the command pattern using WPF.
    /// To learn more about the command pattern, review the following link or search around the web.
    /// Further reading: https://refactoring.guru/design-patterns/command/
    /// This is based off of the example you can find here: https://www.dofactory.com/net/command-design-pattern
    /// Note: For this example, the Window is obviously the "Client" in the Command pattern.
    /// </summary>
    public partial class CalculatorCommandDemoWindow : Window
    {
        private CalculatorInvoker _calculatorInvoker = new CalculatorInvoker();

        public object CalculatorOutPut
        {
            get => GetValue(_calculatorOutPut);
            set => SetValue(_calculatorOutPut, value);
        } 
        public static readonly DependencyProperty _calculatorOutPut = DependencyProperty.Register("CalculatorOutPut", typeof(object),
            typeof(CalculatorCommandDemoWindow), new FrameworkPropertyMetadata(false));

        

        public CalculatorCommandDemoWindow()
        {
            InitializeComponent();
            CalculatorOutPut = "CalculatorReceiver Output";
        }


        private void SubtractButton_OnClick(object sender, RoutedEventArgs e)
        {
            PerformOperation('-');
        }

        private void DivideButton_OnClick(object sender, RoutedEventArgs e)
        {
            PerformOperation('/');
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            PerformOperation('+');
        }

        private void MultiplyButton_OnClick(object sender, RoutedEventArgs e)
        {
            PerformOperation('*');
        }

        private void UndoButton_OnClick(object sender, RoutedEventArgs e)
        {
            CalculatorOutPut = _calculatorInvoker.Undo(1);
        }

        private void RedoButton_OnClick(object sender, RoutedEventArgs e)
        {
            CalculatorOutPut = _calculatorInvoker.Redo();
        }

        private void ClearButton_OnClick(object sender, RoutedEventArgs e)
        {
            CalculatorOutPut = _calculatorInvoker.Clear();
        }

        private void PerformOperation(char @operator)
        {
            var inputResult = GetInput();
            if (inputResult.isValid)
            {
                var computeResult = _calculatorInvoker.Compute(@operator, inputResult.result);
                CalculatorOutPut = computeResult;
            }
        }

        private (bool isValid, int result) GetInput()
        {
            if (string.IsNullOrEmpty(TextBoxAmountToUse.Text))
            {
                MessageBox.Show("Enter a value.");
                return (false, 0);
            }

            try
            {
                var input = Convert.ToInt32(TextBoxAmountToUse.Text);
                return (true, input);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input, please use numbers only.");
                return (false, 0);
            }
        }







    }
}
