using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTest.Classes.ColorChangeDemoClasses
{
    /// <summary>
    /// This is the invoker for the color change demo. It tells the command to execute.
    /// This thing also holds a history object which is used to facilitate the undo commands.
    /// </summary>
    public class ColorChangeInvoker
    {
        private ColorCommand _command;
        private readonly ColorChangeHistory _history = new ColorChangeHistory();

        public void SetCommand(ColorCommand command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            if (_command.ExecuteColorChange())
            {
                _history.PushColorCommand(_command);
            }
        }

        public void Undo()
        {
            if (_history.IsEmpty())
            {
                return;
            }

            var command = _history.PopColorCommand();

            command?.Undo();
        }
    }
}
