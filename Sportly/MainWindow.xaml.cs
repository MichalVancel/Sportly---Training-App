using Sportly.AfterLogin;
using Sportly.Registration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

using static Sportly.Registration.RegistrationWin;

namespace Sportly
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

            string filePathUserData = "userData.json";
        private void CreAccButt_Click(object sender, RoutedEventArgs e)
        {
            
            if (File.Exists(filePathUserData))
            {
                string DoesUserExist = File.ReadAllText(filePathUserData);

                
                if (DoesUserExist != "")
                {
                    MessageBox.Show("Dosiahnuty maximalny pocet registrovanych pouzivatelov");
                }
                else
                {
                    RegistrationWin registrationWin = new RegistrationWin();
                    registrationWin.WindowState = WindowState.Maximized;
                    registrationWin.Show();
                    this.Close();
                }
            }
            else
            {
                File.WriteAllText(filePathUserData, "", Encoding.UTF8);
                RegistrationWin registrationWin = new RegistrationWin();
                registrationWin.WindowState = WindowState.Maximized;
                registrationWin.Show();
                this.Close();
            }
        }
        

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            if (File.Exists(filePathUserData))
            {
                string Userdata = File.ReadAllText(filePathUserData);
                ExistingUserData savedUser = JsonSerializer.Deserialize<ExistingUserData>(Userdata);
                bool IsPassSame = BCrypt.Net.BCrypt.EnhancedVerify(PassWord.Password, savedUser.password);
                if (Email.Text == savedUser.email && IsPassSame)
                {
                    TeamCreateWin teamCreateWin = new TeamCreateWin();
                    teamCreateWin.WindowState = WindowState.Maximized;
                    teamCreateWin.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Zle si napísal email alebo heslo.");
                }
            }



           
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
           ResetPassword resetPassword = new ResetPassword();
            resetPassword.WindowState = WindowState.Maximized;
            resetPassword.Show();
            this.Close( );

        }
    }
}