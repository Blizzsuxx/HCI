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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for CardUserControl.xaml
    /// </summary>
    public partial class CardUserControl : UserControl
    {
        public Proslava proslava { get; set; }
        public KalendarWindow roditelj { get; set; }
        public CardUserControl(Proslava proslava)
        {
            InitializeComponent();
            this.proslava = proslava;
            text.Text = proslava.Naslov;
        }

        public void doubleClicked(object sender, MouseButtonEventArgs e)
        {
            if (DataBase.trenutniKorisnik is Organizator)
            {
                ProzorZaDogadjaj pregledJedneProslave = new ProzorZaDogadjaj(proslava.Id);
                DataBase.trenutnaProslava = proslava;
                this.roditelj.Hide();
                pregledJedneProslave.Closed += this.roditelj.showParentOnClose;
                pregledJedneProslave.Show();
            } else
            {
                ProzorZaDogadjajKorisnika prozorZaDogadjajKorisnika = new ProzorZaDogadjajKorisnika();
                DataBase.trenutnaProslava = proslava;
                this.roditelj.Hide();
                prozorZaDogadjajKorisnika.Closed += this.roditelj.showParentOnClose;
                prozorZaDogadjajKorisnika.Show();
            }
        }
    }
}
