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
        public string CurrentEventInfo { get; set; }

        public AppologyWin(string eventInfo = "")
        {
            InitializeComponent();
            CurrentEventInfo = eventInfo;
        }

        private void AppologyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        internal class AppologyData
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string ApologyText { get; set; }
            public string EventInfo { get; set; }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AppologyTextBox.Text))
            {
                MessageBox.Show("Zadajte ospravedlnenku");
                return;
            }

            string firstName = "";
            string lastName = "";

            try
            {
                if (File.Exists("userData.json"))
                {
                    string userJson = File.ReadAllText("userData.json");
                    var userData = JsonSerializer.Deserialize<DashBoard.Data>(userJson);
                    if (userData != null)
                    {
                        firstName = userData.firstName;
                        lastName = userData.lastName;
                    }
                }
            }
            catch { }

            var apologyData = new AppologyData
            {
                FirstName = firstName,
                LastName = lastName,
                ApologyText = AppologyTextBox.Text,
                EventInfo = CurrentEventInfo
            };

            List<AppologyData> apologies = new List<AppologyData>();

            try
            {
                if (File.Exists("Appology.json"))
                {
                    string existingJson = File.ReadAllText("Appology.json");
                    var existingApologies = JsonSerializer.Deserialize<List<AppologyData>>(existingJson);
                    if (existingApologies != null)
                    {
                        apologies = existingApologies;
                    }
                }
            }
            catch { }

            apologies.Add(apologyData);

            try
            {
                string json = JsonSerializer.Serialize(apologies, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("Appology.json", json);
                MessageBox.Show("Ospravedlnenka napísaná");
                this.Close();
            }
            catch { }
        }
    }
}
