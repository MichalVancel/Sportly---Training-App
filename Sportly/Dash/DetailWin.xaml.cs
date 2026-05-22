using System;
using System.Collections.Generic;
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
    /// Interaction logic for DetailWin.xaml
    /// </summary>
    public partial class DetailWin : Window
    {
        public DetailWin()
        {
            InitializeComponent();
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
