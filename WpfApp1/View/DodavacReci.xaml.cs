using organizerEvents.Controler;
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
using WpfApp1.Controler;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    /// 
    
    public partial class DodavacReci : Window
    {
        public string Rec { get; set; }
        public string Opis { get; set; }
        public DodavacReci()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DuplicateValidator duplicateValidator = new DuplicateValidator();
                Validator.validate(Rec, duplicateValidator);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("Uspesno ste zabelezili rec! Ako bude bila prihvacena, bice dodata");
            DataBase.recniciPojmova.ZahteviZaRecnik.Add(Rec, Opis);
        }
    }
}
