using System.Windows.Media;
using CommandTest.Views;

namespace CommandTest.Classes.ColorChangeDemoClasses 
{
    /// <summary>
    /// This is a concrete command that tells the receiver (in this case the window) to change its color to yellow.
    /// </summary>
    class ChangeToYellowCommand : ColorCommand
    {
        public ChangeToYellowCommand(ColorChangerDemoWindow window) : base(window)
        {
        }

        public override bool ExecuteColorChange()
        {
            if (Window.Background == null)
            {
                return false;
            }

            Backup();

            Window.Background = Brushes.Yellow;
            return true;
        }
    }
}
