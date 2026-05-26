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
            LoadEvents();
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

        public class Event : System.ComponentModel.INotifyPropertyChanged
        {
            public string Miesto { get; set; }
            public string Datum { get; set; }
            public string CasOd { get; set; }
            public string CasDo { get; set; }
            public string Kategoria { get; set; }
            public string Typ { get; set; }

            private int _pocetUcastnikov;
            public int PocetUcastnikov 
            { 
                get => _pocetUcastnikov; 
                set { _pocetUcastnikov = value; OnPropertyChanged(nameof(PocetUcastnikov)); }
            }

            private bool? _ucast;
            public bool? Ucast 
            { 
                get => _ucast; 
                set { _ucast = value; OnPropertyChanged(nameof(Ucast)); }
            }

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(name));

            public string EvenInfo => $"{Datum} - {Typ}: {Miesto} ({CasOd}-{CasDo})";

            public override string ToString() => EvenInfo;
        }

        public void LoadEvents()
        {
            string path = "EventData.json";

            if (File.Exists(path))
            {
                try
                {
                    List<Event> events = JsonSerializer.Deserialize<List<Event>>(File.ReadAllText(path));
                    Events.ItemsSource = null;
                    Events.ItemsSource = events;
                }
                catch
                {
                }
            }
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
            addEvent.Closed += (s, args) => 
            {
                LoadEvents();
            };
            addEvent.Show();
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            UserProfile userProfile = new UserProfile();
            userProfile.WindowState = WindowState.Maximized;
            userProfile.Show();
            this.Close();
        }

        

       

        private void LButton_Click(object sender, RoutedEventArgs e)
        {

        }
// ai kod - robi ze novy event typu zapas a pod sa prida do dashboardu automaticky a otevre
        private void AttendanceToggleButton_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender is System.Windows.Controls.Primitives.ToggleButton toggleButton && toggleButton.DataContext is Event clickedEvent)
            {
                // Zastavíme predvolené správanie kliknutia
                e.Handled = true; 

                ConfirmPopup popup = new ConfirmPopup();
                popup.Owner = this;

                bool? result = popup.ShowDialog();

                // Ak užívateľ zavrel popup bez výberu, neurobíme nič
                if (result == null) return;

                bool? oldUcast = clickedEvent.Ucast;
                bool newUcast = result.Value;

                if (newUcast != oldUcast)
                {
                    // zmení sa počet účasníkov
                    if (newUcast == true)
                    {
                        clickedEvent.PocetUcastnikov++;
                    }
                    else if (oldUcast == true && newUcast == false)
                    {
                        clickedEvent.PocetUcastnikov--;
                    }

                    clickedEvent.Ucast = newUcast;

                    // Uložiť zmeny do JSONu
                    try
                    {
                        if (Events.ItemsSource is List<Event> allEvents)
                        {
                            string jsonData = JsonSerializer.Serialize(allEvents);
                            File.WriteAllText("EventData.json", jsonData);
                        }
                    }
                    catch { }
                }
            }
        }
// až do tialto

        private void UserInfoButton_Click(object sender, RoutedEventArgs e)
        {
            UserProfile userProfile = new UserProfile();
            userProfile.WindowState = WindowState.Maximized;
            userProfile.Show();
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.WindowState = WindowState.Maximized;
            mainWindow.Show();
            this.Close();
        }

        private void RemoveEventButton_Click(object sender, RoutedEventArgs e)
        {
            if(Events.SelectedItem is Event selectedEvent)
            {
               
                    if (Events.ItemsSource is List<Event> allEvents)
                    {
                        allEvents.Remove(selectedEvent);
                        string jsonData = JsonSerializer.Serialize(allEvents);
                        File.WriteAllText("EventData.json", jsonData);
                        LoadEvents();
                    }
                
            }
        }

        private void EventDetails_DoubleClick(object sender, RoutedEventArgs e)
        {
                DetailWin detail = new DetailWin();              
                detail.WindowState = WindowState.Maximized;             
                detail.ShowDialog();
        }
    }
}
