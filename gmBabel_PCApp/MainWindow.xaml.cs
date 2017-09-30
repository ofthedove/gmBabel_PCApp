﻿using System;
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

        public MainWindow()
        {
            InitializeComponent();
            polly = new Polly();
            clips = new List<AudioItem>();
        }

        private void speakButton_Click(object sender, RoutedEventArgs e)
        {
            string text = inputTextBox.Text;
            if (!String.IsNullOrWhiteSpace(text))
            {
                string file = polly.sendText(text);
                AudioItem newItem = new AudioItem() { Text = text, Voice = "Default", AudioFile = file };
                clips.Add(newItem);

                outputDataGrid.ItemsSource = clips;
            }
        }
    }

    public class AudioItem
    {
        public string Text { get; set; }
        public string Voice { get; set; }
        public string AudioFile { get; set; }
    }
}
