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
       
        private void Sacuvaj_Organizatora_Click(object sender, RoutedEventArgs e)
        {
            String KorisnickoIme = korIme.Text;
            String Lozinka = lozinka.Password;
            String BrTel = brTel.Text;
            String Email = email.Text;
            String Ime = ime.Text;
            String Prezime = prezime.Text;
            Double Plata = Double.Parse(plata.Text); //TODO num
            kontroler.dodajOrganizatora(KorisnickoIme,Lozinka,BrTel,Email,Ime, Prezime, Plata);


        }
    }
}
