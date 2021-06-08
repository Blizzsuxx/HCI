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
        public Recnik()
        {
            InitializeComponent();

            RecnikModel.reci.Add(new RecnikModel { Rec = "Baba", Opis = "Stara zena" });
           
        }



       

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DodavacReci d = new DodavacReci();
            d.Show();
        }
    }

    public class RecnikModel
    {
        public static List<RecnikModel> reci = new List<RecnikModel>();
        public String Rec { get; set; }
        public String Opis { get; set; }
    }
}
