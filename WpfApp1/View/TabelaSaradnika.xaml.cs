using organizerEvents.Controler;
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
    /// Interaction logic for TabelaSaradnika.xaml
    /// </summary>
    public partial class TabelaSaradnika : Window
    {
        public static Stack<KeyValuePair<Saradnik, DataGrid>> deleteUndo = new Stack<KeyValuePair<Saradnik, DataGrid>>();

        public Saradnik selektovan { get; set; }

        SaradnikKontroler kontroler { get; set; }
        public TabelaSaradnika()
        {
            kontroler = new SaradnikKontroler();
            DataBase.ucitajPodatke();
            InitializeComponent();
            this.Saradnici.ItemsSource = this.kontroler.ucitaj();
        }

        public void showParentOnClose(object sender, EventArgs e)
        {

            this.Show();
        }
        private void kreirajNovogSaradnika(object sender, RoutedEventArgs e)
        {
            UnosNovogSaradnika noviSaradnik = new UnosNovogSaradnika();
            noviSaradnik.Closed += showParentOnClose;
            this.Hide();
            noviSaradnik.Show();
        }

        private void selektovanjeSaradnika(object sender, MouseButtonEventArgs e)
        {
            selektovan =(Saradnik) this.Saradnici.SelectedItem;
            DataGridRow row = sender as DataGridRow;
            DetaljanPregledSaradnika detaljanPregledSaradnik = new DetaljanPregledSaradnika(this.kontroler.ucitaj()[row.GetIndex()]);
            detaljanPregledSaradnik.Closed += showParentOnClose;
            this.Hide();
            detaljanPregledSaradnik.Show();
        }
        
        //undo
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (deleteUndo.Count == 0)
            {
                return;
            }
            var org = deleteUndo.Pop();
            Console.WriteLine(org.Key.Id);
            foreach (Saradnik token in DataBase.saradnici)
            {
                Console.WriteLine(token.Id);
                if (token.Id == org.Key.Id)
                {
                    
                    token.izbrisan = false; //ili false


                    var itemsSource = org.Value.ItemsSource;
                    org.Value.ItemsSource = null; // force refresh
                    org.Value.ItemsSource = itemsSource; // force refresh
                    List<Organizator> novi = DataBase.dobaviPostojeceOrganizatore();

                    this.Saradnici.ItemsSource = novi;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.selektovan == null)
            {

                MessageBox.Show("Prvo selektujte jednog organizatora, onda kliknite dugme");
            }
            else
            {
                //todo obavesti
                deleteUndo.Push(new KeyValuePair<Saradnik, DataGrid>(this.selektovan, this.Saradnici));
                this.selektovan.izbrisan = true;
                List<Saradnik> novi = DataBase.saradnici;
                foreach (Saradnik o in novi)
                {
                    if (o.Id == this.selektovan.Id)
                    {
                        o.izbrisan = true;
                        //novi.Remove(o);
                        MessageBox.Show("Izbrisali ste saradnika: " + o.Naziv + ". Ako zelite da ga vratite kliknite undo");
                        novi = DataBase.dobaviPostojeceSaradnike();
                        break;
                    }
                }
                novi = DataBase.dobaviPostojeceSaradnike();
                this.Saradnici.ItemsSource = novi;

                
            }
        }
    }
}
