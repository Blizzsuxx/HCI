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
using organizerEvents.Controler;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for PregledSvihMesta.xaml
    /// </summary>
    public partial class PregledSvihMesta : Window
    {

        public static Stack<KeyValuePair<Mesto, ListView>> deleteUndo = new Stack<KeyValuePair<Mesto, ListView>>();

        public Mesto selektovan { get; set; }
        public MestoKontroler kontroler { get; set; }
        public PregledSvihMesta()
        {
            kontroler = new MestoKontroler();
            InitializeComponent();
            this.Mesta.ItemsSource = kontroler.dobaviMesta();
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeMesta prozor = new DodavanjeMesta();
            prozor.Closed += new EventHandler(this.Otvori_ovaj_prozor);
            prozor.Show();
            this.Hide();
            return;
        }
        private void Otvori_ovaj_prozor(object sender, System.EventArgs e)
        {
            this.Show();
        }

       

        private void Mesta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.selektovan = (Mesto)this.Mesta.SelectedItem;
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (this.selektovan == null)
            {

                MessageBox.Show("Prvo selektujte mesto koje zelite da izbrisete, onda kliknite dugme za brisanje.");
            }
            else
            {
                //todo obavesti
                deleteUndo.Push(new KeyValuePair<Mesto, ListView>(this.selektovan, this.Mesta));
                this.selektovan.izbrisan = true;
                List<Mesto> novi = DataBase.mesta;
                foreach (Mesto o in novi)
                {
                    if (o.Id == this.selektovan.Id)
                    {
                        o.izbrisan = true;
                        //novi.Remove(o);
                        MessageBox.Show("Izbrisali ste mesto: "+o.NazivMesta+". Ako zelite da ga vratite kliknite undo.");
                        novi = DataBase.dobaviPostojecaMesta();
                        break;
                    }
                }
                novi = DataBase.dobaviPostojecaMesta();
                this.Mesta.ItemsSource = novi;
               
                //kontroler.obrisi(this.selektovan.Id);
                //todo ponovo obavesti
            }
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
           
            if (deleteUndo.Count == 0)
            {
                
                return;
            }
            var org = deleteUndo.Pop();
            Console.WriteLine(org.Key.Id);
            foreach (Mesto token in DataBase.mesta)
            {
                Console.WriteLine(token.Id);
                if (token.Id == org.Key.Id)
                {
                    Console.WriteLine("aaaa");
                    token.izbrisan = false; //ili false


                    var itemsSource = org.Value.ItemsSource;
                    org.Value.ItemsSource = null; // force refresh
                    org.Value.ItemsSource = itemsSource; // force refresh
                    List<Mesto> novi = DataBase.dobaviPostojecaMesta();

                    this.Mesta.ItemsSource = novi;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.selektovan == null) { MessageBox.Show("Prvo selektujte mesto"); }
            else
            {
                AzuriranjeMesta prozor =new AzuriranjeMesta(this.selektovan);
                prozor.Closed += new EventHandler(this.Otvori_ovaj_prozor);
                prozor.Show();
                this.Hide();
                return;
            }
        }
    }
}
