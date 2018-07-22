using System.Windows.Media;
using CommandTest.Views;

namespace CommandTest.Classes.ColorChangeDemoClasses
{
    /// <summary>
    /// This is the command "interface" for our color change command demo. All commands derive from this, allowing us to perform
    /// any number of commands that inherit this class.
    /// </summary>
    public abstract class ColorCommand 
    {
        protected readonly ColorChangerDemoWindow Window;
        private Brush BackupColorBrush;
        private Brush GenericBrush;

        protected ColorCommand(ColorChangerDemoWindow window)
        {
            Window = window;

        }

        protected void Backup()
        {
            BackupColorBrush = Window.Background;
        }

        public void Undo()
        {
            Window.Background = BackupColorBrush;
        }

        public abstract bool ExecuteColorChange();

    }
}
