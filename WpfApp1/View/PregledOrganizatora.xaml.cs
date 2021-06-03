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
using organizerEvents.model;
using WpfApp1.Controler;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class PregledOrganizatora : Window
    {
        OrganizatorKontroler kontroler { get; set; }
        public PregledOrganizatora()
        {
            InitializeComponent();

            kontroler = new OrganizatorKontroler();
            this.organizatori.ItemsSource = kontroler.dobaviSveOrganizatore();

        }

            private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
