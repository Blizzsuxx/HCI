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
using organizerEvents.Controler;


namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for Obavestenja.xaml
    /// </summary>
    public partial class Obavestenja : Window
    {
        public Dictionary<String, String> zahtevi { get; set; }
        public Obavestenja()
        {
            zahtevi= DataBase.recniciPojmova.ZahteviZaRecnik;
            InitializeComponent();
            int counter = 0;
            foreach (String proslava in zahtevi.Keys)
            {
                ObavestenjaPopups zahtevUserControl = new ObavestenjaPopups(proslava,zahtevi[proslava]);
                Telo.Children.Add(zahtevUserControl);
                Grid.SetColumn(zahtevUserControl, 0);
                Grid.SetRow(zahtevUserControl, counter);
                counter++;
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.MinHeight = 50;
                Telo.RowDefinitions.Add(rowDefinition);
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
