using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.Json;
namespace Sportly.Registration
{
    /// <summary>
    /// Interaction logic for RegistrationWin.xaml
    /// </summary>
    public partial class RegistrationWin : Window
    {
        public RegistrationWin()
        {
            InitializeComponent();
            genderSelect.Items.Add(new ComboBoxItem() { Content = "Muz" });
            genderSelect.Items.Add(new ComboBoxItem() { Content = "Zena" });
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AssignValue assVal = new AssignValue();


            string firstName = _firstName.Text;
            string lastName = _lastName.Text;
            DateTime? birthDate = _birthDate.SelectedDate;
            string address = _address.Text;
            string email = _email.Text;
            string phoneNumber = _phoneNumber.Text;
            string gender = (genderSelect.SelectedItem as ComboBoxItem).Content.ToString();
            string password = _password.Text;


        }
        private class AssignValue()
        {
            public string firstName { get; set; }
            public string lastName { get; set; } 
            public int birthDate { get; set;  }
            public string address { get; set; }
            public string email { get; set; }
            public string phoneNumber { get; set; }
            public string gender { get; set; }
            public string password { get; set; }

        }
      
    }

}   
    
    

