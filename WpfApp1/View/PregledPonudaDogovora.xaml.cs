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
    /// Interaction logic for PregledPonudaDogovora.xaml
    /// </summary>
    public partial class PregledPonudaDogovora : Window
    {
        private int Indikator;
        private List<Ponuda> trenutnePonude = new List<Ponuda>();
        public PregledPonudaDogovora roditelj;
        public PregledPonudaDogovora(int indicator)
        {
            this.Indikator = indicator;
            InitializeComponent();
            if (indicator == 0)
            {
                this.inicijalizujPonude();
            }
            if (indicator == 1)
            {
                this.inicijalizujNovePonude();
            }
        }

        private void inicijalizujNovePonude()
        {
            List<Ponuda> ponude = new List<Ponuda>();
            foreach (Ponuda ponuda in DataBase.ponude)
            {
                foreach(Saradnik saradnik in (DataBase.trenutniKorisnik as Organizator).Saradnici)
                {
                    if (saradnik.Id == ponuda.Saradnik.Id && DataBase.kreiranjeDogadjajaPonude.IndexOf(ponuda) == -1)
                    {
                        ponude.Add(ponuda);
                    }
                }
            }
            Ponude.ItemsSource = ponude;
            this.trenutnePonude = ponude;
        }

        private void inicijalizujPonude()
        {

            Ponude.ItemsSource = DataBase.kreiranjeDogadjajaPonude;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PregledPonudaDogovora pregledPonudaDogovor = new PregledPonudaDogovora(1);
            pregledPonudaDogovor.roditelj = this;
            pregledPonudaDogovor.Dodavanje.Visibility = Visibility.Hidden;
            pregledPonudaDogovor.Show();
        }

        private void inbox_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Ponuda temp = (Ponuda)Ponude.SelectedItem;
            if(temp!= null)
            {
                DataBase.kreiranjeDogadjajaPonude.Add(temp);
                this.Close();
            }
           
        }

        
    }
}
