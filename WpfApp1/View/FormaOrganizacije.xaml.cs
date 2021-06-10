using Microsoft.Win32;
using organizerEvents.Controler;
using organizerEvents.model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

        public Organizator org;
        public FormaOrganizacije(Organizator organizator)
        {

            InitializeComponent();
            this.DataContext = this;

            Combo.ItemsSource = DataBase.mesta;
            Combo.DisplayMemberPath = "NazivMesta";
            Combo.SelectedValuePath = "Id";
            org = organizator;
            Combo.SelectedValue = DataBase.mesta[0].Id;
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
        private void Sacuvaj_Organizatora_Click(object sender, RoutedEventArgs e)
        {










            try
            {

                NoEmptyFieldValidator noEmptyFieldValidator = new NoEmptyFieldValidator();
                Validator.validate(Naziv, noEmptyFieldValidator);
                Validator.validate(Tip, noEmptyFieldValidator);

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
            int brojGostiju = int.Parse(BrojGostiju);
            DateTime datum = DateTime.Parse(Datum, CultureInfo.CurrentUICulture, DateTimeStyles.None);
            DateTime vreme = DateTime.Parse(Vreme, CultureInfo.CurrentUICulture, DateTimeStyles.None);
            DateTime dateTime = datum.AddTicks(vreme.Ticks);

            MessageBox.Show("Uspeh!");
            
            ZahtevZaProslavu proslava = new ZahtevZaProslavu {  Naslov= Naziv, Tip = Tip, Mesto = (Mesto)Combo.SelectedItem, DatumVreme = dateTime, Budzet = budzet, BrojGostiju = brojGostiju, MestoId = ((Mesto)Combo.SelectedItem).Id, Narucilac = (Narucilac)DataBase.trenutniKorisnik, NarucilacId = DataBase.trenutniKorisnik.Id, Opis = Opis, OrganizatorId = org.Id, Organizator = org };
            DataBase.zahtevZaProslave.Add(proslava);
            org.Zahtevi.Add(proslava);
            org.ZahteviId.Add(proslava.Id);
            
            (DataBase.trenutniKorisnik as Narucilac).Zahtevi.Add(proslava);
            (DataBase.trenutniKorisnik as Narucilac).ZahteviId.Add(proslava.Id);
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
