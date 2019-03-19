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

            if (!Directory.Exists(path))         
            {
                Console.WriteLine("directory not found");

                PathInput dialog;

                do
                {
                    dialog = new PathInput("The heatmap folder was not found. Please enter a valid path : ");

                    if (dialog.ShowDialog() == true)
                    {
                       path = dialog.answer;
                    }
                } while (!Directory.Exists(path));
            }
            GenerateLayout();
        }

        private void playtest_click(object sender, RoutedEventArgs e)
        {
            Button clicked = (Button)sender;

            Console.WriteLine(clicked.Name.GetType());

            //TextBlock clickedContent = (TextBlock)clicked.Content;        

            foreach(Button b in elementList.Children)
            {
                if(!b.IsEnabled && b != clicked)
                {
                    b.IsEnabled = true;
                }
            }

            clicked.IsEnabled = false;

            test.Init(path, clicked.Tag.ToString());

            Expand.IsExpanded = false;

        }

        private void GenerateLayout()
        {
            Button temp;
            TextBlock tempText;

            string directoryName;

            double timestamp;

            DateTime date;

            foreach (string s in Directory.GetDirectories(path))
            {
                directoryName = Path.GetFileName(s);

                if(directoryName == "GeneralsDatas")
                {
                    continue;
                }

                Console.WriteLine(directoryName);

                temp = new Button();
                tempText = new TextBlock();

                tempText.Text = Path.GetFileName(s);

                if (directoryName.Contains("Playtest"))
                {
                    //temp.Content = tempText;

                    date = File.GetCreationTime(directoryName);

                    temp.Content = date.DayOfWeek.ToString() + ", " + date.ToString("M", new CultureInfo("en-us"));
  
                }

                else
                {
                    timestamp = double.Parse(directoryName);

                    date = ExtensionMethods.UnixTimeStampToDateTime(timestamp);              

                    temp.Content = date.DayOfWeek.ToString() + ", " + date.ToString("M", new CultureInfo("en-us"));
                    temp.Tag = directoryName;
                }

                temp.HorizontalAlignment = HorizontalAlignment.Center;
                temp.VerticalAlignment = VerticalAlignment.Center;

                temp.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                temp.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                temp.Margin = new Thickness(0, 3, 0, 3);

                temp.Height = 50;
                temp.Width = 140;

                elementList.Children.Add(temp);

                temp.Click += playtest_click;
            }
        }

        private void Test_Expanded(object sender, RoutedEventArgs e)
        {
            Grid.SetColumnSpan(test, 1);
            Grid.SetColumn(test, 1);
        }

        private void Test_Collapsed(object sender, RoutedEventArgs e)
        {
            Grid.SetColumnSpan(test, 2);
            Grid.SetColumn(test, 0);
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }
    }
}

#pragma warning restore MissingOptionsRule // Missing Or Corrupted Options