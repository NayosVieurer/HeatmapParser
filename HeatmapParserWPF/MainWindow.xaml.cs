using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Interop;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

public struct HeatPoint
{
    public int X;
    public int Y;
    public byte intensity;
    public HeatPoint(int iX, int iY, byte intens)
    {
        X = iX;
        Y = iY;
        intensity = intens;
    }
}

namespace HeatmapParserWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<HeatPoint> list;
   

        public MainWindow()
        {
            InitializeComponent();
            
            for(int i = 0; i < 4; i++)
            {
                FolderSelection.Items.Add(i.ToString()); 
            }

            FolderSelection1.Click += SelectFolder;
        }     
        
        public void SelectFolder(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();

           DialogResult result =  dialog.ShowDialog();

            Console.WriteLine(dialog.SelectedPath.ToString());
        }
    
    }
}
