using Sportly.AfterLogin;
using Sportly.Dash;
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
           WindowState = WindowState.Maximized;
        }

            string filePathUserData = "userData.json";
        private void CreAccButt_Click(object sender, RoutedEventArgs e)
        {
            
            if (File.Exists(filePathUserData))
            {
                string DoesUserExist = File.ReadAllText(filePathUserData);

                
                if (DoesUserExist != "")
                {
                    MessageBox.Show("Môžeš mať iba jeden účet!");
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
                File.WriteAllText(filePathUserData, "");
                RegistrationWin registrationWin = new RegistrationWin();
                registrationWin.WindowState = WindowState.Maximized;
                registrationWin.Show();
                this.Close();
            }
        }
        

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Email.Text) || string.IsNullOrEmpty(PassWord.Password))
            {
                MessageBox.Show("Vyplňte všetky polia");
                return;
            }

            if (File.Exists(filePathUserData))
            {


                string Userdata = File.ReadAllText(filePathUserData);
                ExistingUserData savedUser = JsonSerializer.Deserialize<ExistingUserData>(Userdata);
                bool IsPassSame = BCrypt.Net.BCrypt.EnhancedVerify(PassWord.Password, savedUser.password);

                string teamDataPath = "teamData.json";

                if (Email.Text == savedUser.email && IsPassSame)
                {


                    if (!File.Exists(teamDataPath))
                    {

                        TeamCreateWin teamCreateWin = new TeamCreateWin();
                        teamCreateWin.WindowState = WindowState.Maximized;
                        teamCreateWin.Show();
                        this.Close();
                    }
                    else
                    {
                        DashBoard dashBoard = new DashBoard();
                        dashBoard.WindowState = WindowState.Maximized;
                        dashBoard.Show();
                        this.Close();
                    }

                }

                else if (Email.Text != savedUser.email || !IsPassSame)
                {
                    MessageBox.Show("Zle si napísal email alebo heslo.");
                }
            }
           
           


        }



           
        

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (File.Exists(filePathUserData))
            {
                string json = File.ReadAllText(filePathUserData);
                if(json != "")
                {
                ResetPassword resetPassword = new ResetPassword();
                resetPassword.WindowState = WindowState.Maximized;
                resetPassword.Show();
                this.Close( );

                }
                else if(json == "")
                {
                MessageBox.Show("Neexistuje žiadny účet");
                }

            }
            else if (!File.Exists(filePathUserData))
            {
                MessageBox.Show("Ešte si není zaregistrovaný");
            }

            
            

        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
           
            if(File.Exists(filePathUserData))
            {
                string userData = File.ReadAllText(filePathUserData);
                if (userData != "")
                {
                    DeleteUser deleteUser = new DeleteUser();
                    deleteUser.WindowState = WindowState.Maximized;
                    deleteUser.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Neexistuje žiadny účet");
                }
               

            }
        }
    }
}