using organizerEvents.Controler;
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
using System.Windows.Shapes;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for ZahteviZaOrganizacije.xaml
    /// </summary>
    public partial class ZahteviZaOrganizacije : Window
    {
        public List<ZahtevZaProslavu> ZahtevZaProslavu { get; set; }
        public ZahteviZaOrganizacije(List<ZahtevZaProslavu> zahtevZaProslavu)
        {
            InitializeComponent();
            this.ZahtevZaProslavu = zahtevZaProslavu;
            this.DataContext = this;
            int counter = 0;
            foreach(var zahtev in zahtevZaProslavu)
            {
                if (zahtev.Odobren == 0)
                {
                    ZahtevUserControl zahtevUserControl = new ZahtevUserControl(zahtev);
                    Telo.Children.Add(zahtevUserControl);
                    Grid.SetColumn(zahtevUserControl, 0);
                    Grid.SetRow(zahtevUserControl, counter);
                    counter++;
                    RowDefinition rowDefinition = new RowDefinition();
                    rowDefinition.MinHeight = 50;
                    Telo.RowDefinitions.Add(rowDefinition);
                }
            }
        }
        private void Logout(object sender, RoutedEventArgs e)
        {
            this.Close();
            DataBase.LogoutProzor.Show();
            foreach (Window window in Application.Current.Windows)
            {
                if (!window.Equals((Window)DataBase.LogoutProzor))
                {
                    window.Close();
                }
            }
        }
    }
}
