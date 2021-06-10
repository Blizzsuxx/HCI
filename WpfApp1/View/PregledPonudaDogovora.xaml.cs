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
    /// 
    class TempPonuda
    {
        public Ponuda Ponuda { get; set; }
        public String Stanje { get; set; }

    }
    public partial class PregledPonudaDogovora : Window
    {
        private int Indikator;
        private List<Ponuda> trenutnePonude = new List<Ponuda>();
        public PregledPonudaDogovora roditelj;
        public KreiranjeDogovora roditeljKreiranje;

        public Dogovor dogovor { get; set; }
        public PregledPonudaDogovora(int indicator)
        {
            this.Indikator = indicator;
            InitializeComponent();
            Odbijanje.Visibility = Visibility.Hidden;
            if (indicator == 0)
            {
                this.inicijalizujPonude();
                
            }
            if (indicator == 1)
            {
                this.inicijalizujNovePonude();
            }
            if (indicator == 2)
            {
                if(DataBase.trenutniKorisnik is Organizator)
                {
                    Dodavanje.Visibility = Visibility.Hidden;
                }
                else
                {
                    Dodavanje.ToolTip = "Prihvati ponudu";
                    Odbijanje.Visibility = Visibility.Visible;
                }
            }
            
        }

        public void inicijalizujKreiranDogovor()
        {
            List<TempPonuda> tempPonude = new List<TempPonuda>();
            foreach(Ponuda ponuda in dogovor.Ponude)
            {
                tempPonude.Add(new TempPonuda
                {
                    Ponuda = ponuda,
                    Stanje =  dogovor.StanjaPonuda[ponuda.Id]
                });
            }
            Ponude.ItemsSource = tempPonude;
            if (dogovor.Stanje == Stanje.Odbijeno)
            {
                Odbijanje.Visibility = Visibility.Hidden;
                Dodavanje.Visibility = Visibility.Hidden;
                return;
            }
            
            foreach(Ponuda ponuda in dogovor.Ponude)
            {
                if(dogovor.StanjaPonuda[ponuda.Id]== "Prihvaceno")
                {
                    Odbijanje.Visibility = Visibility.Hidden;
                    Dodavanje.Visibility = Visibility.Hidden;
                }
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

            List<TempPonuda> tempPonude = new List<TempPonuda>();
            foreach (Ponuda ponuda in ponude)
            {
                tempPonude.Add(new TempPonuda
                {
                    Ponuda = ponuda,
                    Stanje = "Nije dodato"
                });
            }
            Ponude.ItemsSource = tempPonude;
            this.trenutnePonude = ponude;
        }

        public void inicijalizujPonude()
        {
            List<TempPonuda> tempPonude = new List<TempPonuda>();
            foreach (Ponuda ponuda in DataBase.kreiranjeDogadjajaPonude)
            {
                tempPonude.Add(new TempPonuda
                {
                    Ponuda = ponuda,
                    Stanje = "Nije dodato"
                });
            }
            Ponude.ItemsSource = tempPonude;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.Indikator != 2)
            {
                PregledPonudaDogovora pregledPonudaDogovor = new PregledPonudaDogovora(1);
                pregledPonudaDogovor.roditelj = this;

                pregledPonudaDogovor.Dodavanje.Visibility = Visibility.Hidden;
                this.Hide();
                pregledPonudaDogovor.Show();
            }
            else
            {
                TempPonuda temp = (TempPonuda)Ponude.SelectedItem;
                if (temp != null)
                {
                    this.dogovor.Stanje = Stanje.Dogovoreno;
                    this.dogovor.SelektovanaPonuda = temp.Ponuda;
                    this.dogovor.SelektovanaPonudaId = temp.Ponuda.Id;
                    this.dogovor.StanjaPonuda[temp.Ponuda.Id] = "Prihvaceno";
                    this.roditeljKreiranje.PromjeniStatus();
                    DataBase.sacuvajDogovore();
                    this.Close();
                }
            }
        }

        private void inbox_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TempPonuda temp = (TempPonuda)Ponude.SelectedItem;
            if(temp!= null)
            {
                DataBase.kreiranjeDogadjajaPonude.Add(temp.Ponuda);
                this.roditelj.inicijalizujPonude();
                this.Close();
            }
           
        }

        private void Odbijanje_Click(object sender, RoutedEventArgs e)
        {
            TempPonuda temp = (TempPonuda)Ponude.SelectedItem;
            if (temp != null)
            {
                
                
             
                this.dogovor.StanjaPonuda[temp.Ponuda.Id] = "Odbijeno";

                bool odbijeno = true;
                foreach (Ponuda ponuda in this.dogovor.Ponude)
                {
                    if (this.dogovor.StanjaPonuda[ponuda.Id] != "Odbijeno")
                    {
                        odbijeno = false;
                    }
                }
                if(odbijeno)
                    this.dogovor.Stanje = Stanje.Odbijeno;
                DataBase.sacuvajDogovore();
                this.Close();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.roditelj != null)
            {

                try
                {

                    
                    this.roditelj.Show();
                }
                catch
                {

                }

                
            }
            if(this.roditeljKreiranje!= null)
            {
                try
                {


                    this.roditeljKreiranje.Show();
                }
                catch
                {

                }
              
            }
        }
    }
}
