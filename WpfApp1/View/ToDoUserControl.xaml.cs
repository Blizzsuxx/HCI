using organizerEvents.model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for ToDoUserControl.xaml
    /// </summary>
    public partial class ToDoUserControl : UserControl
    {
        public List<Ponuda> lista { get; set; }

        public ToDoUserControl(List<Ponuda> ponude)
        {
            InitializeComponent();
            lista = ponude;

            

            zadaciGrid.ItemsSource = lista;
        }

        private void zadaciGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void delete_task_on_click(object sender, MouseButtonEventArgs e)
        {
            
            UIElement element = (UIElement)zadaciGrid.InputHitTest(e.GetPosition(zadaciGrid));
            int row = Grid.GetRow(element);
            lista.RemoveAt(row);
            zadaciGrid.ItemsSource = null;
            zadaciGrid.ItemsSource = lista;
        }
    }
}
