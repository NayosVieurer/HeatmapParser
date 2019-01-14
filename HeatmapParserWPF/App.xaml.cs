using System.Windows;

namespace HeatmapParserWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            HeatmapParserWPF.Properties.Settings.Default.Save();
        }

    }
}
