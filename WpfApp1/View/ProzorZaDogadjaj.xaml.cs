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
    /// Interaction logic for ProzorZaDogadjaj.xaml
    /// </summary>
    public partial class ProzorZaDogadjaj : Window
    {
        public ProzorZaDogadjaj(long proslava)
        {

            InitializeComponent();
            int indikator = 0;
            foreach(ToDo zadatak in DataBase.toDos)
            {
                if(zadatak.Dogovor.Proslava.Organizator.Id == DataBase.trenutniKorisnik.Id && zadatak.Dogovor.Proslava.Id==proslava)
                {
                    Expander expander = new Expander();
                    expander.Header = zadatak.OpisZadatka;
                    zadaci.Children.Add(expander);
                    var novRed = new RowDefinition();
                    novRed.MinHeight = 50;
                    zadaci.RowDefinitions.Add(novRed);
                    Grid.SetColumn(expander, 1);
                    Grid.SetRow(expander, indikator);
                    expander.HorizontalAlignment = HorizontalAlignment.Left;
                    indikator++;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TabelaSaradnika tabelaSaradnika = new TabelaSaradnika();
            tabelaSaradnika.Closed += showParentOnClose;
            this.Hide();
            tabelaSaradnika.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PregledStolova pregledStolova = new PregledStolova();
            pregledStolova.Closed+= showParentOnClose;
            this.Hide();
            pregledStolova.Show();
        }

        public void showParentOnClose(object sender, EventArgs e)
        {

            this.Show();
        }
    }
}
