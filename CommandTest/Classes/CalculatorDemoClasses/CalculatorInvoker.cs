using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandTest.Views;

namespace CommandTest.Classes.CalculatorDemoClasses
{
    /// <summary>
    /// This is the "Invoker" class for the calculator, it asks the receiver (the Calculator) to do its stuff.
    /// </summary>
    class CalculatorInvoker
    {
        private CalculatorReceiver _calculator = new CalculatorReceiver();
        private List<CalculatorCommand> _commands = new List<CalculatorCommand>();
        private int CurrentValue;

        public string Redo()
        {
            var index = CurrentValue - 1;
            var command = _commands[index];
            var returnValue = command.Execute();
            CurrentValue++;
            _commands.Add(command);
            return returnValue;
        }

        public string Undo(int levels)
        {
            for (int i = 0; i < levels; i++)
            {
                if (CurrentValue > 0)
                {
                    var command = _commands[--CurrentValue] as CalculatorCommand;
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

        public string Clear()
        {
            var command = new CalculatorCommand(_calculator, 'C', 0);
            var executionResult = command.Clear();
            _commands.Clear();
            CurrentValue = 0;
            return executionResult;
        }
    }
}
