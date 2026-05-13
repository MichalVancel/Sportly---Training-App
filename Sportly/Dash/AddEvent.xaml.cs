
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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

            MessageBox.Show("Udalosť sa uložila");

            this.Close();
        }

        private void EventKategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
