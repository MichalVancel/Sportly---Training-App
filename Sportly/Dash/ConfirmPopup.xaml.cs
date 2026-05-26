using System.Windows;
using System.Windows.Input;

namespace Sportly.Dash
{
    public partial class ConfirmPopup : Window
    {
        public string EventInfo { get; set; }

        public ConfirmPopup(string eventInfo = "")
        {
            InitializeComponent();
            EventInfo = eventInfo;
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Hide();
            AppologyWin appologyWin = new AppologyWin(EventInfo);
            
            appologyWin.ShowDialog();
            this.Close();
        }
    }
}