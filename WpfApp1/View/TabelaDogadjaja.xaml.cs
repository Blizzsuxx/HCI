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
    }
}
