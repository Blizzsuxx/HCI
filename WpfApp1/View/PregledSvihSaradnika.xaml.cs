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

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for PregledSvihSaradnika.xaml
    /// </summary>
    public partial class PregledSvihSaradnika : Window
    {
        SaradnikKontroler kontroler { get; set; }
        public PregledSvihSaradnika()
        {
            kontroler = new SaradnikKontroler();
            InitializeComponent();
            this.Saradnici.ItemsSource = this.kontroler.ucitaj();

        }
    }
}
