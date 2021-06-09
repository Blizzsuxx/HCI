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
    /// Interaction logic for ChatMeni.xaml
    /// </summary>
    public partial class ChatMeni : Window
    {
        public List<Proslava> Proslave { get; set; }
        public ChatMeni(List<Proslava> proslave)
        {
            InitializeComponent();
            this.Proslave = proslave;
            this.DataContext = this;
            int counter = 0;
            foreach (var proslava in Proslave)
            {
                ChatPopupsUserControl zahtevUserControl = new ChatPopupsUserControl(proslava);
                Telo.Children.Add(zahtevUserControl);
                Grid.SetColumn(zahtevUserControl, 0);
                Grid.SetRow(zahtevUserControl, counter);
                counter++;
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.MinHeight = 50;
                Telo.RowDefinitions.Add(rowDefinition);
            }
        }
    }
}
