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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_Copy.Text.Equals("admin"))
            {

            } else if (textBox_Copy.Text.Equals("org"))
            {
                //organizerEvents.Controler.DataBase.trenutniKorisnik = organuzator;
                ZadaciWindow zadaci = new ZadaciWindow();
                zadaci.Closed += new EventHandler(this.Otvori_ovaj_prozor);
                zadaci.Show();
                this.Hide();
                return;
            } else if (textBox_Copy.Text.Equals("nar"))
            {

            }
            foreach (var admin in organizerEvents.Controler.DataBase.administratori)
            {
                if ((admin.Sifra.Equals(passwordBox.Password) && admin.KorisnickoIme.Equals(textBox_Copy.Text)) )
                {
                    organizerEvents.Controler.DataBase.trenutniKorisnik = admin;
                    return;
                } 
   
            }
            foreach (var organuzator in organizerEvents.Controler.DataBase.organizatori )
            {
                if ((organuzator.Sifra.Equals(passwordBox.Password) && organuzator.KorisnickoIme.Equals(textBox_Copy.Text)) )
                {
                    organizerEvents.Controler.DataBase.trenutniKorisnik = organuzator;
                    ZadaciWindow zadaci = new ZadaciWindow();
                    zadaci.Closed += new EventHandler(this.Otvori_ovaj_prozor);
                    zadaci.Show();
                    this.Hide();
                    return;
                }

            }
            foreach (var narucioci in organizerEvents.Controler.DataBase.narucioci )
            {
                if ((narucioci.Sifra.Equals(passwordBox.Password) && narucioci.KorisnickoIme.Equals(textBox_Copy.Text)))
                {
                    organizerEvents.Controler.DataBase.trenutniKorisnik = narucioci;
                    return;
                }

            }
            HintAssist.SetHelperText(passwordBox, "Pogresna Sifra i/ili Korisnicko Ime");



        }

        private void textBox_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
