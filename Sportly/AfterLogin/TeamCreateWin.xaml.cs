using Sportly.Dash;
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

namespace Sportly.AfterLogin
{
    /// <summary>
    /// Interaction logic for TeamCreateWin.xaml
    /// </summary>
    public partial class TeamCreateWin : Window
    {
        public TeamCreateWin()
        {
            InitializeComponent();
        }

        private void Sport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var teamData = new AboutTeam
            {
                TeamName = TeamName.Text,
                Sport = (Sport.SelectedItem as ComboBoxItem).Content.ToString(),
                City = CityName.Text
            };

            string json = JsonSerializer.Serialize(teamData);
            File.WriteAllText("teamData.json", json);

            MessageBox.Show("Tím bol vytvorený");

            DashBoard DashBoardWin = new DashBoard();
            DashBoardWin.WindowState = WindowState.Maximized;
            DashBoardWin.Show();
            this.Close();

        }

        internal class AboutTeam()
        {
            public string TeamName { get; set; }
            public string Sport { get; set; }
            public string City { get; set; }
            
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow LoginWindow = new MainWindow();
            LoginWindow.WindowState = WindowState.Maximized;
            LoginWindow.Show();
            this.Close();

        }
    }
}
