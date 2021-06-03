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
    /// Interaction logic for PregledProslava.xaml
    /// </summary>
    public partial class PregledProslava : Window
    {
       ProslavaKontroler proslaveKontroler { get; set; }
        public PregledProslava()
        {
            InitializeComponent();
            McDataGrid.ItemsSource = pronadjiProslave();
        }

        private List<Proslava> pronadjiProslave()
        {
            this.proslaveKontroler = new ProslavaKontroler();

            List<Proslava> zaSlanje = this.proslaveKontroler.ucitaj();
            return zaSlanje;

        }
    }
}
