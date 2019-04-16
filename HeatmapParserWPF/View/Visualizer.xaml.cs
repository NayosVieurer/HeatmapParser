using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Interop;
using System.Windows.Navigation;

namespace HeatmapParserWPF
{
    /// <summary>
    /// Interaction logic for Visualizer.xaml
    /// </summary>
    public partial class Visualizer : UserControl
    {
        public Visualizer()
        {
            InitializeComponent();
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {

        }



        private void ComboBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}