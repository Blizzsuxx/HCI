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
using System.Windows.Controls.Primitives;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for ToDoUserControl.xaml
    /// </summary>
    public partial class ToDoUserControl : UserControl
    {
        public List<ToDo> lista { get; set; }
        public List<Dogovor> DogovoriZaProslavu { get; set; }
        public ToDoUserControl(List<ToDo> toDos, Proslava proslava)
        {
            lista = toDos;
            if (proslava != null)
                DogovoriZaProslavu = proslava.Dogovori;
            InitializeComponent();

            zadaciGrid.ItemsSource = lista;

            var temp = this.DataContext;
            this.DataContext = null;
            this.DataContext = temp;
        }

        public void toggleClicked(object sender, RoutedEventArgs e)
        {
            (e.Source as ToggleButton).GetBindingExpression(ContentProperty).UpdateTarget();
        }

        private void zadaciGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void delete_task_on_click(object sender, MouseButtonEventArgs e)
        {
            
            UIElement element = (UIElement)zadaciGrid.InputHitTest(e.GetPosition(zadaciGrid));
            int row = Grid.GetRow(element);
            ToDo toDo = lista[row];
            lista.Remove(toDo);
            DataBase.toDos.Remove(toDo);


            zadaciGrid.ItemsSource = null;
            zadaciGrid.ItemsSource = lista;
        }
    }
}
