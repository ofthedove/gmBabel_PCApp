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

namespace gmBabel_PCApp
{
    /// <summary>
    /// Interaction logic for VoiceSelectionWindow.xaml
    /// </summary>
    public partial class CharacterSelectionWindow : Window
    {
        Polly _polly;
        List<Character> _characters;
        Character[] _selectedCharacters;

        public CharacterSelectionWindow(Polly polly, List<Character> characters, ref Character[] selectedCharacters)
        {
            InitializeComponent();

            _polly = polly;
            _characters = characters;
            _selectedCharacters = selectedCharacters;

            char1ComboBox.ItemsSource = _characters;
            if (selectedCharacters[0] != null)
                char1ComboBox.SelectedItem = selectedCharacters[0];
            char2ComboBox.ItemsSource = _characters;
            if (selectedCharacters[1] != null)
                char1ComboBox.SelectedItem = selectedCharacters[1];
            char3ComboBox.ItemsSource = _characters;
            if (selectedCharacters[2] != null)
                char1ComboBox.SelectedItem = selectedCharacters[2];
            char4ComboBox.ItemsSource = _characters;
            if (selectedCharacters[3] != null)
                char1ComboBox.SelectedItem = selectedCharacters[3];
            char5ComboBox.ItemsSource = _characters;
            if (selectedCharacters[4] != null)
                char1ComboBox.SelectedItem = selectedCharacters[4];
            char6ComboBox.ItemsSource = _characters;
            if (selectedCharacters[5] != null)
                char1ComboBox.SelectedItem = selectedCharacters[5];
        }

        private void voiceListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedCharacters[Convert.ToInt32((sender as ComboBox).Tag)] = ((sender as ComboBox).SelectedValue as Character);
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            CharacterDeleteWindow delWin = new CharacterDeleteWindow();
            delWin.ShowDialog();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            CharacterSettingsWindow setWin = new CharacterSettingsWindow(_polly);
            setWin.ShowDialog();

            if(!setWin.Dirty)
            {
                Character ch = new Character();
                ch.CharName = setWin.CharName;
                ch.CharVoice = setWin.VoiceSettings;
                _characters.Add(ch);
                RefreshDropDowns();
            }
        }

        private void RefreshDropDowns()
        {
            char1ComboBox.Items.Refresh();
            char2ComboBox.Items.Refresh();
            char3ComboBox.Items.Refresh();
            char4ComboBox.Items.Refresh();
            char5ComboBox.Items.Refresh();
            char6ComboBox.Items.Refresh();
        }

        private void modifyButton_Click(object sender, RoutedEventArgs e)
        {
            CharacterSettingsWindow setWin = new CharacterSettingsWindow(_polly);
            setWin.ShowDialog();
        }

        private void okayButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
