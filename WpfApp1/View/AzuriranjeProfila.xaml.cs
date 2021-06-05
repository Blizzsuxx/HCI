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
    /// Interaction logic for AzuriranjeProfila.xaml
    /// </summary>
    public partial class AzuriranjeProfila : Window
    {
        public AzuriranjeProfila()
        {
            InitializeComponent();
        }

        private void SacuvajPromene_Click(object sender, RoutedEventArgs e)
        {
            String Ime = ime.Text;
            String Prezime = prezime.Text;
            String BrTel = brTel.Text;
            String KorisnickoIme = korIme.Text;
            String Email = email.Text;
            String Lozinka = lozinka.Text;

        }

        private void Odbaci_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
