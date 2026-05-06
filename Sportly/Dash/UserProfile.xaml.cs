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
using static Sportly.Dash.DashBoard;

namespace Sportly.Dash
{
    /// <summary>
    /// Interaction logic for UserProfile.xaml
    /// </summary>
    public partial class UserProfile : Window
    {
        public UserProfile()
        {
            InitializeComponent();
            LoadUserProfileData();
        }


        internal class UserProfileData
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string birthDate { get; set; }
            public string Address { get; set; }
            public string email { get; set; }
            public string PhoneNumber { get; set; }
            public string Gender { get; set; }
           
        }

        public void LoadUserProfileData()
        {
            string jsonString = File.ReadAllText("userData.json");
            UserProfileData userData = JsonSerializer.Deserialize<UserProfileData>(jsonString);
            FirstNameBox.Text = userData.firstName;
            LastNameBox.Text = userData.lastName;
            DateOfBirthBox.Text = userData.birthDate;
            AddressBox.Text = userData.Address;
            EmailBox.Text = userData.email;
            PhoneBox.Text = userData.PhoneNumber;
            GenderBox.Text = userData.Gender;

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            DashBoard dashBoard = new DashBoard();
            dashBoard.WindowState = WindowState.Maximized;
            dashBoard.Show();
            this.Close();
        }
    }
}
