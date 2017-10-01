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
        List<Character> characters;
        Character[] selectedCharacters = new Character[6];
        Button[] charButtons;
        Character curChar;

        public MainWindow()
        {
            InitializeComponent();

            polly = new Polly();
            clips = new List<AudioItem>();
            characters = Character.Load();

            outputDataGrid.ItemsSource = clips;

            charButtons = new Button[6];
            charButtons[0] = characterOneButton;
            charButtons[1] = characterTwoButton;
            charButtons[2] = characterThreeButton;
            charButtons[3] = characterFourButton;
            charButtons[4] = characterFiveButton;
            charButtons[5] = characterSixButton;
            RefreshCharacterButtons();
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
                if (item.Voice.CompareTo(curChar.CharName) == 0 && item.Text.Trim().CompareTo(text.Trim()) == 0)
                {
                    PlayAudioFile(item.AudioFile);
                    inputTextBox.Text = "";
                    return;
                }
            }

            speakButton.IsEnabled = false;

            string file;
            AudioItem newItem;
            if (curChar == null)
            {
                file = polly.sendText(text);
                newItem = new AudioItem() { Text = text, Voice = "Default", AudioFile = file };
            }
            else
            {
                file = polly.sendText(text, curChar.CharVoice);
                newItem = new AudioItem() { Text = text, Voice = curChar.CharName, AudioFile = file };
            }
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
            CharacterSelectionWindow charSettings = new CharacterSelectionWindow(polly, characters, ref selectedCharacters);
            charSettings.ShowDialog();
            RefreshCharacterButtons();
        }

        private void gmBabel_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Character.Save(characters);
        }

        private void RefreshCharacterButtons()
        {
            for (int i = 0; i < 6; i++)
            {
                if (selectedCharacters[i] == null)
                {
                    charButtons[i].Content = "Character " + i;
                    charButtons[i].IsEnabled = false;
                }
                else
                {
                    charButtons[i].Content = selectedCharacters[i].CharName;
                    charButtons[i].IsEnabled = true;
                }
            }
        }

        private void charButton_Click(object sender, RoutedEventArgs e)
        {
            int i = Convert.ToInt32((sender as Button).Tag);
            curChar = selectedCharacters[i];
        }
    }

    public class AudioItem
    {
        public string Text { get; set; }
        public string Voice { get; set; }
        public string AudioFile { get; set; }
    }
}
