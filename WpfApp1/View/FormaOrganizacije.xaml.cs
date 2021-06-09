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
    /// Interaction logic for FormaOrganizacije.xaml
    /// </summary>
    public partial class FormaOrganizacije : Window
    {
        public String Naziv { get; set; }
        public String Datum { get; set; }
        public String Vreme { get; set; }
        public String Budzet { get; set; }
        public String Tip { get; set; }
        public String BrojGostiju { get; set; }
        public String Mesto { get; set; }
        public String Opis { get; set; }
        public FormaOrganizacije()
        {
            InitializeComponent();
            this.DataContext = this;
        }




        private void Sacuvaj_Organizatora_Click(object sender, RoutedEventArgs e)
        {










            try
            {

                NoEmptyFieldValidator noEmptyFieldValidator = new NoEmptyFieldValidator();
                Validator.validate(Naziv, noEmptyFieldValidator);
                Validator.validate(Tip, noEmptyFieldValidator);
                Validator.validate(Mesto, noEmptyFieldValidator);

                DateValidator dateValidator = new DateValidator();
                Validator.validate(Datum, dateValidator);

                TimeValidator timeValidator = new TimeValidator();
                Validator.validate(Vreme, timeValidator);

                NumbersValidatorNumerals numbersValidator = new NumbersValidatorNumerals();
                Validator.validate(Budzet, numbersValidator);
                Validator.validate(BrojGostiju, numbersValidator);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            Double budzet = Double.Parse(Budzet); //TODO num
            long brojGostiju = long.Parse(BrojGostiju);
            DateTime datum = DateTime.Parse(Datum);
            DateTime vreme = DateTime.Parse(Vreme);
            DateTime dateTime = datum.AddTicks(vreme.Ticks);

            MessageBox.Show("Uspeh!");
            //Console.WriteLine(KorisnickoIme); Console.WriteLine("-----------------------------------------------");
            //kontroler.dodajOrganizatora(KorisnickoIme, Lozinka, BrTel, Email, Ime, Prezime, Plata);


        }

        private void odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Naziv = "";
            this.Datum = "";
            this.Vreme = "";
            this.BrojGostiju = "";
            this.Budzet = "";
            this.Mesto = "";
            this.Tip = "";
        }
    }
}
