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
using System.Text.Json;
using System.IO;
using BCrypt;
namespace Sportly.Registration
{
    /// <summary>
    /// Interaction logic for RegistrationWin.xaml
    /// </summary>
    public partial class RegistrationWin : Window
    {
        public RegistrationWin()
        {
            InitializeComponent();
           

        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var getData = new AssignValue
            {
                firstName = FirstName.Text,
                lastName = LastName.Text,
                birthDate = BirthDate.SelectedDate,
                Address = Adress.Text,
                email = EmailAdd.Text,
                PhoneNumber = PhoneNum.Text,
                Gender = (GenderSelect.SelectedItem as ComboBoxItem).Content.ToString(),
                password = BCrypt.Net.BCrypt.EnhancedHashPassword(PassWord.Password)


            };
            
            
            string json = JsonSerializer.Serialize(getData);

            
            File.WriteAllText("userData.json", json);

            MessageBox.Show("Registrácia úspešná");

            MainWindow LoginWindow = new MainWindow();
            LoginWindow.WindowState = WindowState.Maximized;
            LoginWindow.Show();
            this.Close();


            
        }


        internal class AssignValue
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public DateTime? birthDate { get; set; }
            public string Address { get; set; }
            public string email { get; set; }
            public string PhoneNumber { get; set; }
            public string Gender { get; set; }
            public string password { get; set; }
        }
        private void GenderSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
    
    

