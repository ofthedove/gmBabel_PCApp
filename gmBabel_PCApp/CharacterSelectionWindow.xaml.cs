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

        public CharacterSelectionWindow(Polly polly, List<Character> characters)
        {
            InitializeComponent();

            _polly = polly;
            _characters = characters;

            char1ComboBox.ItemsSource = _characters;
            char2ComboBox.ItemsSource = _characters;
            char3ComboBox.ItemsSource = _characters;
            char4ComboBox.ItemsSource = _characters;
            char5ComboBox.ItemsSource = _characters;
            char6ComboBox.ItemsSource = _characters;
        }

        private void allVoicesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void quickVoicesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
    }
}
