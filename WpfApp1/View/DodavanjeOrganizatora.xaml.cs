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
            String KorisnickoIme = this.Kime.Text;
            String Lozinka = this.Lozinka.Text;
            String BrTel = this.BrTel.Text;
            String Email = this.Email.Text;
           
            String Ime = this.Ime.Text;
            String Prezime = this.Prezime.Text;
            Double Plata = Double.Parse(this.Plata.Text); //TODO num
            Console.WriteLine(KorisnickoIme); Console.WriteLine("-----------------------------------------------");
            kontroler.dodajOrganizatora(KorisnickoIme,Lozinka,BrTel,Email,Ime, Prezime, Plata);


        }

        private void odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Kime.Text = "";
            this.Lozinka.Text="";
            this.BrTel.Text="";
            this.Email.Text="";
            this.Ime.Text="";
            this.Prezime.Text="";
            this.Plata.Text = "";
        }
    }
}
