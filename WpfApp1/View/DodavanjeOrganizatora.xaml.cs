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
using MaterialDesignThemes.Wpf;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for DodavanjeOrganizatora.xaml
    /// </summary>
    public partial class DodavanjeOrganizatora : Window
    {
        OrganizatorKontroler kontroler { get; set; }
        public DodavanjeOrganizatora()
        {
            kontroler = new OrganizatorKontroler();
            InitializeComponent();
        }
        public void proveriSifru(object sender, RoutedEventArgs e)
        {
            if (Lozinka.Text.Length < 8)
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
        private void Sacuvaj_Organizatora_Click(object sender, RoutedEventArgs e)
        {







            String KorisnickoIme = this.Kime.Text;
            String Lozinka = this.Lozinka.Text;
            String BrTel = this.BrTel.Text;
            String Email = this.Email.Text;

            String Ime = this.Ime.Text;
            String Prezime = this.Prezime.Text;



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

                NumbersValidatorNumerals numbersValidatorNumerals = new NumbersValidatorNumerals();
                Validator.validate(this.Plata.Text, numbersValidatorNumerals);
                if (Lozinka.Length < 8)
                    throw new Exception("Molimo vas da ispravno popunite sva polja " + "sifra" + " je nevalidna");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            Double Plata = Double.Parse(this.Plata.Text); //TODO num

            MessageBox.Show("Uspeh!");
            Console.WriteLine(KorisnickoIme); Console.WriteLine("-----------------------------------------------");
            kontroler.dodajOrganizatora(KorisnickoIme,Lozinka,BrTel,Email,Ime, Prezime, Plata);


        }
    }
}
