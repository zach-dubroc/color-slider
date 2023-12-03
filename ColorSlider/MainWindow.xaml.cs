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

namespace ColorSlider {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {

            byte red = (byte)sldRed.Value;
            
            byte green = (byte)sldGreen.Value;
           
            byte blue = (byte)sldBlue.Value;
           
            byte alpha = (byte)sldAlpha.Value;

            if (txtRed != null) {
                txtRed.Text = red.ToString(); 
            }
            if (txtGreen != null) {
                txtGreen.Text = green.ToString(); 
            }
            if (txtBlue != null) {
                txtBlue.Text = blue.ToString(); 
            }
            if (txtAlpha != null) {
                txtAlpha.Text = alpha.ToString(); 
            }

            UpdateRectangle(red, green, blue, alpha);
            UpdateLabels();

        }//end event
        private void TextChanged(object sender, TextChangedEventArgs e) {

            byte red = 0;
            byte green = 0;
            byte blue = 0;
            byte alpha = 0;

            if (txtRed != null) {
                byte.TryParse(txtRed.Text, out red);
                sldRed.Value = red; 
            }

            if (txtGreen != null) {
                byte.TryParse(txtGreen.Text, out green);
                sldGreen.Value = green; 
            }

            if (txtBlue != null) {
                byte.TryParse(txtBlue.Text, out blue);
                sldBlue.Value = blue; 
            }

            if (txtAlpha != null) {
                byte.TryParse(txtAlpha.Text, out alpha);
                sldAlpha.Value = alpha; 
            } 

        }//end function

        private void UpdateRectangle(byte red, byte green, byte blue, byte alpha) {

            Color brushColor = Color.FromArgb(alpha, red, green, blue);
            SolidColorBrush brush = new SolidColorBrush(brushColor);
            
            rctColor.Fill = brush;

        }//end function

        private void UpdateLabels() {
            SolidColorBrush tempBrush = (SolidColorBrush)rctColor.Fill;
            Color brushColor = tempBrush.Color;

            byte red = brushColor.R;
            byte green = brushColor.G;
            byte blue = brushColor.B;
            byte alpha = brushColor.A;

            string binaryString = $"{Convert.ToString(alpha, 2).PadLeft(8,'0')} {Convert.ToString(red, 2).PadLeft(8, '0')} {Convert.ToString(green, 2).PadLeft(8, '0')} {Convert.ToString(blue, 2).PadLeft(8, '0')}";
            if (lblBinary.Content != null) {
                lblBinary.Content = binaryString; 
            }//end if

            byte[] value = {blue, green , red, alpha };     
            uint intValue = BitConverter.ToUInt32(value, 0);
            if(lblInt.Content != null) {
                lblInt.Content = intValue;
            }//end if

            string hexString = Convert.ToString(intValue, 16).PadLeft(8, '0');
            if(lblHex.Content != null) {
                lblHex.Content = hexString;
            }//end if
        }//end function
    }
}
