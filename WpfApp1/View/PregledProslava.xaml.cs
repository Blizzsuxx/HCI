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
    /// Interaction logic for PregledProslava.xaml
    /// </summary>
    public partial class PregledProslava : Window
    {
        Proslava proslava { get; set; }
       ProslavaKontroler proslaveKontroler { get; set; }
        public PregledProslava()
        {
            proslaveKontroler = new ProslavaKontroler();
            InitializeComponent();
            this.Proslave.ItemsSource = this.proslaveKontroler.ucitaj();
        }

        private void Jedna_Click(object sender, RoutedEventArgs e)
        {
            if (this.proslava == null)
            {

            }
            else
            {
                PregledJedneProslave prozor = new PregledJedneProslave(this.proslava.Id);
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

        private void Proslave_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.proslava = (Proslava)this.Proslave.SelectedItem;

        }

        private void Organizatori_Click(object sender, RoutedEventArgs e)
        {
            PregledOrganizatora prozor = new PregledOrganizatora();
            prozor.Closed += new EventHandler(this.Otvori_ovaj_prozor);
            prozor.Show();
            this.Hide();
            return;
        }

        private void Saradnici_Click(object sender, RoutedEventArgs e)
        {
            TabelaSaradnika prozor = new TabelaSaradnika();
            prozor.Closed += new EventHandler(this.Otvori_ovaj_prozor);
            prozor.Show();
            this.Hide();
            return;
        }

        private void Korisnici_Click(object sender, RoutedEventArgs e)
        {
            PregledKorisnika prozor = new PregledKorisnika();
            prozor.Closed += new EventHandler(this.Otvori_ovaj_prozor);
            prozor.Show();
            this.Hide();
            return;
        }

        private void Mesta_Click(object sender, RoutedEventArgs e)
        {
            PregledSvihMesta prozor = new PregledSvihMesta();
            prozor.Closed += new EventHandler(this.Otvori_ovaj_prozor);
            prozor.Show();
            this.Hide();
            return;
        }
    }
}
