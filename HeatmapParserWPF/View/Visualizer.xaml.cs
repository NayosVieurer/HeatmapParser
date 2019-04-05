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
        Heatmap currentMap;

        //SoldierTrace currentTrace;

        public string dayPath { get; set; }

        public string datasPath { get; set; }

        Vector worldRef;

        float worldSize;

        Dictionary<string, string> nameTransposition = new Dictionary<string, string>();

        MapType mapType;

        bool init;

        List<Heatmap> maps;

        List<Trace> traces;

        string game;

        string floor;

        public Visualizer()
        {
            InitializeComponent();
        }

        private void GameSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(gameSelection.SelectedItem == null)
            {
                return;
            }

            game = ((ComboBoxItem)gameSelection.SelectedItem).Content.ToString();

            traceDepthSlider.Value = 0;

            if(mapType == MapType.Steps)
            {
                traceDepthSlider.Focus();
            }

            if (floor != null || mapType == MapType.Steps)
            {
                UpdateDisplay();
            }
        }

        private void FloorSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (floorSelection.SelectedItem == null)
            {
                return;
            }

            string verificationBuffer;

            foreach(string key in nameTransposition.Keys)
            {
                nameTransposition.TryGetValue(key, out verificationBuffer);

                if (verificationBuffer == ((ComboBoxItem)floorSelection.SelectedItem).Content.ToString())
                {
                    floor = key;
                    break;
                }
            }

            if (game != null)
            {
                UpdateDisplay();
            }
        }

        private void UpdateDisplay()
        {
            if(mapType == MapType.Steps)
            {
                ShowTrace();
            }
            else
            {

                ShowHeatmap();
            }
        }

        private void ShowHeatmap()
        {

            currentMap = maps.Find(x => x.game == game && x.floor == floor && x.playerType == mapType);

            if (currentMap == null)
            {
                currentMap = new Heatmap(floor, game, mapType);

                byte[] buffer;

                if (game != "Global")
                {
                    if(!File.Exists(dayPath + '\\' + game + '\\' + mapType.ToString() + '\\' + floor + ".bhd"))
                    {
                        MessageBox.Show("The file does not exist", "Not found", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    buffer = File.ReadAllBytes(dayPath + '\\' + game + '\\' + mapType.ToString() + '\\' + floor + ".bhd");

                    currentMap.heatPoints.AddRange(buffer.ConvertBytesToImagePoints(worldRef, worldSize, currentMap.referenceImage.Size));
                }
                else
                {
                    foreach (string s in Directory.GetDirectories(dayPath))
                    {
                        if (!File.Exists(s + '\\' + mapType.ToString() + '\\' + floor + ".bhd"))
                        {
                            MessageBox.Show("The file does not exist", "Not found", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        buffer = File.ReadAllBytes(s + '\\' + mapType.ToString() + '\\' + floor + ".bhd");

                        currentMap.heatPoints.AddRange(buffer.ConvertBytesToImagePoints(worldRef, worldSize, currentMap.referenceImage.Size));
                    }
                }
                currentMap.GenerateHeatmap();
                maps.Add(currentMap);
            }

            amount.Text = currentMap.heatPoints.Count.ToString();

            Display.Source = Imaging.CreateBitmapSourceFromHBitmap(currentMap.referenceImage.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            Mask.Source = Imaging.CreateBitmapSourceFromHBitmap(currentMap.mask.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void ShowTrace()
        {
            //currentTrace = traces.Find(x => x.game == game);

            //if(currentTrace == null)
            //{
            //    if(!File.Exists(dayPath + "\\" + game + "\\" + MapType.Soldier.ToString() + "\\soldier.bhd"))
            //    {
            //        MessageBox.Show("The file does not exist", "Not found", MessageBoxButton.OK, MessageBoxImage.Error);
            //        return;
            //    }
            //    byte[] buffer = File.ReadAllBytes(dayPath + "\\" + game + "\\" + MapType.Soldier.ToString() + "\\soldier.bhd");

            //    Vector[] temp = buffer.ConvertBytesToVectors();

            //    currentTrace = new SoldierTrace(game);

            //    string tempString = "";

            //    Bitmap tempImage;

            //    foreach(Vector v in temp)
            //    {
            //        switch(v.Z)
            //        {
            //            case float val when val == 0 || (val >= -380 && val < -75) :
            //                tempString = "FirstFloor";
            //                break;

            //            case float val when val == 1 || (val >= -75 && val < 515):
            //                tempString = "SecondFloor";
            //                break;

            //            case float val when val == 2 || (val >= -515 && val < 1075):
            //                tempString = "ThirdFloor";
            //                break;

            //            case float val when val == 3 || val >= 1075:
            //                tempString = "FourthFloor";
            //                break;
            //        }
            //        currentTrace.masks.TryGetValue(tempString, out tempImage);
            //        ImagePoint tempIp = v.ConvertVectorToImagePoint(worldRef, worldSize, tempImage.Size);
            //        TracePoint test = new TracePoint(tempIp, tempString);

            //        currentTrace.tracePoints.Add(test);
            //    }

            //    traces.Add(currentTrace);
            //}

            //currentTrace.Reset();

            //Display.Source = Imaging.CreateBitmapSourceFromHBitmap(currentTrace.currentImage.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            //Mask.Source = Imaging.CreateBitmapSourceFromHBitmap(currentTrace.currentMask.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            //traceDepthSlider.Maximum = currentTrace.tracePoints.Count - 1;
        }

        private void TraceDepthSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //if(currentTrace == null)
            //{
            //    return;
            //}

            //if(e.NewValue == 0)
            //{
            //    currentTrace.Reset();
            //    return;
            //}

            
            //currentTrace.Reset();

            //currentTrace.UpdateTrace((int)e.NewValue);

            //Display.Source = Imaging.CreateBitmapSourceFromHBitmap(currentTrace.currentImage.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            //Mask.Source = Imaging.CreateBitmapSourceFromHBitmap(currentTrace.currentMask.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

        }

        private void TraceControls_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(mapType == MapType.Steps && StepsControls.IsEnabled)
            {

                e.CanExecute = true;
            }
        }

        private void Increase_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Console.WriteLine("toto");
            traceDepthSlider.Value++;
        }

        private void Decrease_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            traceDepthSlider.Value--;
        }
    }
}