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
    /// Interaction logic for PretragaOrganizatora.xaml
    /// </summary>
    public partial class PretragaOrganizatora : Window
    {
        public List<Organizator> Lista { get; set; }
        public PretragaOrganizatora()
        {
            Lista = DataBase.organizatori;

            InitializeComponent();

        }


        private void zakazi_proslavu(object sender, MouseButtonEventArgs args)
        {
            UIElement element = (UIElement)Tabela.InputHitTest(args.GetPosition(Tabela));
            int row = Grid.GetRow(element);
        }

        private void pogledaj_profil(object sender, MouseButtonEventArgs args)
        {
            UIElement element = (UIElement)Tabela.InputHitTest(args.GetPosition(Tabela));
            int row = Grid.GetRow(element);
            PregledJednogOrganizatora pregledJednogOrganizatora = new PregledJednogOrganizatora(Lista[row]);
            pregledJednogOrganizatora.Show();
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            Lista = (from i in DataBase.organizatori where i.KorisnickoIme.Contains(Pretraga.Text) select i).ToList();
            Tabela.ItemsSource = null;
            Tabela.ItemsSource = Lista;
        }
    }
}
