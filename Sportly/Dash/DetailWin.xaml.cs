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
    /// Interaction logic for DetailWin.xaml
    /// </summary>
    public partial class DetailWin : Window
    {
        public DashBoard.Event CurrentEvent { get; set; }

        public DetailWin(DashBoard.Event selectedEvent)
        {
            InitializeComponent();
            CurrentEvent = selectedEvent;
            LoadAttendance();
        }

        private void LoadAttendance()
        {
            try
            {
                string jsonString = File.ReadAllText("userData.json");
                DashBoard.Data userData = JsonSerializer.Deserialize<DashBoard.Data>(jsonString);

                string apologyText = "";
                if (CurrentEvent.Ucast == false)
                {
                    try
                    {
                        if (File.Exists("Appology.json"))
                        {
                            string apologyJson = File.ReadAllText("Appology.json");
                            var apologies = JsonSerializer.Deserialize<List<AppologyWin.AppologyData>>(apologyJson);
                            if (apologies != null)
                            {
                                var matchingApology = apologies.Find(a => a.FirstName == userData.firstName && 
                                                                          a.LastName == userData.lastName && 
                                                                          a.EventInfo == CurrentEvent.EvenInfo);
                                if (matchingApology != null)
                                {
                                    apologyText = matchingApology.ApologyText;
                                }
                            }
                        }
                    }
                    catch { }
                }

                List<AttendanceRecord> records = new List<AttendanceRecord>();
                records.Add(new AttendanceRecord
                {
                    FirstName = userData.firstName,
                    LastName = userData.lastName,
                    AttendingSymbol = CurrentEvent.Ucast == true ? "\uE73E" : (CurrentEvent.Ucast == false ? "\uE711" : "\uE11B"),
                    SymbolForeground = CurrentEvent.Ucast == true ? "#4CAF50" : (CurrentEvent.Ucast == false ? "#FF5252" : "White"),
                    SymbolBackground = CurrentEvent.Ucast == true ? "#1B4220" : (CurrentEvent.Ucast == false ? "#4A1C1C" : "#333333"),
                    ApologyText = apologyText
                });

                Attendance.ItemsSource = records;
            }
            catch { }
        }

        public class AttendanceRecord
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string AttendingSymbol { get; set; }
            public string SymbolForeground { get; set; }
            public string SymbolBackground { get; set; }
            public string ApologyText { get; set; }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            DashBoard dash = new DashBoard();
            dash.WindowState = WindowState.Maximized;
            dash.Show();
            this.Close();

        }
    }   
}
