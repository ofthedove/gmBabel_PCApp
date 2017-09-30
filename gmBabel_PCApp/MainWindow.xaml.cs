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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gmBabel_PCApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Polly polly = new Polly();
        List<AudioItem> clips = new List<AudioItem>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void speakButton_Click(object sender, RoutedEventArgs e)
        {
            string file = polly.sendText(inputTextBox.Text);
        }
    }

    public class AudioItem
    {
        public string Text { get; set; }
        public string Voice { get; set; }
        public string AudioFile { get; set; }
    }
}
