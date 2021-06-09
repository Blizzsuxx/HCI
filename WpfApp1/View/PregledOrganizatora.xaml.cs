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
using organizerEvents.model;
using WpfApp1.Controler;
using WpfApp1.View;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class PregledOrganizatora : Window
    {
        Organizator selektovan { get; set; }
        OrganizatorKontroler kontroler { get; set; }
        public PregledOrganizatora()
        {
            InitializeComponent();

            kontroler = new OrganizatorKontroler();
            this.organizatori.ItemsSource = kontroler.dobaviSveOrganizatore();

        }

        private void organizatori_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(this.organizatori.SelectedItem);
            this.selektovan = (Organizator)this.organizatori.SelectedItem;
        }

        private void PogledajDetaljnije_Click(object sender, RoutedEventArgs e)
        {
            if (this.selektovan == null) { }
            else
            {
                PregledJednogOrganizatora prozor = new PregledJednogOrganizatora(this.selektovan.Id);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeOrganizatora prozor = new DodavanjeOrganizatora();
            prozor.Closed += new EventHandler(this.Otvori_ovaj_prozor);
            prozor.Show();
            this.Hide();
            return;
        }

        private void Korisnici_Click(object sender, RoutedEventArgs e)
        {
            PregledKorisnika prozor = new PregledKorisnika();
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

        private void Mesta_Click(object sender, RoutedEventArgs e)
        {
           /* PregledJednogOrganizatora prozor = new PregledJednogOrganizatora(this.selektovan.Id);
            prozor.Closed += new EventHandler(this.Otvori_ovaj_prozor);
            prozor.Show();
            this.Hide();
            return;*/

        }
    }
}
