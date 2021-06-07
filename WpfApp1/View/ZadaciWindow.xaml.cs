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
using System.Collections.ObjectModel;
using organizerEvents.model;
using organizerEvents.Controler;
using WpfApp1.View;
using System.Windows.Controls.Primitives;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    /// 





    public partial class ZadaciWindow : Window
    {
        public ZadaciWindow()
        {
            InitializeComponent();
            List<Proslava> proslave = new List<Proslava>();
            proslave.Add(new Proslava { Zadaci = new List<ToDo>(), Opis="opis proslave", Naslov="Naslov Proslave" });
            proslave[0].Zadaci.Add(new ToDo { Ponude= new List<Ponuda>(), OpisZadatka="Opis Zadatka", StanjeZadatka=Stanje.Uradjeno});
            proslave[0].Zadaci[0].Ponude.Add(new Ponuda { Naziv = "naziv", Opis = "Opis" });
            foreach(var proslava in proslave)
            {
                Expander expander = new Expander();
                expander.Header = proslava.Naslov;
                zadaciStackPanel.Children.Add(expander);
                StackPanel expanderPanel = new StackPanel();
                expanderPanel.Margin = new Thickness(50, 0, 0, 0);
                
                expander.Content = expanderPanel;
                foreach(var zadatak in proslava.Zadaci)
                {
                    Expander zadatakExpander = new Expander();
                    
                    zadatakExpander.Header = zadatak.OpisZadatka;
                    
                    StackPanel zadatakPanel = new StackPanel();
                    zadatakExpander.Content = zadatakPanel;

                    Grid wrapPanel = new Grid();
                    ToggleButtonUserControl toggle = new ToggleButtonUserControl(zadatak);
                    toggle.DataContext = this.DataContext;
                    wrapPanel.Children.Add(toggle);
                    wrapPanel.Children.Add(zadatakExpander);

                    expanderPanel.Children.Add(wrapPanel);
                    zadatakPanel.Children.Add(new ToDoUserControl(zadatak.Ponude));
                }
            }


        }

        




        

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Recnik r = new Recnik();
            r.Show();

        }

        private void poruke_on_click(object sender, RoutedEventArgs e)
        {

        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            
        }
    }

    public class ZadatakModel
    {
        public bool Odradjen { get; set; }

        public string Ime { get; set; }

    }


}
