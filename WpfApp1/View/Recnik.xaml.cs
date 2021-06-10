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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Recnik : Window
    {
        public Dictionary<string, string> reci;
        public Recnik()
        {
            InitializeComponent();
            if(DataBase.trenutniKorisnik is Narucilac)
            {
                dugmeZaDodavanje.Visibility = Visibility.Collapsed;
            }
            reci = DataBase.recniciPojmova.Pojmovi;
            initReci();
        }


        public void pretrazi(object sender, KeyEventArgs e)
        {
            Dictionary<string, string> pretrazeneReci = new Dictionary<string, string>();
            foreach(var par in DataBase.recniciPojmova.Pojmovi)
            {
                if (par.Key.Contains(SearchTextBox.Text))
                {
                    pretrazeneReci.Add(par.Key, par.Value);
                }
            }
            reci = pretrazeneReci;
            initReci();
        }

        private void initReci()
        {
            Telo.Children.Clear();
            Telo.RowDefinitions.Clear();
            RowDefinition rowDefinition1 = new RowDefinition();
            rowDefinition1.MaxHeight = 5;
            rowDefinition1.MaxHeight = 5;
            Telo.RowDefinitions.Add(rowDefinition1);
            Rectangle rect = new Rectangle();
            Telo.Children.Add(rect);
            Grid.SetRow(rect, 0);
            Grid.SetColumn(rect, 1);
            rect.Fill = Brushes.MediumPurple;
            Grid.SetRowSpan(rect, 10000);

            int counter = 1;
            foreach (string rec in reci.Keys)
            {
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.MinHeight = 50;
                Telo.RowDefinitions.Add(rowDefinition);
                TextBlock jednaRec = new TextBlock();
                jednaRec.Text = rec;
                jednaRec.Foreground = Brushes.MediumPurple;
                TextBlock znacenje = new TextBlock();
                jednaRec.FontSize = 18;
                znacenje.FontSize = 18;
                jednaRec.Margin = new Thickness(0, 10, 0, 10);
                znacenje.Margin = new Thickness(0, 10, 0, 10);
                jednaRec.HorizontalAlignment = HorizontalAlignment.Center;
                znacenje.HorizontalAlignment = HorizontalAlignment.Center;
                znacenje.Text = reci[rec];
                znacenje.Foreground = Brushes.MediumPurple;
                Telo.Children.Add(jednaRec);
                Telo.Children.Add(znacenje);
                Grid.SetColumn(jednaRec, 0);
                Grid.SetColumn(znacenje, 2);
                Grid.SetRow(jednaRec, counter);
                Grid.SetRow(znacenje, counter);
                
                counter++;



            }
        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DodavacReci d = new DodavacReci();
            d.Show();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            this.Close();
            DataBase.LogoutProzor.Show();
            foreach (Window window in Application.Current.Windows)
            {
                if (!window.Equals((Window)DataBase.LogoutProzor))
                {
                    window.Close();
                }
            }
        }
    }

 
}
