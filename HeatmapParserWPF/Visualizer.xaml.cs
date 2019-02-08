using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
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
        string generalDatasPath;

        string dayPath;

        string fullPath;

        string playerType;

        string game;

        string floor;

        public Visualizer()
        {
            InitializeComponent();
        }

        public Visualizer(string path)
        {
            InitializeComponent();

            generalDatasPath = Properties.Settings.Default.Path;

            Creatures.IsEnabled = false;

            playerType = "\\Creature\\";

            dayPath = path;

            ComboBoxItem tempItem;

            foreach(string s in Directory.GetDirectories(dayPath))
            {
                tempItem = new ComboBoxItem();

                tempItem.Content = Path.GetFileName(s);

                gameSelection.Items.Add(tempItem);
            }           
        }

        private void Soldier_Click(object sender, RoutedEventArgs e)
        {
            Soldier.IsEnabled = false;
            Creatures.IsEnabled = true;

            playerType = "\\Soldier\\";

            if (game != null)
            {
                ComboBoxItem tempItem;

                floorSelection.Items.Clear();

                foreach (string s in Directory.GetFiles(dayPath + game + playerType))
                {
                    Console.WriteLine(s);

                    tempItem = new ComboBoxItem();

                    tempItem.Content = Path.GetFileNameWithoutExtension(s);

                    floorSelection.Items.Add(tempItem);
                }

                if(floor != null)
                {
                    fullPath = dayPath + game + playerType + floor + ".bhd";

                    Console.WriteLine(fullPath);

                    GenerateHeatmap();

                    //TO-DO : Generate Heatmap
                }
            }            
        }

        private void Creatures_Click(object sender, RoutedEventArgs e)
        {
            Soldier.IsEnabled = true;
            Creatures.IsEnabled = false;

            playerType = "\\Creature\\";

            if(game != null)
            {
                ComboBoxItem tempItem;

                floorSelection.Items.Clear();

                foreach (string s in Directory.GetFiles(dayPath + game + playerType))
                {
                    tempItem = new ComboBoxItem();

                    tempItem.Content = Path.GetFileNameWithoutExtension(s);

                    floorSelection.Items.Add(tempItem);
                }

                if(floor != null)
                {
                    fullPath = dayPath + game + playerType + floor + ".bhd";

                    Console.WriteLine(fullPath);

                    GenerateHeatmap();
                    
                    //TO-DO : Generate heatmap
                }
            }
        }

        private void GameSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            game = "\\" + ((ComboBoxItem)gameSelection.SelectedItem).Content.ToString();

            if(playerType != null)
            {
                ComboBoxItem tempItem;

                floorSelection.Items.Clear();

                foreach (string s in Directory.GetFiles(dayPath + game + playerType))
                {

                    tempItem = new ComboBoxItem();

                    tempItem.Content = Path.GetFileNameWithoutExtension(s);

                    floorSelection.Items.Add(tempItem);
                }

                if(floor != null)
                {
                    fullPath = dayPath + game + playerType + floor + ".bhd";

                    GenerateHeatmap();
                    
                    //TO-DO : Generate heatmap;
                }
            }
        }

        private void FloorSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (floorSelection.SelectedItem != null)
            {
                floor = ((ComboBoxItem)floorSelection.SelectedItem).Content.ToString();
            }

            if(playerType != null && game != null)
            {
                fullPath = dayPath + game + playerType + floor + ".bhd";

                GenerateHeatmap();

                //TO-DO : Generate heatmap
            }
        }

        private void GenerateHeatmap()
        {
            Heatmap temp = new Heatmap(fullPath, floor);

            temp.Generate();

            Display.Source = Imaging.CreateBitmapSourceFromHBitmap(temp.result.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
