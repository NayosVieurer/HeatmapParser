#pragma warning disable MissingOptionsRule // Missing Or Corrupted Options
using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
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

        int numberPerRow = 10;

        Visualizer currentVisualizer;
        
        public MainWindow()
        {
            InitializeComponent();

            isMaximised = Properties.Settings.Default.Maximized;

           path = Properties.Settings.Default.Path;

            this.WindowState = isMaximised ? WindowState.Maximized : WindowState.Normal;
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            
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

        private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

            if(mainMenu.IsEnabled)
            {
                e.CanExecute = true;
            }
            //e.CanExecute = true;
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
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

            TextBlock clickedContent = (TextBlock)clicked.Content;

            string fullPath = path + '\\' + clickedContent.Text;

            //foreach (string s in Directory.GetDirectories(fullPath))
            //{
            //    Console.WriteLine(s);
            //}

            currentVisualizer = new Visualizer(fullPath);

            currentVisualizer.Width = ActualWidth;

            currentVisualizer.Height = ActualHeight;

            //mainMenu.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;

            //mainMenu.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;

            //currentVisualizer.Margin = new Thickness(15, 15, 15, 15);

            foreach (UIElement item in mainGrid.Children)
            {
                item.IsEnabled = false;
                item.Visibility = Visibility.Hidden;
            }

            Grid.SetRowSpan(currentVisualizer, mainGrid.RowDefinitions.Count);

            Grid.SetColumnSpan(currentVisualizer, mainGrid.ColumnDefinitions.Count);

            mainGrid.Children.Add(currentVisualizer);
        }

        private void GenerateLayout()
        {
            Button temp;
            TextBlock tempText;

            ColumnDefinition tempColumn;
            RowDefinition tempRow;

            int elementColumn = 0;
            int elementRow = 0;

            foreach (string s in Directory.GetDirectories(path, "Playtests*"))
            {
                temp = new Button();
                tempText = new TextBlock();
                tempText.Text = Path.GetFileName(s);

                temp.Content = tempText;

                if (mainGrid.ColumnDefinitions.Count <= elementColumn)
                {
                    tempColumn = new ColumnDefinition();
                    tempColumn.Width = new GridLength();
                    mainGrid.ColumnDefinitions.Add(tempColumn);
                }

                Grid.SetColumn(temp, elementColumn);

                if (mainGrid.RowDefinitions.Count <= elementRow)
                {
                    tempRow = new RowDefinition();
                    tempRow.Height = new GridLength();
                    mainGrid.RowDefinitions.Add(tempRow);
                }

                Grid.SetRow(temp, elementRow);

                temp.HorizontalAlignment = HorizontalAlignment.Center;
                temp.VerticalAlignment = VerticalAlignment.Center;

                temp.Height = 50;
                temp.Width = 140;

                temp.Margin = new Thickness(15, 15, 15, 15);

                if (elementColumn >= numberPerRow)
                {
                    elementColumn = 0;
                    elementRow++;
                }
                else
                {
                    elementColumn++;
                }
                mainGrid.Children.Add(temp);

                temp.Click += playtest_click;
            }
        }

        private void CloseVisualizer_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(currentVisualizer != null)
            {
                e.CanExecute = true;
            }
        }

        private void CloseVisualizer_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            mainGrid.Children.Remove(currentVisualizer);

            currentVisualizer = null;

            foreach(UIElement item in mainGrid.Children)
            {
                item.IsEnabled = true;
                item.Visibility = Visibility.Visible;
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }
}

#pragma warning restore MissingOptionsRule // Missing Or Corrupted Options