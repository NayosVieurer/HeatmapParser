#pragma warning disable MissingOptionsRule // Missing Or Corrupted Options
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using System.IO;
using System;


namespace HeatmapParserWPF
{

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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isMaximised;

        string path = "X:\\J002\\01_PERSO\\BLACK_HIVE\\Playtest_Datas\\Heatmaps";

        public MainWindow()
        {
            InitializeComponent();

                

            isMaximised = Properties.Settings.Default.Maximized;
            this.WindowState = isMaximised ? WindowState.Maximized : WindowState.Normal;

            

        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Properties.Settings.Default.Maximized = isMaximised;

            Properties.Settings.Default.Save();
        }

        private void Window_StateChanged(object sender, System.EventArgs e)
        {
            if(this.WindowState != WindowState.Minimized)
            {
                isMaximised = !isMaximised;
            }
        }

        private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            Console.WriteLine("toto");

            if (!Directory.Exists(path))         
            {
                InputDialog dialog;

                do
                {
                    dialog = new InputDialog("The heatmap folder was not found. Please enter a valid path : ");

                    if (dialog.ShowDialog() == true)
                    {
                        path = dialog.answer;
                    }
                } while (!Directory.Exists(path));
            }
        }
    }


    public static class CustomCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand
        (
            "Exit",
            "Exit",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.F4, ModifierKeys.Alt)
            }
        );
    }
}

#pragma warning restore MissingOptionsRule // Missing Or Corrupted Options