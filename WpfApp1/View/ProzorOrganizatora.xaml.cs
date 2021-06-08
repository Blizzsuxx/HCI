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
    /// Interaction logic for ProzorOrganizatora.xaml
    /// </summary>
    public partial class ProzorOrganizatora : Window
    {
        public ProzorOrganizatora()
        {
            InitializeComponent();

            foreach (var proslava in (DataBase.trenutniKorisnik as Organizator).Proslave)
            {
                Expander expander = new Expander();
                expander.Header = proslava.Naslov;
                telo.Children.Add(expander);
                Grid.SetColumn(expander, 1);
                Grid.SetRow(expander, 6);


            }



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Recnik r = new Recnik();
            //r.Show();
            AzuriranjeProfila azuriranjeProfila = new AzuriranjeProfila();
            azuriranjeProfila.Show();
        }

        private void Button_calendar(object sender, RoutedEventArgs e)
        {
            //Recnik r = new Recnik();
            //r.Show();
            KalendarWindow azuriranjeProfila = new KalendarWindow();
            azuriranjeProfila.Show();
        }

        private void poruke_on_click(object sender, RoutedEventArgs e)
        {

        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
