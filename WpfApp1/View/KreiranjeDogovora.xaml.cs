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
    /// Interaction logic for KreiranjeDogovora.xaml
    /// </summary>
    public partial class KreiranjeDogovora : Window
    {
        public TabelaDogovora roditelj { get; set; }
        public int Indikator { get; set; }
        public Dogovor dogovor { get; set; }
        public KreiranjeDogovora(int idikator)
        {
            this.Indikator = idikator;
            InitializeComponent();
            if(this.Indikator == 1)
            {
                
                KreirajeDog.Visibility = Visibility.Hidden;
                OdustaniDog.Visibility = Visibility.Hidden;
                Ime.IsReadOnly = true;
                Opis.IsReadOnly = true;
                Komentar.IsReadOnly = true;

            }
        }

        public void inicijalizujPostojeciDogovor()
        {
            Ime.Text = this.dogovor.Ime;
            Opis.Text = this.dogovor.Opis;
            Komentar.Text = this.dogovor.Komentar;
            Stanje1.Text = this.dogovor.Stanje.ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.Indikator == 1)
            {
                PregledPonudaDogovora pregledPonudaDogovora = new PregledPonudaDogovora(2);
                pregledPonudaDogovora.Show();
            }
            else
            {
                PregledPonudaDogovora pregledPonudaDogovora = new PregledPonudaDogovora(0);
                pregledPonudaDogovora.Show();
            }
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Dogovor dogovor = new Dogovor
            {
                Id = DataBase.dogovori[DataBase.dogovori.Count - 1].Id + 1,
                Ime = Ime.Text,
                Stanje =  Stanje.Dogovaranje,
                Opis =  Opis.Text,
                Komentar = Komentar.Text
            };
            foreach(Ponuda ponuda in DataBase.kreiranjeDogadjajaPonude)
            {
                dogovor.Ponude.Add(ponuda);
                dogovor.PonudeId.Add(ponuda.Id);
            }
            dogovor.Proslava = DataBase.trenutnaProslava;
            dogovor.ProslavaId = DataBase.trenutnaProslava.Id;
            DataBase.dogovori.Add(dogovor);
            DataBase.sacuvajDogovore();
            DataBase.trenutnaProslava.Dogovori.Add(dogovor);
            DataBase.trenutnaProslava.DogovoriId.Add(dogovor.Id);
            DataBase.sacuvajProslave();
            DataBase.kreiranjeDogadjajaPonude = new List<Ponuda>();
            this.roditelj.inicijalizujDogovore();
            this.Close();
        }
    }
}
