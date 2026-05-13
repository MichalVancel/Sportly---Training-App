using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sportly.Dash
{
    /// <summary>
    /// Interaction logic for AppologyWin.xaml
    /// </summary>
    public partial class AppologyWin : Window
    {
        public AppologyWin()
        {
            InitializeComponent();
        }

        private void AppologyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        internal class AppologyData
        {
            public string ApologyText { get; set; }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            var apologyData = new AppologyData
            {
                ApologyText = AppologyTextBox.Text
            };

            string json = JsonSerializer.Serialize(apologyData);
            File.WriteAllText("Appology.json", json);
            MessageBox.Show("Ospravedlnenka napísaná");
            this.Close();

        }
    }
}
