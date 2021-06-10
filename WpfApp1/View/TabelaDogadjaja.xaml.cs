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
    /// Interaction logic for TabelaDogadjaja.xaml
    /// </summary>
    public partial class TabelaDogadjaja : Window
    {

        public List<Proslava> Lista { get; set; }
        public TabelaDogadjaja(List<Proslava> proslave)
        {
            this.Lista = proslave;
            InitializeComponent();

            this.DataContext = this;
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {


            UIElement element = (UIElement)Tabela.InputHitTest(e.GetPosition(Tabela));
            int row = Grid.GetRow(element);
            Proslava proslava = Lista[row];
            DataBase.trenutnaProslava = proslava;
            ProzorZaDogadjaj prozorZaDogadjaj = new ProzorZaDogadjaj(proslava.Id);
            prozorZaDogadjaj.Show();
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
