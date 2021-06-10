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
    /// Interaction logic for ProzorZaDogadjaj.xaml
    /// </summary>
    public partial class ProzorZaDogadjaj : Window
    {
        public ProzorZaDogadjaj(long proslava)
        {

            InitializeComponent();
            Proslava prosl = null;
            foreach(var pro in DataBase.proslave)
            {
                if(pro.Id == proslava)
                {
                    prosl = pro;
                }
            }
            ToDoUserControl toDoUserControl = new ToDoUserControl(prosl.Zadaci, prosl);
            zadaci.Children.Add(toDoUserControl);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TabelaSaradnika tabelaSaradnika = new TabelaSaradnika();
            tabelaSaradnika.Closed += showParentOnClose;
            this.Hide();
            tabelaSaradnika.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PregledStolova pregledStolova = new PregledStolova();
            pregledStolova.Closed+= showParentOnClose;
            this.Hide();
            pregledStolova.Show();
        }

        public void showParentOnClose(object sender, EventArgs e)
        {

            this.Show();
        }
    }
}
