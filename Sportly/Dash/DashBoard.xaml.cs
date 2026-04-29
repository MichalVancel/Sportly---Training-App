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
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Window
    {
        public DashBoard()
        {
            InitializeComponent();
            LoadUserData();
        }

        

        public void LoadUserData()
        {
           string jsonString = File.ReadAllText("userData.json");
           Data userData = JsonSerializer.Deserialize<Data>(jsonString);
           NameLabel.Content = userData.firstName;
           SureNameLabel.Content = userData.lastName;
           BirthDateLabel.Content = userData.birthDate;




           string jsonString2 = File.ReadAllText("teamData.json");
           Data TeamData = JsonSerializer.Deserialize<Data>(jsonString2);
           TeamNameLabel.Content = TeamData.TeamName;

        }





        internal class Data()
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string TeamName { get; set; }

            public string birthDate { get; set; }
        }

        private void AddEventButton_Click(object sender, RoutedEventArgs e)
        {
            AddEvent addEvent = new AddEvent();
            addEvent.Show();

        }
    }
}
