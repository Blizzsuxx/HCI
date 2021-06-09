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

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for TabelaSaradnika.xaml
    /// </summary>
    public partial class TabelaSaradnika : Window
    {

        SaradnikKontroler kontroler { get; set; }
        public TabelaSaradnika()
        {
            kontroler = new SaradnikKontroler();
            DataBase.ucitajPodatke();
            InitializeComponent();
            this.Saradnici.ItemsSource = this.kontroler.ucitaj();
        }


        private void kreirajNovogSaradnika(object sender, RoutedEventArgs e)
        {
            UnosNovogSaradnika noviSaradnik = new UnosNovogSaradnika();
            noviSaradnik.Show();
        }

        private void selektovanjeSaradnika(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            DetaljanPregledSaradnika detaljanPregledSaradnik = new DetaljanPregledSaradnika(this.kontroler.ucitaj()[row.GetIndex()]);
            detaljanPregledSaradnik.Show();
        }
    }
}
