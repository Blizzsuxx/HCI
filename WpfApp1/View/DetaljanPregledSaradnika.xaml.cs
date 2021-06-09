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
    /// Interaction logic for DetaljanPregledSaradnika.xaml
    /// </summary>
    public partial class DetaljanPregledSaradnika : Window
    {
        private  Saradnik saradnik;
        public DetaljanPregledSaradnika(Saradnik saradnik)
        {
            this.saradnik = saradnik;
            InitializeComponent();
            naziv.Text = this.saradnik.Naziv;
            mesto.Text = this.saradnik.Mesto;
            opis.Text = this.saradnik.Opis;
            tip.Text = this.saradnik.Tip;
            this.dobaviPonude();
            


        }
        private void dobaviPonude()
        {
            List<Ponuda> ponude = new List<Ponuda>();
            foreach(Ponuda ponuda in DataBase.ponude)
            {
                if(ponuda.Saradnik.Id == this.saradnik.Id)
                {
                    ponude.Add(ponuda);
                }
            }
            Ponude.ItemsSource = ponude;
        }

        private void kreirajNovuPonudu(object sender, RoutedEventArgs e)
        {
            KreiranjePonuda kreiranjePonude = new KreiranjePonuda(this.saradnik);
            kreiranjePonude.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.saradnik.Naziv=  naziv.Text;
             this.saradnik.Mesto= mesto.Text ;
             this.saradnik.Opis = opis.Text;
             this.saradnik.Tip = tip.Text ;
            
        }
    }
}
