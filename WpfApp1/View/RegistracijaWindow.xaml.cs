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
    /// Interaction logic for RegistracijaWindow.xaml
    /// </summary>
    public partial class RegistracijaWindow : Window
    {

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string BrojTelefona { get; set; }
        public string KorisnickoIme { get; set; }



        public RegistracijaWindow()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        public void proveriSifru(object sender, RoutedEventArgs e)
        {
            if(Lozinka.Password.Length < 8) {
                Lozinka.BorderBrush = Brushes.DarkRed;
                HintAssist.SetHelperText(Lozinka, "Sifra mora imati 8 ili vise karaktera");
                HintAssist.SetForeground(Lozinka, Brushes.DarkRed);
                Lozinka.Foreground = Brushes.DarkRed;
            } else
            {
                Lozinka.BorderBrush = Brushes.Black;
                Lozinka.Foreground = Brushes.Black;
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UsernameValidator usernameValidator = new UsernameValidator();
                Validator.validate(KorisnickoImeV.Text, usernameValidator);

                NoEmptyFieldValidator noEmptyFieldValidator = new NoEmptyFieldValidator();
                Validator.validate(ImeV.Text, noEmptyFieldValidator);
                Validator.validate(PrezimeV.Text, noEmptyFieldValidator);

                EmailValidator emailValidator = new EmailValidator();
                Validator.validate(EmailV.Text, emailValidator);

                NumbersValidator numbersValidator = new NumbersValidator();
                Validator.validate(BrojTelefonaV.Text, numbersValidator);
                if (Lozinka.Password.Length < 8)
                    throw new Exception("Molimo vas da ispravno popunite sva polja " + "sifra" + " je nevalidna");
            } catch(Exception ex)
            {
                MessageBox.Show("Molimo vas da ispravno popunite sva polja " + ex.Message + " je nevalidan");
                return;
            }
            MessageBox.Show("Uspesno ste se registrovali!");
            DataBase.narucioci.Add(new organizerEvents.model.Narucilac {Ime=ImeV.Text, Email=EmailV.Text, Prezime=PrezimeV.Text, Sifra=Lozinka.Password, BrojTelefona=BrojTelefonaV.Text, KorisnickoIme = KorisnickoImeV.Text });
            this.Close();
        }
    }
}
