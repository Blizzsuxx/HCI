using organizerEvents.Controler;
using organizerEvents.model;
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

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for PrikazDogadjaja.xaml
    /// </summary>
    public partial class PrikazDogadjaja : Window
    {
        private ZahtevZaProslavu zahtev;
        public PrikazDogadjaja(ZahtevZaProslavu zahtev)
        {
            InitializeComponent();
            this.zahtev = zahtev;
            Console.WriteLine(zahtev.Naslov);
            Name.Text = zahtev.Naslov;
            datum.SelectedDate = zahtev.DatumVreme.Date;
            Vrijeme.SelectedTime = zahtev.DatumVreme;
            Console.WriteLine(zahtev.Budzet.ToString());
            Budzet.Text = zahtev.Budzet.ToString();
            Tip.Text = zahtev.Tip;
            Opis.Text = zahtev.Opis;
            Mesto.Text = zahtev.Mesto;
            Gosti.Text = zahtev.BrojGostiju.ToString();
        }

        private void Prihvaceno(object sender, RoutedEventArgs e)
        {
            Proslava proslava = new Proslava(this.zahtev);
            this.zahtev.Odobren = 1;
            proslava.Organizator = (DataBase.trenutniKorisnik as Organizator);
            proslava.Id = DataBase.proslave[DataBase.proslave.Count - 1].Id + 1;
            DataBase.proslave.Add(proslava);
            DataBase.sacuvajProslave();
            DataBase.sacuvajZahteveZaProslavu();
            this.Close();
        }

        private void Odbij(object sender, RoutedEventArgs e)
        {
            this.zahtev.Odobren = -1;
            DataBase.sacuvajZahteveZaProslavu();
            this.Close();
        }
    }
}
