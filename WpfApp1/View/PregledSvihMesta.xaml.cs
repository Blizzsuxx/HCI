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
    /// Interaction logic for PregledSvihMesta.xaml
    /// </summary>
    public partial class PregledSvihMesta : Window
    {
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

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //todo obavestenje
            if (this.selektovan == null)
            {

            }
            else
            {
                kontroler.obrisi(this.selektovan.Id);
            }
            //todo obavestenje
        }

        private void Mesta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.selektovan = (Mesto)this.Mesta.SelectedItem;
        }
    }
}
