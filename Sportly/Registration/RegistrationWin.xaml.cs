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
using System.Text.RegularExpressions;
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

            var getData = new ExistingUserData
            {
                firstName = FirstName.Text,
                lastName = LastName.Text,
                birthDate = BirthDate.SelectedDate?.ToString("dd.MM.yyyy") ?? "",
                Address = Adress.Text,
                email = EmailAdd.Text,
                PhoneNumber = PhoneNum.Text,
                Gender = (GenderSelect.SelectedItem as ComboBoxItem).Content.ToString(),
                password = BCrypt.Net.BCrypt.EnhancedHashPassword(PassWord.Password)
            };
            

            if (BirthDate.SelectedDate < DateTime.Now )
            {
                 if(!Regex.IsMatch(PhoneNum.Text, "^[0-9]+$"))
                {
                    MessageBox.Show("Zle zadané telefónne číslo");
                }

                else
                {
                 
                 string json = JsonSerializer.Serialize(getData);
                    File.WriteAllText("userData.json", json);

                 MainWindow LoginWindow = new MainWindow();
                 MessageBox.Show("Registrácia úspešná");
                 LoginWindow.WindowState = WindowState.Maximized;
                 LoginWindow.Show();
                 this.Close();

                }
            }

            else
            {
                MessageBox.Show("Pre registráciu je potrebne zadat platny datum narodenia ");
            }

           



            
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

    
        internal class ExistingUserData
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string birthDate { get; set; }
            public string Address { get; set; }
            public string email { get; set; }
            public string PhoneNumber { get; set; }
            public string Gender { get; set; }
            public string password { get; set; }
        }

    
}   
    
    

