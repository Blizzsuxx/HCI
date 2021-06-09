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
    /// Interaction logic for UnosNovogSaradnika.xaml
    /// </summary>
    public partial class UnosNovogSaradnika : Window
    {
        private SaradnikKontroler kontroler { get; set; }
        public UnosNovogSaradnika()
        {
            kontroler = new SaradnikKontroler();
            InitializeComponent();
        }


        private void Kreiraj_Click(object sender, RoutedEventArgs e)
        {
            String ime = this.Naziv.Text;
            String opis = this.Opis.Text;
            String mesto = this.Mesto.Text;
            String tip = this.Tip.Text;
            kontroler.dodajSaradnika(ime, mesto, opis, tip);
            this.Close();

        }
    }
}
