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
using organizerEvents.Controler;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class PregledOrganizatora : Window
    {
        public static Stack<KeyValuePair<Organizator, ListView>> deleteUndo = new Stack<KeyValuePair<Organizator, ListView>>();
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
                PregledJednogOrganizatora prozor = new PregledJednogOrganizatora(this.selektovan);
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
            PregledSvihMesta prozor = new PregledSvihMesta();
            prozor.Closed += new EventHandler(this.Otvori_ovaj_prozor);
            prozor.Show();
            this.Hide();
            return;

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (this.selektovan == null)
            {

                MessageBox.Show("Prvo selektujte jednog organizatora, onda kliknite dugme");
            }
            else {
                //todo obavesti
                deleteUndo.Push(new KeyValuePair<Organizator, ListView>(this.selektovan, this.organizatori));
                this.selektovan.izbrisan = true;
                List<Organizator> novi = DataBase.organizatori;
                foreach(Organizator o in novi)
                {
                    if (o.Id == this.selektovan.Id)
                    {
                        o.izbrisan = true;
                        //novi.Remove(o);
                        MessageBox.Show("Izbrisali ste organizatora: "+o.Ime+" "+o.Prezime+". Ako zelite da ga vratite kliknite undo");
                        novi = DataBase.dobaviPostojeceOrganizatore();
                        break;
                    }
                }
                novi = DataBase.dobaviPostojeceOrganizatore();
                this.organizatori.ItemsSource = novi;
                Console.WriteLine("ggggggggggggggggggggggggggggggggggggggggggggggg");
                //kontroler.obrisi(this.selektovan.Id);
                //todo ponovo obavesti
            }
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("aaaa");
            if (deleteUndo.Count == 0)
            {
                Console.WriteLine("agaa");
                return;
            }
            var org = deleteUndo.Pop();
            Console.WriteLine(org.Key.Id);
            foreach (Organizator token in DataBase.organizatori )
            {
                Console.WriteLine(token.Id);
                if (token.Id == org.Key.Id)
                {
                    Console.WriteLine("aaaa");
                    token.izbrisan = false; //ili false

                    
                    var itemsSource = org.Value.ItemsSource;
                    org.Value.ItemsSource = null; // force refresh
                    org.Value.ItemsSource = itemsSource; // force refresh
                    List<Organizator> novi = DataBase.dobaviPostojeceOrganizatore();
                   
                    this.organizatori.ItemsSource = novi;
                }
            }
        }

       

        private void bell_Click(object sender, RoutedEventArgs e)
        {
            DataBase.recniciPojmova.ZahteviZaRecnik["ketering"] = "mala skupa hrana";
            Obavestenja chat = new Obavestenja();
            chat.Closed += Otvori_ovaj_prozor;
            this.Hide();
            chat.Show();
        }

        private void trazi_Click(object sender, RoutedEventArgs e)
        {
            String input = this.search.Text;
            if (input.Equals(""))
            {
                this.organizatori.ItemsSource = null;
                this.organizatori.ItemsSource = DataBase.dobaviPostojeceOrganizatore();
            }
            else
            {
                List<Organizator> n = new List<Organizator>();
                foreach (Organizator nar in DataBase.dobaviPostojeceOrganizatore())
                {
                    if (nar.Email == null) { nar.Email = ""; }
                    if (nar.BrojTelefona== null) { nar.BrojTelefona = ""; }
                    if (nar.Email.StartsWith(input) || nar.BrojTelefona.StartsWith(input) ||
                        nar.Ime.StartsWith(input) || nar.KorisnickoIme.StartsWith(input) || nar.Prezime.StartsWith(input) 
                        )
                    {
                        n.Add(nar);
                    }
                }
                this.organizatori.ItemsSource = null;
                this.organizatori.ItemsSource = n;


            }

        }
    }
}
