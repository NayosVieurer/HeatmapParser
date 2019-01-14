using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HeatmapParserWPF
{
    /// <summary>
    /// Interaction logic for PathInput.xaml
    /// </summary>
    public partial class InputDialog : Window
    {
        public string answer { get { return inputAnswer.Text; } }

        public InputDialog(string question, string defaultAnswer = "")
        {
            InitializeComponent();
            dialQuestion.Content = question;
            inputAnswer.Text = defaultAnswer;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            inputAnswer.Focus();
        }

        private void DialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
