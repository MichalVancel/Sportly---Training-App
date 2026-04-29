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
using static Sportly.Registration.ExistingUserData;
namespace Sportly
{
    /// <summary>
    /// Interaction logic for ResetPassword.xaml
    /// </summary>
    public partial class ResetPassword : Window
    {
        public ResetPassword()
        {
            InitializeComponent();
        }

        string userFilePath = "userData.json";
        public class UserData
        {
            public string isEmailCorrect { get; set; }
            public string newPassword { get; set; }


        }

        private void resetPasswordBuutton_Click(object sender, RoutedEventArgs e)
        {
            
            string json = File.ReadAllText(userFilePath);
            ExistingUserData userData = JsonSerializer.Deserialize<ExistingUserData>(json);
            string isEmailCorrect = emailTextBox.Text; 
            string newPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(newPasswordBox.Password);
            
            if(isEmailCorrect == userData.email)
            {
                userData.password = newPassword;
                string usersData = JsonSerializer.Serialize(userData);
                File.WriteAllText(userFilePath, usersData);
                MessageBox.Show("Heslo uspesne zresetovane, mozete ssa prihlasit znova");
                MainWindow LoginWindow = new MainWindow();
                LoginWindow.WindowState = WindowState.Maximized;
                LoginWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nespravne udaje zadane, nemozno resetovat heslo, skuste znova");
            }
        }
    }
}
