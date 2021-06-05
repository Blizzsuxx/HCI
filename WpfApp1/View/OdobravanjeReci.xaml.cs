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
    /// Interaction logic for OdobravanjeReci.xaml
    /// </summary>
    public partial class OdobravanjeReci : Window
    {
        RecnikKontroler Kontroler { get; set; }

        public OdobravanjeReci()
        {
            InitializeComponent();
            this.naziv.Text = "prva rec"; //todo notice
            this.opis.Text= Kontroler.recnik.ZahteviZaRecnik["prvarec"];
        }

        private void sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            bool uspelo=Kontroler.OdobriRec(this.naziv.Text);

        }
    }
}
