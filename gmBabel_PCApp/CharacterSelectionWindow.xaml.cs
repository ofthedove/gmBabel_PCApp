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
    public partial class VoiceSelectionWindow : Window
    {
        
        public VoiceSelectionWindow()
        {
            InitializeComponent();
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
            CharacterSettingsWindow setWin = new CharacterSettingsWindow();
            setWin.ShowDialog();
        }

        private void modifyButton_Click(object sender, RoutedEventArgs e)
        {
            CharacterSettingsWindow setWin = new CharacterSettingsWindow();
            setWin.ShowDialog();
        }
    }
}
