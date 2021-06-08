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
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class KalendarWindow : Window
    {
        public KalendarWindow()
        {
            InitializeComponent();
            Button b = new Button();
            b.Content = "asd";
            //Ponedeljak.Children.Add(b);
            
        }
    }
}
