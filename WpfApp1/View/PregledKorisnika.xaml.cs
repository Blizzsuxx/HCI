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
    /// Interaction logic for PregledKorisnika.xaml
    /// </summary>
    public partial class PregledKorisnika : Window
    {
       NarucilacKontroler narucilackontroler { get; set; }

        public PregledKorisnika()
        {
            narucilackontroler = new NarucilacKontroler();

            InitializeComponent();
            this.Korisnici.ItemsSource = narucilackontroler.ucitaj();

        }


        
       
    }
}
