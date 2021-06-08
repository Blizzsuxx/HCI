using MaterialDesignThemes.Wpf;
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
using System.Windows.Shapes;
using WpfApp1.Controler;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for AzuriranjeProfila.xaml
    /// </summary>
    public partial class AzuriranjeProfila : Window
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string BrTel { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

        public AzuriranjeProfila()
        {
            this.DataContext = this;
            InitializeComponent();

            ime.Text = DataBase.trenutniKorisnik.Ime;
            prezime.Text = DataBase.trenutniKorisnik.Prezime;
            email.Text = DataBase.trenutniKorisnik.Email;
            brTel.Text = DataBase.trenutniKorisnik.BrojTelefona;
            korIme.Text = DataBase.trenutniKorisnik.KorisnickoIme;
            
        }

        public void proveriSifru(object sender, RoutedEventArgs e)
        {
            if (lozinka.Text.Length < 8 && lozinka.Text.Length != 0)
            {
                lozinka.BorderBrush = Brushes.DarkRed;
                HintAssist.SetHelperText(lozinka, "Sifra mora imati 8 ili vise karaktera");
                HintAssist.SetForeground(lozinka, Brushes.DarkRed);
                lozinka.Foreground = Brushes.DarkRed;
            }
            else
            {
                lozinka.BorderBrush = Brushes.Black;
                lozinka.Foreground = Brushes.Black;
            }
        }

        private void SacuvajPromene_Click(object sender, RoutedEventArgs e)
        {
            Ime = ime.Text;
            Prezime = prezime.Text;
            BrTel = brTel.Text;
            KorisnickoIme = korIme.Text;
            Email = email.Text;
            Lozinka = lozinka.Text;




            try
            {
                UsernameValidator usernameValidator = new UsernameValidator();
                Validator.validate(KorisnickoIme, usernameValidator);

                NoEmptyFieldValidator noEmptyFieldValidator = new NoEmptyFieldValidator();
                Validator.validate(Ime, noEmptyFieldValidator);
                Validator.validate(Prezime, noEmptyFieldValidator);

                EmailValidator emailValidator = new EmailValidator();
                Validator.validate(Email, emailValidator);

                NumbersValidator numbersValidator = new NumbersValidator();
                Validator.validate(BrTel, numbersValidator);
                if (Lozinka.Length < 8 && Lozinka.Length != 0)
                    throw new Exception("Molimo vas da ispravno popunite sva polja " + "sifra" + " je nevalidna");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("Uspesno ste se promenili podatke!");
            DataBase.trenutniKorisnik.Ime = Ime;
            DataBase.trenutniKorisnik.Prezime = Prezime;
            DataBase.trenutniKorisnik.Email = Email;
            DataBase.trenutniKorisnik.KorisnickoIme = KorisnickoIme;
            DataBase.trenutniKorisnik.BrojTelefona = BrTel;
            if (Lozinka.Length != 0)
            {
                DataBase.trenutniKorisnik.Sifra = Lozinka;
            }
            this.Close();

        }

        private void Odbaci_Click(object sender, RoutedEventArgs e)
        {
            ime.Text = DataBase.trenutniKorisnik.Ime;
            prezime.Text = DataBase.trenutniKorisnik.Prezime;
            email.Text = DataBase.trenutniKorisnik.Email;
            brTel.Text = DataBase.trenutniKorisnik.BrojTelefona;
            korIme.Text = DataBase.trenutniKorisnik.KorisnickoIme;
        }
    }
}
