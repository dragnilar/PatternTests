using System.Windows.Media;
using CommandTest.Views;

namespace CommandTest.Classes.ColorChangeDemoClasses
{
    /// <summary>
    /// This is a concrete command that tells the receiver (in this case the window) to change its color to a specific color.
    /// </summary>
    public sealed class ChangeToGenericColorCommand : ColorCommand
    {
        private readonly Brush _currentBrush;

        public ChangeToGenericColorCommand(ColorChangerDemoWindow window, Brush brush) : base(window)
        {
            _currentBrush = brush;
        }

        public override bool ExecuteColorChange()
        {
            if (Window.Background == null)
            {
                return false;
            }

            Backup();

            Window.Background = _currentBrush;
            return true;
        }
    }
}
