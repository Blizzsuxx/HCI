using organizerEvents.model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for ZahtevUserControl.xaml
    /// </summary>
    public partial class ZahtevUserControl : UserControl
    {
        public ZahtevZaProslavu ZahtevZaProslavu { get; set; }
        public ZahtevUserControl(ZahtevZaProslavu zahtevZaProslavu)
        {
            InitializeComponent();
            this.ZahtevZaProslavu = zahtevZaProslavu;

            Naslov.Text = ZahtevZaProslavu.Naslov;
            Sadrzaj.Text = ZahtevZaProslavu.Opis;
            
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            
        }
    }
}
