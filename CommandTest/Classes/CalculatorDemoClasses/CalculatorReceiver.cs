using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTest.Classes.CalculatorDemoClasses
{
    /// <summary>
    /// This is the calculator receiver, or otherwise the actual calculator. It performs the commands that are sent to the invoker.
    /// </summary>
    public class CalculatorReceiver
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
                    case 'C':
                        CurrentValue = operand;
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
}

