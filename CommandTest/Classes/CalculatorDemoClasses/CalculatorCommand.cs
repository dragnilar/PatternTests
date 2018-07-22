using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTest.Classes.CalculatorDemoClasses
{
    /// <summary>
    /// This is the concrete representation of the calculator abstract command. These are sent from the invoker to the receiver.
    /// </summary>
    public class CalculatorCommand : CalculatorCommandAbstract
    {
        private char _operator;
        private int _operand;
        private CalculatorReceiver _calculatorReceiver;

        public CalculatorCommand(CalculatorReceiver calculatorReceiver, char @operator, int operand)
        {
            _calculatorReceiver = calculatorReceiver;
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
            return _calculatorReceiver.Operation(_operator, _operand);
        }

        public override string UnExecute()
        {
            return _calculatorReceiver.Operation(UndoMessage(_operator), _operand);
        }

        public override string Clear()
        {
            return _calculatorReceiver.Operation(_operator, _operand);
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
}
