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

namespace CommandTest.Views
{
    /// <summary>
    /// This is a simple demonstration of using the command pattern using WPF.
    /// To learn more about the command pattern, review the following link or search around the web.
    /// Further reading: https://refactoring.guru/design-patterns/command/
    /// This is based off of the example you can find here: https://www.dofactory.com/net/command-design-pattern
    /// </summary>
    public partial class CalculatorCommandDemoWindow : Window
    {
        private CalculatorUser currentCalculatorUser = new CalculatorUser();

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
            CalculatorOutPut = "Calculator Output";
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
            CalculatorOutPut = currentCalculatorUser.Undo(1);
        }

        private void PerformOperation(char @operator)
        {
            var inputResult = GetInput();
            if (inputResult.isValid)
            {
                var computeResult = currentCalculatorUser.Compute(@operator, inputResult.result);
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

        private abstract class Command
        {
            public abstract string Execute();
            public abstract string UnExecute();
        }

        private class CalculatorCommand : Command
        {
            private char _operator;
            private int _operand;
            private Calculator _calculator;

            public CalculatorCommand(Calculator calculator, char @operator, int operand)
            {
                _calculator = calculator;
                _operator = @operator;
                _operand = operand;
            }

            public char Operator
            {
                set => _operator = value;
            }

            public int Operand
            {
                set => _operand = value;
            }

            public override string Execute()
            {
                return _calculator.Operation(_operator, _operand);
            }

            public override string UnExecute()
            {
                return _calculator.Operation(UndoMessage(_operator), _operand);
            }

            private char UndoMessage(char @operator)
            {
                switch (@operator)
                {
                    case '+':
                        return '-';
                    case '-':
                        return '+';
                    case '*':
                        return '/';
                    case '/':
                        return '*';
                    default:
                        throw new ArgumentException("@operator");
                }
            }
        }

        private class Calculator
        {
            private int CurrentValue = 0;

            public string Operation(char @operator, int operand)
            {
                try
                {
                    switch (@operator)
                    {
                        case '+':
                            CurrentValue += operand;
                            break;
                        case '-':
                            CurrentValue -= operand;
                            break;
                        case '*':
                            CurrentValue *= operand;
                            break;
                        case '/':
                            CurrentValue /= operand;
                            break;
                        default:
                            throw new ArgumentException("Invalid operand");

                    }

                    return $"Current Value = {CurrentValue}, following: {@operator} with operand: {operand}";
                }
                catch (Exception e)
                {
                    return $"Error: {e.Message}";
                }

            }
        }


        private class CalculatorUser
        {
            private Calculator _calculator = new Calculator();
            private List<Command> _commands = new List<Command>();
            private int CurrentValue;

            public string Redo(int levels)
            {
                for (int i = 0; i < levels; i++)
                {
                    if (CurrentValue < _commands.Count -1)
                    {
                        var command = _commands[CurrentValue++];
                        return command.Execute();
                    }
                }

                return string.Empty;
            }

            public string Undo(int levels)
            {
                for (int i = 0; i < levels; i++)
                {
                    if (CurrentValue > 0)
                    {
                        var command = _commands[--CurrentValue] as Command;
                        return command.UnExecute();
                    }
                }

                return string.Empty;
            }

            public string Compute(char @operator, int operand)
            {
                var command = new CalculatorCommand(_calculator, @operator, operand);
                var executionResult = command.Execute();
                _commands.Add(command);
                CurrentValue++;
                return executionResult;
            }
        }


    }
}
