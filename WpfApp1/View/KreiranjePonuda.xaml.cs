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
    /// Interaction logic for KreiranjePonuda.xaml
    /// </summary>
    public partial class KreiranjePonuda : Window
    {
        private Saradnik saradnik;
        public KreiranjePonuda(Saradnik saradnik)
        {
            
            InitializeComponent();
            this.saradnik = saradnik;
        }

        private void Kreiraj_Ponudu(object sender, RoutedEventArgs e)
        {
            string naziv = this.Naziv.Text;
            string tip = this.Tip.Text;
            int budzet = Int32.Parse(this.Budzet.Text);
            string opis = this.Opis.Text;
            string informacije = this.Informacije.Text;
            this.sacuvajPonudu(naziv, tip, budzet, opis, informacije);

        }

        private void sacuvajPonudu(string naziv, string tip, int budzet, string opis, string informacije)
        {
            Ponuda ponuda = new Ponuda
            {
                Naziv = naziv,
                Tip = tip,
                Budzet =  budzet,
                Opis =  opis,
                Informacije = informacije
            };
            ponuda.Id = DataBase.ponude[DataBase.ponude.Count - 1].Id + 1;
            ponuda.SaradnikId = this.saradnik.Id;
            ponuda.Saradnik = this.saradnik;
            DataBase.ponude.Add(ponuda);
            DataBase.sacuvajPonude();
            this.Close();
        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
