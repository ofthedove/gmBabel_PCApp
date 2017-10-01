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
        Polly polly;
        List<AudioItem> clips;
        List<Character> characters = new List<Character>();

        public MainWindow()
        {
            InitializeComponent();

            polly = new Polly();
            clips = new List<AudioItem>();

            outputDataGrid.ItemsSource = clips;
        }

        private void speakButton_Click(object sender, RoutedEventArgs e)
        {
            string text = inputTextBox.Text;
            if (String.IsNullOrWhiteSpace(text))
            {
                return;
            }
            foreach (AudioItem item in clips)
            {
                if (item.Text.Trim().CompareTo(text.Trim()) == 0)
                {
                    PlayAudioFile(item.AudioFile);
                    inputTextBox.Text = "";
                    return;
                }
            }

            speakButton.IsEnabled = false;

            string file = polly.sendText(text);
            AudioItem newItem = new AudioItem() { Text = text, Voice = "Default", AudioFile = file };
            PlayAudioFile(newItem.AudioFile);
            clips.Add(newItem);

            inputTextBox.Text = "";
            outputDataGrid.Items.Refresh();
            speakButton.IsEnabled = true;
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button && (sender as Button).Tag != null)
            {
                string fileName = (sender as Button).Tag.ToString();
                PlayAudioFile(fileName);
            }
        }

        private void PlayAudioFile(string fileName)
        {
            audioMediaElement.Source = new Uri("mp3\\" + fileName, UriKind.Relative);
            audioMediaElement.Play();
        }

        private void characterSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            CharacterSelectionWindow charSettings = new CharacterSelectionWindow(polly, characters);
            charSettings.ShowDialog();
        }
    }

    public class AudioItem
    {
        public string Text { get; set; }
        public string Voice { get; set; }
        public string AudioFile { get; set; }
    }
}
