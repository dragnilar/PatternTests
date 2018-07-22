using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using CommandTest.Classes.ColorChangeDemoClasses;
using CommandTest.Views;

namespace CommandTest.Classes
{
    /// <summary>
    /// This is a concrete command that tells the receiver (in this case the window) to change its color to green.
    /// </summary>
    public sealed class ChangeToGreenCommand : ColorCommand
    {
        public ChangeToGreenCommand(ColorChangerDemoWindow window) : base(window)
        {
        }

        public override bool ExecuteColorChange()
        {
            if (Window.Background == null)
            {
                return false;
            }

            Backup();

            Window.Background = Brushes.Green;
            return true;
        }
    }
}
