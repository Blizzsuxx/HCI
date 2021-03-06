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
using organizerEvents.Controler;

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
        private void Logout(object sender, RoutedEventArgs e)
        {
            this.Close();
            DataBase.LogoutProzor.Show();
            foreach (Window window in Application.Current.Windows)
            {
                if (!window.Equals((Window)DataBase.LogoutProzor))
                {
                    window.Close();
                }
            }
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

        private void Organizatori_Click(object sender, RoutedEventArgs e)
        {
            PregledOrganizatora prozor = new PregledOrganizatora();
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

        private void Saradnici_Click(object sender, RoutedEventArgs e)
        {
            TabelaSaradnika prozor = new TabelaSaradnika();
            prozor.Closed += new EventHandler(this.Otvori_ovaj_prozor);
            prozor.Show();
            this.Hide();
            return;
        }

        private void Proslave_Click(object sender, RoutedEventArgs e)
        {
            PregledProslava prozor = new PregledProslava();
            prozor.Closed += new EventHandler(this.Otvori_ovaj_prozor);
            prozor.Show();
            this.Hide();
            return;
        }

        private void trazi_Click(object sender, RoutedEventArgs e)
        {
            String input = this.search.Text;
            if (input.Equals(""))
            {
                this.Korisnici.ItemsSource = null;
                this.Korisnici.ItemsSource= narucilackontroler.ucitaj();
            }
            else
            {
                List<Narucilac> n = new List<Narucilac>();
                foreach(Narucilac nar in narucilackontroler.ucitaj())
                {
                    if(nar.Email.StartsWith(input) || nar.BrojTelefona.StartsWith(input) ||
                        nar.Ime.StartsWith(input) || nar.KorisnickoIme.StartsWith(input) || nar.Prezime.StartsWith(input) 
                        )
                    {
                        n.Add(nar);
                    }
                }
                this.Korisnici.ItemsSource = null;
                this.Korisnici.ItemsSource = n;


            }

        }
    }
}
