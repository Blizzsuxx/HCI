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
        public CardUserControl(Proslava proslava)
        {
            InitializeComponent();
            this.proslava = proslava;
            text.Text = proslava.Naslov;
        }

        public void doubleClicked(object sender, MouseButtonEventArgs e)
        {
            PregledJedneProslave pregledJedneProslave = new PregledJedneProslave(proslava.Id);
            pregledJedneProslave.Show();
        }
    }
}
