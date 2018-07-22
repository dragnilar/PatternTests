using System.Collections.Generic;

namespace CommandTest.Classes.ColorChangeDemoClasses
{
    /// <summary>
    /// This is the list that keeps track of our commands, which allows us to transition back to a previous command if desired.
    /// In this case we are using a stack since we are merely performing push/pop functionality. 
    /// </summary>
    public class ColorChangeHistory
    {
        private readonly Stack<ColorCommand> _history = new Stack<ColorCommand>();

        public void PushColorCommand(ColorCommand command)
        {
            _history.Push(command);
        }

        public ColorCommand PopColorCommand()
        {
            return _history.Pop();
        }

        public bool IsEmpty()
        {
            return _history.Count == 0;
        }
    }
}
