using organizerEvents.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for ChatPopupsUserControl.xaml
    /// </summary>
    public partial class ChatPopupsUserControl : UserControl
    {
        public Proslava Proslava { get; set; }
        public ChatPopupsUserControl(Proslava Proslava)
        {
            InitializeComponent();
            this.Proslava = Proslava;

            Naslov.Text = Proslava.Naslov;
            Sadrzaj.Text = Proslava.Opis;

        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Chat chat = new Chat(Proslava);
            chat.Show();
            
        }
    }
}
