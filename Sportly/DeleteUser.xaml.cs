using Sportly.Registration;
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
using static Sportly.ResetPassword;

namespace Sportly
{
    /// <summary>
    /// Interaction logic for DeleteUser.xaml
    /// </summary>
    public partial class DeleteUser : Window
    {
        public DeleteUser()
        {
            InitializeComponent();
        }

        private void DeleteUser1_Click(object sender, RoutedEventArgs e)
        {
            string jsonfile = "userData.json";
            if(!File.Exists(jsonfile))
            {
                MessageBox.Show("Neexistuje žiadny účet");
                
            }
            else
            {
                string jsonData = File.ReadAllText(jsonfile);
                ExistingUserData savedUser = JsonSerializer.Deserialize<ExistingUserData>(jsonData);
                bool IsPassSame = BCrypt.Net.BCrypt.EnhancedVerify(password.Password, savedUser.password);

            if (email.Text == savedUser.email && IsPassSame && firstName.Text == savedUser.firstName && lastName.Text == savedUser.lastName)

            {
               File.Delete(jsonfile);
                MessageBox.Show("Účet bol úspešne zmazaný");

                MainWindow mainWindow = new MainWindow();
                mainWindow.WindowState = WindowState.Maximized;
                mainWindow.Show();
                this.Close();

            }
            else if (email.Text != savedUser.email && IsPassSame)
            {
                MessageBox.Show("Neplatne prihlasovacie udaje");
            }
            }
            
          
               }

        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
