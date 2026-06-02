
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddEvent.xaml
    /// </summary>
    public partial class AddEvent : Window
    {
        public AddEvent()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            if (string.IsNullOrWhiteSpace(PlaceName.Text) || EventDate.SelectedDate == null || string.IsNullOrWhiteSpace(TimeFrom.Text) || string.IsNullOrWhiteSpace(TimeTo.Text) || EventKategory.SelectedItem == null || EventType.SelectedItem == null)
            {
                MessageBox.Show("Vyplňte všetky polia");
                return;
            }
            var newEvent = new DashBoard.Event
            {
                Miesto = PlaceName.Text,
                Datum = EventDate.SelectedDate?.ToString("dd.MM.yyyy") ?? "",
                CasOd = TimeFrom.Text,
                CasDo = TimeTo.Text,
                Kategoria = (EventKategory.SelectedItem as ComboBoxItem).Content?.ToString() ?? "",
                Typ = (EventType.SelectedItem as ComboBoxItem).Content?.ToString() ?? ""
            };

            string path = "EventData.json";
            List<DashBoard.Event> events = new List<DashBoard.Event>();
            string timePattern = @"^(0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$";

            if (!Regex.IsMatch(TimeTo.Text, timePattern) || !Regex.IsMatch(TimeFrom.Text, timePattern))
            {
                MessageBox.Show("Zle zadaný čas. Zadajte formát od 00:00 do 23:59.");
            }
            else
            {
                    
                    if (File.Exists(path))
                    {
                        string existingJson = File.ReadAllText(path);


                        if (!string.IsNullOrWhiteSpace(existingJson))
                        {
                            try
                            {
                                events = System.Text.Json.JsonSerializer.Deserialize<List<DashBoard.Event>>(existingJson) ?? new List<DashBoard.Event>();
                            }
                            catch
                            {

                            }
                        }
                    }

                    events.Add(newEvent);

                    string jsonData = System.Text.Json.JsonSerializer.Serialize(events);
                    File.WriteAllText(path, jsonData);

                    MessageBox.Show("Udalosť pridaná");

                    this.Close();

            }
        }

        private void EventKategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EventType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TimeFrom_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
