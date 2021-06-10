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
using WpfApp1.View;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class KalendarWindow : Window
    {
        public static Stack<Proslava> deleteUndo = new Stack<Proslava>();
        public List<Proslava> proslave { get; set; }
        public int minCol, maxCol, minRow, maxRow;
        public KalendarWindow()
        {
            InitializeComponent();
            if (DataBase.trenutniKorisnik is Organizator)
            {
                proslave = (DataBase.trenutniKorisnik as Organizator).Proslave;
                Organizatori.Visibility = Visibility.Collapsed;
                Poruke.Visibility = Visibility.Collapsed;
                Obavestenja.Visibility = Visibility.Collapsed;
            }
            else
                proslave = (DataBase.trenutniKorisnik as Narucilac).Proslave;

            minCol = 2; minRow = 1; maxRow = 15; maxCol = 9;

            foreach(var proslava in proslave)
            {
                int dan = (int)proslava.DatumVreme.DayOfWeek + 1;
                if (dan == 1) dan = 8;
                int sati = proslava.DatumVreme.Hour - 6;
                sati = Math.Max(sati, 1);
                CardUserControl karta = new CardUserControl(proslava);
                karta.roditelj = this;
                Kalendar.Children.Add(karta);
                Grid.SetColumn(karta, dan);
                Grid.SetRow(karta, sati);
            }
            
        }



        public void showParentOnClose(object sender, EventArgs e)
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
            
        }

        private void poruke_on_click(object sender, RoutedEventArgs e)
        {
            ChatMeni chat = new ChatMeni((DataBase.trenutniKorisnik as Narucilac).Proslave);
            chat.Closed += showParentOnClose;
            this.Hide();
            chat.Show();

        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<ZahtevZaProslavu> zaht = null;
            if(DataBase.trenutniKorisnik is Organizator)
            {
                zaht = (DataBase.trenutniKorisnik as Organizator).Zahtevi;
            } else
            {
                zaht = (DataBase.trenutniKorisnik as Narucilac).Zahtevi;
            }
            ZahteviZaOrganizacije zahteviZaOrganizacije = new ZahteviZaOrganizacije(zaht);
            zahteviZaOrganizacije.Closed += showParentOnClose;
            this.Hide();
            zahteviZaOrganizacije.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Recnik recnik = new Recnik();
            recnik.Closed += showParentOnClose;
            recnik.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            PretragaOrganizatora pretragaOrganizatora = new PretragaOrganizatora();
            pretragaOrganizatora.Closed += showParentOnClose;
            pretragaOrganizatora.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        //undo
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (deleteUndo.Count == 0)
            {
                return;
            }
            var toDo = deleteUndo.Pop();

            //TODO UNDO ZA DELETE
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            TabelaDogadjaja tabelaDogadjaja = new TabelaDogadjaja((DataBase.trenutniKorisnik as Organizator).Proslave);
            tabelaDogadjaja.Closed += this.showParentOnClose;
            tabelaDogadjaja.Show();
            this.Hide();
        }











    }
}
