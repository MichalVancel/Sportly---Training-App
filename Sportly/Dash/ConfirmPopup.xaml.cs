using System.Windows;
using System.Windows.Input;

namespace Sportly.Dash
{
    public partial class ConfirmPopup : Window
    {
        public ConfirmPopup()
        {
            InitializeComponent();
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}