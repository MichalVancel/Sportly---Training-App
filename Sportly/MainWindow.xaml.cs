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

        private void CreAccButt_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWin registrationWin = new RegistrationWin();
            registrationWin.WindowState = WindowState.Maximized;
            registrationWin.Show();
            this.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "userData.json";

            if (File.Exists(filePath))
            {
                string Userdata = File.ReadAllText(filePath);
                AssignValue savedUser = JsonSerializer.Deserialize<AssignValue>(Userdata);
                if (Email.Text == savedUser.email && PassWord.Password == savedUser.password)
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
    }
}