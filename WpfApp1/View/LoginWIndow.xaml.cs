using organizerEvents.Controler;
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
using MaterialDesignThemes.Wpf;
using organizerEvents.model;
using WpfApp1.View;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            //DataBase.ucitajPodatke();
            //DataBase.inicijalizujPodatke();
        }

        private void Otvori_ovaj_prozor(object sender, System.EventArgs e)
        {
            this.Show();
        }

        public void proveriSifru(object sender, RoutedEventArgs e)
        {
            if (Lozinka.Password.Length < 8)
            {
                Lozinka.BorderBrush = Brushes.DarkRed;
                HintAssist.SetHelperText(Lozinka, "Sifra mora imati 8 ili vise karaktera");
                HintAssist.SetForeground(Lozinka, Brushes.DarkRed);
                Lozinka.Foreground = Brushes.DarkRed;
            }
            else
            {
                Lozinka.BorderBrush = Brushes.Black;
                Lozinka.Foreground = Brushes.Black;
            }
        }

        private void validate(string text, ValidationRule validator)
        {
            var result = validator.Validate(text, null);
            if (!result.IsValid)
                throw new Exception("Molimo vas da ispravno popunite sva polja " + text + " je nevalidan");

        }

        private void button_Click_login(object sender, RoutedEventArgs e)
        {
            if (KorisnickoImeV.Text.Equals("admin"))
            {

            } else if (KorisnickoImeV.Text.Equals("org"))
            {
                //organizerEvents.Controler.DataBase.trenutniKorisnik = organuzator;
                ZadaciWindow zadaci = new ZadaciWindow();
                zadaci.Closed += new EventHandler(this.Otvori_ovaj_prozor);
                zadaci.Show();
                this.Hide();
                return;
            } else if (KorisnickoImeV.Text.Equals("nar"))
            {

            }
            Korisnik korisnik = DataBase.nadjiKorisnika(KorisnickoImeV.Text, Lozinka.Password);
            if(korisnik is Administrator)
            {
                return;
            } else if(korisnik is Organizator)
            {
                ZadaciWindow zadaci = new ZadaciWindow();
                zadaci.Closed += new EventHandler(this.Otvori_ovaj_prozor);
                zadaci.Show();
                this.Hide();
                return;
            } else if(korisnik is Narucilac)
            {
                return;
            }
            HintAssist.SetHelperText(Lozinka, "Pogresna Sifra i/ili Korisnicko Ime");



        }


        private void button_Click_registracija(object sender, RoutedEventArgs e)
        {
            RegistracijaWindow zadaci = new RegistracijaWindow();
            zadaci.Closed += new EventHandler(this.Otvori_ovaj_prozor);
            zadaci.Show();
            this.Hide();
        }
    }
}
