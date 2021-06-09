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
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class Chat : Window
    {
        public Proslava proslava;
        public int brojPoruka;
        public Chat(Proslava proslava)
        {
            InitializeComponent();
            brojPoruka = 0;
            this.proslava = proslava;
            foreach (var poruka in proslava.Poruke)
            {
                this.addPoruka(poruka);
            }
        }

        private void addPoruka(Poruke poruka)
        {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = poruka.Text;
                textBlock.Background = Brushes.MediumPurple;
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.Width = 200;
                textBlock.Margin = new Thickness(0,5,0,5);
                textBlock.Foreground = Brushes.White;
                ChatBody.Children.Add(textBlock);
                var novRed = new RowDefinition();
                novRed.MinHeight = 50;
                ChatBody.RowDefinitions.Add(novRed);
                if (poruka.AutorId != DataBase.trenutniKorisnik.Id)
                {

                    Grid.SetColumn(textBlock, 0);
                    textBlock.HorizontalAlignment = HorizontalAlignment.Left;
                
                }
                else
                {
                    Grid.SetColumn(textBlock, 1);
                    textBlock.HorizontalAlignment = HorizontalAlignment.Right;
                }
                Console.WriteLine(poruka.Text);
                Console.WriteLine(poruka.AutorId == DataBase.trenutniKorisnik.Id);
                Grid.SetRow(textBlock, brojPoruka);
                
                brojPoruka++;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Poruke novaPoruka = new Poruke {AutorId = DataBase.trenutniKorisnik.Id, Autor= DataBase.trenutniKorisnik, Text=SadrzajPoruke.Text };
            this.proslava.Poruke.Add(novaPoruka);
            this.proslava.PorukeId.Add(novaPoruka.Id);
            Console.WriteLine(novaPoruka.Id);
            DataBase.poruke.Add(novaPoruka);
            addPoruka(novaPoruka);
            SadrzajPoruke.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (DataBase.trenutniKorisnik is Organizator)
            {
                TabelaDogovora dogovori = new TabelaDogovora();
                dogovori.ChatRoditelj = this;
                this.Hide();
                dogovori.Show();
            }
            else
            {
                TabelaDogovora dogovori = new TabelaDogovora();
                dogovori.ChatRoditelj = this;
                this.Hide();
                dogovori.Kreiranje.Visibility = Visibility.Hidden;
                dogovori.Show(); 
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
    }
}
