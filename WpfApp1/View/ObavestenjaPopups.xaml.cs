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
using System.Windows.Shapes;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for ObavestenjaPopups.xaml
    /// </summary>
    public partial class ObavestenjaPopups : UserControl
    {
        public string Ime { get; set; }
        public string Opis { get; set; }
        public ObavestenjaPopups(string ime, string opis)
        {InitializeComponent();
            this.Ime = ime;
            this.Opis = opis;
            Naslov.Text = ime;
            Sadrzaj.Text = opis;
            
        }
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            OdobravanjeReci chat = new OdobravanjeReci(Ime,Opis);
            chat.Show();

        }
    }
}
