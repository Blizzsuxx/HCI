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
            ScrollViewer scrollViewer = new ScrollViewer();
            StackPanel stackPanel = new StackPanel();
            telo.Children.Add(scrollViewer);
            scrollViewer.Content = stackPanel;
            Grid.SetColumn(scrollViewer, 1);
            Grid.SetRow(scrollViewer, 6);

            

            foreach(var token in (DataBase.trenutniKorisnik as Organizator).Proslave)
            {
                Expander expander = new Expander();
                expander.Header = token.Naslov;
                expander.Content = new ToDoUserControl(token.Zadaci, token);
                stackPanel.Children.Add(expander);
            }

            
            this.DataContext = this;

        }

        private void showParentOnClose(object sender, EventArgs e)
        {
            this.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AzuriranjeProfila azuriranjeProfila = new AzuriranjeProfila();
            azuriranjeProfila.Closed += showParentOnClose;
            this.Hide();
            azuriranjeProfila.Show();
        }

        private void Button_calendar(object sender, RoutedEventArgs e)
        {
            KalendarWindow azuriranjeProfila = new KalendarWindow();
            azuriranjeProfila.Closed += showParentOnClose;
            this.Hide();
            azuriranjeProfila.Show();
        }

        private void poruke_on_click(object sender, RoutedEventArgs e)
        {
            ChatMeni chat = new ChatMeni((DataBase.trenutniKorisnik as Organizator).Proslave);
            chat.Closed += showParentOnClose;
            this.Hide();
            chat.Show();

        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ZahteviZaOrganizacije zahteviZaOrganizacije = new ZahteviZaOrganizacije( (DataBase.trenutniKorisnik as Organizator).Zahtevi);
            zahteviZaOrganizacije.Closed += showParentOnClose;
            this.Hide();
            zahteviZaOrganizacije.Show();
        }
    }
}
