using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HeatmapParserWPF
{
    /// <summary>
    /// Interaction logic for PathPicker.xaml
    /// </summary>
    public partial class PathPicker :  System.Windows.Controls.UserControl
    {
        public PathPicker()
        {
            InitializeComponent();
            pathTxtBox.Text = "";
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                pathTxtBox.Text = dialog.SelectedPath;
            }
        }
    }
}
