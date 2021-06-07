using organizerEvents.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for ToggleButtonUserControl.xaml
    /// </summary>
    public partial class ToggleButtonUserControl : UserControl
    {
        public bool Odradjen { get => !toDo.Odradjen; set { toDo.Odradjen = value; RaisePropertyChanged("Odradjen"); }  }

        public String StanjeZadatka { get => toDo.StanjeZadatka.ToString();  set { Console.WriteLine(value); RaisePropertyChanged("StanjeZadatka"); } }

        private ToDo toDo;
        public ToggleButtonUserControl(ToDo ToDo)
        {
            this.toDo = ToDo;

            InitializeComponent();


        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void RaisePropertyChanged(string propertyName)
        {
            var handlers = PropertyChanged;

            handlers(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
