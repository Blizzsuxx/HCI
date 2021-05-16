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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ZadaciWindow : Window
    {
        public ZadaciWindow()
        {
            InitializeComponent();
            List<ZadatakModel> lista = new List<ZadatakModel>();
            ZadatakModel m1 = new ZadatakModel();
            ZadatakModel m2 = new ZadatakModel();
            ZadatakModel m3 = new ZadatakModel();
            m1.Odradjen = true;
            m2.Odradjen = false;
            m3.Odradjen = true;
            m1.Ime = "zasadi cvece";
            m2.Ime = "vataj zijale";
            m3.Ime = "napravi listu";
            lista.Add(m1);
            lista.Add(m2);
            lista.Add(m3);
            zadaciGrid.ItemsSource = lista;
        }

        private void zadaciGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        public class ZadatakModel
        {
            public bool Odradjen { get; set; }

            public string Ime { get; set; }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KalendarWindow w = new KalendarWindow();
            w.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Recnik r = new Recnik();
            r.Show();
        }
    }
}
