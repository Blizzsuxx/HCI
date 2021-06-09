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

            //foreach (var proslava in (DataBase.trenutniKorisnik as Organizator).Proslave)
            //{
            //    Expander expander = new Expander();
            //    expander.Header = proslava.Naslov;
            //    zadaciStackPanel.Children.Add(expander);
            //    StackPanel expanderPanel = new StackPanel();
            //    expanderPanel.Margin = new Thickness(50, 0, 0, 0);

            //    expander.Content = expanderPanel;
            //    foreach (var zadatak in proslava.Zadaci)
            //    {
            //        Expander zadatakExpander = new Expander();

            //        zadatakExpander.Header = zadatak.OpisZadatka;

            //        StackPanel zadatakPanel = new StackPanel();
            //        zadatakExpander.Content = zadatakPanel;

            //        Grid wrapPanel = new Grid();
            //        ToggleButtonUserControl toggle = new ToggleButtonUserControl(zadatak);
            //        toggle.DataContext = this.DataContext;
            //        wrapPanel.Children.Add(toggle);
            //        wrapPanel.Children.Add(zadatakExpander);

            //        expanderPanel.Children.Add(wrapPanel);
            //        zadatakPanel.Children.Add(new ToDoUserControl(zadatak.Ponude, zadatak));
            //    }
            //}


            
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
