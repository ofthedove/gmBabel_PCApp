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
using Amazon.Polly;

namespace gmBabel_PCApp
{
    /// <summary>
    /// Interaction logic for VoiceSettingsWindow.xaml
    /// </summary>
    public partial class CharacterSettingsWindow : Window
    {
        Polly _polly;

        private string _CharName;
        private VoiceSettings _VoiceSettings;
        private bool _Dirty = true;

        public string CharName { get { return _CharName; } set { _CharName = value;  nameTextBox.Text = _CharName; } }
        public VoiceSettings VoiceSettings { get { return _VoiceSettings; } }
        public bool Dirty { get { return _Dirty; } }

        public CharacterSettingsWindow(Polly polly)
        {
            InitializeComponent();

            _polly = polly;
            langComboBox.ItemsSource = VoiceSettings.LanguageOptions();
        }

        private void okayButton_Click(object sneder, RoutedEventArgs e)
        {
            VoiceId voiceId;

            if (!String.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                _CharName = nameTextBox.Text;
            }
            else
            {
                MessageBox.Show("You must choose a name for your character!");
                return;
            }

            if (voiceComboBox.SelectedValue is VoiceId)
            {
                voiceId = (VoiceId)voiceComboBox.SelectedValue;
            }
            else
            {
                MessageBox.Show("You must select a voice for your character!");
                return;
            }

            Polly.MyGender gender = ConvertGender(((ComboBoxItem)genderComboBox1.SelectedItem).Name);
            string langCd = langComboBox.SelectedValue.ToString();
            VoiceSettings vs = new VoiceSettings() { VoiceID = voiceId, Gender = gender, Language = langCd };
            _VoiceSettings = vs;

            _Dirty = false;
            this.Close();
        }

        private void langComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Polly.MyGender gender = ConvertGender(((ComboBoxItem)genderComboBox1.SelectedItem).Name);
                voiceComboBox.ItemsSource = _polly.GetVoices(langComboBox.SelectedValue.ToString(), gender);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid language selection!");
                string msg;
                msg = ex.Message + "  ";
            }
        }

        private void genderComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (langComboBox.SelectedItem != null)
                {
                    Polly.MyGender gender = ConvertGender(((ComboBoxItem)genderComboBox1.SelectedItem).Name);
                    voiceComboBox.ItemsSource = _polly.GetVoices(langComboBox.SelectedValue.ToString(), gender);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid language selection!");
                string msg;
                msg = ex.Message + "  ";
            }
        }

        private Polly.MyGender ConvertGender(string gender)
        {
            Polly.MyGender outGender;
            switch (gender)
            {
                case "genderCB_Male":
                    outGender = Polly.MyGender.Male;
                    break;
                case "genderCB_Female":
                    outGender = Polly.MyGender.Female;
                    break;
                case "genderCB_All":
                default:
                    outGender = Polly.MyGender.All;
                    break;
            }
            return outGender;
        }
    }
}
