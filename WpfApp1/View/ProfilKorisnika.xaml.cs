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
using organizerEvents.Controler;
using System.Windows.Shapes;
using WpfApp1.Controler;
using organizerEvents.model;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for ProfilKorisnika.xaml
    /// </summary>
    public partial class ProfilKorisnika : Window
    {
        NarucilacKontroler kontroler { get; set; }
        public ProfilKorisnika(long id)
        {
            kontroler = new NarucilacKontroler();
            InitializeComponent();
            Narucilac n = kontroler.pronadji(id);
            if (n != null) {
                this.kIme.Text = n.KorisnickoIme;
                this.Ime.Text = n.Ime;
                this.Prezime.Text = n.Prezime;
                this.BrTelefona.Text = n.BrojTelefona;
                if (n.Proslave != null) { 
                this.BrProslava.Text = n.Proslave.Count + "";}
                this.Email.Text = n.Email; }
        }
    }
}
