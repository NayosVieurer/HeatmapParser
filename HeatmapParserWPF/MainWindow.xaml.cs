#pragma warning disable MissingOptionsRule // Missing Or Corrupted Options
using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls.Primitives;
using System.Globalization;
using System.ComponentModel;
using System.IO;
using System;


namespace HeatmapParserWPF
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isMaximised;

        string path = "";
        
        public MainWindow()
        {
            InitializeComponent();

            isMaximised = Properties.Settings.Default.Maximized;

           path = Properties.Settings.Default.Path;

            this.WindowState = isMaximised ? WindowState.Maximized : WindowState.Normal;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Properties.Settings.Default.Maximized = isMaximised;

            Properties.Settings.Default.Path = path;

            Properties.Settings.Default.Save();

            Application.Current.Shutdown();
        }

        private void Window_StateChanged(object sender, System.EventArgs e)
        {
            if(this.WindowState != WindowState.Minimized)
            {
                isMaximised = !isMaximised;
            }  

        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            MainWindowViewModel mainViewModel = new MainWindowViewModel();

            DataContext = mainViewModel;
            Visualizer.DataContext = mainViewModel;

        }

        private void Test_Expanded(object sender, RoutedEventArgs e)
        {
            Grid.SetColumn(Visualizer, 1);
            Grid.SetColumnSpan(Visualizer, 1);
        }

        private void Test_Collapsed(object sender, RoutedEventArgs e)
        {
            Grid.SetColumn(Visualizer, 0);
            Grid.SetColumnSpan(Visualizer, 2);
        }
    }
}

#pragma warning restore MissingOptionsRule // Missing Or Corrupted Options