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
using WpfApp1.Controler;
using organizerEvents.model;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for PregledKorisnika.xaml
    /// </summary>
    public partial class PregledKorisnika : Window
    {
        Narucilac narucilac { get; set; }
       NarucilacKontroler narucilackontroler { get; set; }

        public PregledKorisnika()
        {
            narucilackontroler = new NarucilacKontroler();

            InitializeComponent();
            this.Korisnici.ItemsSource = narucilackontroler.ucitaj();

        }

        private void profil_Click(object sender, RoutedEventArgs e)
        {
            if (this.narucilac == null) { } else
            {
                ProfilKorisnika prozor = new ProfilKorisnika(this.narucilac.Id);
                prozor.Closed += new EventHandler(this.Otvori_ovaj_prozor);
                prozor.Show();
                this.Hide();
                return;
            }

        }
        private void Otvori_ovaj_prozor(object sender, System.EventArgs e)
        {
            this.Show();
        }

        private void Korisnici_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.narucilac =(Narucilac)this.Korisnici.SelectedItem;

        }
    }
}
