#pragma warning disable MissingOptionsRule // Missing Or Corrupted Options
using System.Windows;
using System.ComponentModel;
using System;

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
        bool isMaximised;

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
    }
}

#pragma warning restore MissingOptionsRule // Missing Or Corrupted Options