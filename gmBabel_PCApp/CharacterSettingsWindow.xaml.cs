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
    /// Interaction logic for VoiceSettingsWindow.xaml
    /// </summary>
    public partial class CharacterSettingsWindow : Window
    {
        public string CharName { get; set; }
        public string Lang { get; set; }
        public string Gender { get; set; }
        public string Voice { get; set; }

        public CharacterSettingsWindow()
        {
            InitializeComponent();
        }

        private void okayButton_Click(object sneder, RoutedEventArgs e)
        {

        }
    }
}
