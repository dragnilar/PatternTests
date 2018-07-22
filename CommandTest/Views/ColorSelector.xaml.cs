using System;
using System.Collections.Generic;
using System.Linq;
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
    /// The color selector is a window that is used to allow a user to select a color for the color changer demo.
    /// </summary>
    public partial class ColorSelector : Window
    {
        public Brush SelectedColorBrush;
        public ColorSelector()
        {
            InitializeComponent();
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void ButtonOK_OnClick(object sender, RoutedEventArgs e)
        {
            if (ColorCanvasMain.SelectedColor != null)
            {
                SelectedColorBrush = ConvertColorToBrush(ColorCanvasMain.SelectedColor.Value);
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Please select a color!");
            }
               

        }


        private SolidColorBrush ConvertColorToBrush(Color color)
        {
            return new SolidColorBrush(color);
        }
    }
}
