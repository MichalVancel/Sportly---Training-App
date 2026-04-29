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
            var newEvent = new GetEventData
            {
                place = PlaceName.Text,
                date = EventDate.SelectedDate?.ToString("dd.MM.yyyy") ?? "",
                timeFrom =  TimeFrom.Text,
                timeTo =    TimeTo.Text,
                eventCategory = (EventKategory.SelectedItem as ComboBoxItem).Content.ToString(),
                eventType = (EventType.SelectedItem as ComboBoxItem).Content.ToString()
            };

            string jsonData = System.Text.Json.JsonSerializer.Serialize(newEvent);
            File.WriteAllText("EventData.json", jsonData);


            MessageBox.Show("Udalosť sa uložila");

            this.Close();
        }



        internal class GetEventData
        { 
           public string place { get; set; }
           public string date { get; set; }
           public string timeFrom { get; set; }
           public string timeTo { get; set; }
           
           public string eventCategory { get; set; }

           public string eventType { get; set; }









        }

        private void EventKategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
