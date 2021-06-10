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
    /// Interaction logic for TabelaDogovora.xaml
    /// </summary>
    public partial class TabelaDogovora : Window
    {
        public List<Dogovor> dogovori { get; set; }
        public Chat ChatRoditelj { get; set; }
        public TabelaDogovora()
        {
            InitializeComponent();
            this.inicijalizujDogovore();
        }

        public void inicijalizujDogovore()
        {
            List<Dogovor> dogovori = new List<Dogovor>();
            foreach(Dogovor dogovor in DataBase.dogovori)
            {
                if (dogovor.Proslava.Id == DataBase.trenutnaProslava.Id)
                {
                    dogovori.Add(dogovor);
                }
            }
            this.dogovori = dogovori;
            Dogovori.ItemsSource = dogovori;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KreiranjeDogovora kreiranjeDogovora = new KreiranjeDogovora(0);
            kreiranjeDogovora.roditelj = this;
            this.Hide();
            kreiranjeDogovora.Show();

        }

        private void Dogovori_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            Dogovor temp = this.dogovori[row.GetIndex()];

            if (temp != null)
            {
                this.Hide();
                KreiranjeDogovora kreiranjeDogovora = new KreiranjeDogovora(1);
                kreiranjeDogovora.dogovor = temp;
                kreiranjeDogovora.roditelj = this;
                kreiranjeDogovora.inicijalizujPostojeciDogovor();
                kreiranjeDogovora.Show();


            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            try
            {


                this.ChatRoditelj.Show();
            }
            catch
            {

            }
            
        }
    }
}
