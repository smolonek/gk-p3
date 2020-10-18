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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gk_p3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Color rectFill;
        private bool loaded = false;
        public MainWindow()
        {
            InitializeComponent();
            R.Value = 0;
            G.Value = 0;
            B.Value = 0;
            C.Value = 0;
            M.Value = 0;
            Y.Value = 0;
            K.Value = 0;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void R_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //SetCMYK();
        }

        private void G_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //SetCMYK();
        }

        private void B_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //SetCMYK();
        }

        private void C_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //SetRGB();
        }

        private void M_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //SetRGB();
        }

        private void Y_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //SetRGB();
        }

        private void K_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //SetRGB();
        }
        private void SetCMYK()
        {
            double R1 = R.Value / 255;
            double G1 = G.Value / 255;
            double B1 = B.Value / 255;
            double C1, M1, Y1;
            double K1 = 1 - GetMax(new double[] { R1, G1, B1 });
            if (K1 == 1)
            {
                C1 = 0;
                M1 = 0;
                Y1 = 0;
            }
            else
            {
                C1 = (1 - R1 - K1) / (1 - K1);
                M1 = (1 - G1 - K1) / (1 - K1);
                Y1 = (1 - B1 - K1) / (1 - K1);
            }
            if (loaded)
            {
                K.Value = Math.Round(Math.Round(K1, 2) * 100);
                C.Value = Math.Round(Math.Round(C1, 2) * 100);
                M.Value = Math.Round(Math.Round(M1, 2) * 100);
                Y.Value = Math.Round(Math.Round(Y1, 2) * 100);
                rectFill = Color.FromRgb((byte)R.Value, (byte)G.Value, (byte)B.Value);
                rect.Fill = new SolidColorBrush(rectFill);
            }
            
        }
        private void SetRGB()
        {
            double C1 = C.Value / 100;
            double M1 = M.Value / 100;
            double Y1 = Y.Value / 100;
            double K1 = K.Value / 100;
            if (loaded)
            {

                //R.Value = Math.Round((1 - Math.Min(1, C1 * (1 - K1) + K1))) * 255;
                //G.Value = Math.Round((1 - Math.Min(1, M1 * (1 - K1) + K1))) * 255;
                //B.Value = Math.Round((1 - Math.Min(1, Y1 * (1 - K1) + K1))) * 255;

                R.Value = Math.Round((1 - Math.Min(1, C1 * (1 - K1) + K1)) * 255, 2);
                G.Value = Math.Round((1 - Math.Min(1, M1 * (1 - K1) + K1)) * 255, 2);
                B.Value = Math.Round((1 - Math.Min(1, Y1 * (1 - K1) + K1)) * 255, 2);

                rectFill = Color.FromRgb((byte)R.Value, (byte)G.Value, (byte)B.Value);
                rect.Fill = new SolidColorBrush(rectFill);
            }
        }
        private double GetMax(double[] array)
        {
            Array.Sort(array);
            return array[2];
        }

        private void textBoxR_TextChanged(object sender, TextChangedEventArgs e)
        {
            //SetCMYK();
        }

        private void textBoxG_TextChanged(object sender, TextChangedEventArgs e)
        {
            //SetCMYK();
        }

        private void textBoxB_TextChanged(object sender, TextChangedEventArgs e)
        {
            //SetCMYK();
        }

        private void textBoxC_TextChanged(object sender, TextChangedEventArgs e)
        {
            //SetRGB();
        }

        private void textBoxM_TextChanged(object sender, TextChangedEventArgs e)
        {
            //SetRGB();
        }

        private void textBoxY_TextChanged(object sender, TextChangedEventArgs e)
        {
            //SetRGB();
        }

        private void textBoxK_TextChanged(object sender, TextChangedEventArgs e)
        {
            //SetRGB();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loaded = true;
        }

        private void RGBtoCMYK_Click(object sender, RoutedEventArgs e)
        {
            SetCMYK();
        }

        private void CMYKtoRGB_Click(object sender, RoutedEventArgs e)
        {
            SetRGB();
        }
    }
}
