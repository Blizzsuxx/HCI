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
    /// Interaction logic for InfoDogadjaja.xaml
    /// </summary>
    public partial class InfoDogadjaja : Window
    {
        public InfoDogadjaja()
        {
            InitializeComponent();
            Proslava proslava = DataBase.trenutnaProslava;
            Naziv.Text = proslava.Naslov;
            Datum.Text = proslava.DatumVreme.ToString();
            Gosti.Text = proslava.BrojGostiju.ToString();
            Budzet.Text = proslava.Budzet.ToString();
            Tip.Text = proslava.Tip;
            Mesto.Text = proslava.Mesto.NazivMesta;
            Organizator.Text = proslava.Organizator.KorisnickoIme;
        }
    }
}
