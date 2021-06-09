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
    /// Interaction logic for PregledStolova.xaml
    /// </summary>

    public partial class PregledStolova : Window
    {
        const int BROJ_GOSTIJU_MAX = 100;
        const int BROJ_STOLOVA_MAX = 10;

        const int BROJ_GOSTIJU = 0;
        const int BROJ_STOLOVA = 0;

        public PregledStolova()
        {
            InitializeComponent();
            
            for(int i = 0; i < BROJ_GOSTIJU_MAX; ++i)
            {
                Ellipse userCTRL = new Ellipse();
                userCTRL.Fill = Brushes.Black;
                userCTRL.Width = 20;
                userCTRL.Height = 20;
                Canvas.SetTop(userCTRL, 20);
                Canvas.SetLeft(userCTRL, 20);
                userCTRL.PreviewMouseDown += UserCTRL_PreviewMouseDown;
                CanvasMain.Children.Add(userCTRL);
            }

            for (int i = 0; i < BROJ_STOLOVA_MAX; ++i)
            {
                Ellipse userCTRL = new Ellipse();
                userCTRL.Fill = Brushes.Red;
                userCTRL.Width = 30;
                userCTRL.Height = 30;
                Canvas.SetTop(userCTRL, 60);
                Canvas.SetLeft(userCTRL, 60);
                userCTRL.PreviewMouseDown += UserCTRL_PreviewMouseDown;
                CanvasMain.Children.Add(userCTRL);
            }
            
            
            
        }

        UIElement dragObject = null;
        Point offset;

        private void UserCTRL_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.dragObject = sender as UIElement;
            this.offset = e.GetPosition(this.CanvasMain);
            this.offset.Y -= Canvas.GetTop(this.dragObject);
            this.offset.X -= Canvas.GetLeft(this.dragObject);
            this.CanvasMain.CaptureMouse();

        }
        private void CanvasMain_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (this.dragObject == null)
                return;
            var position = e.GetPosition(sender as IInputElement);
            Canvas.SetTop(this.dragObject, position.Y - this.offset.Y);
            Canvas.SetLeft(this.dragObject, position.X - this.offset.X);
        }

        private void CanvasMain_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            this.dragObject = null;
            this.CanvasMain.ReleaseStylusCapture();
        }

        private void button_Click_gosti(object sender, RoutedEventArgs e)
        {
            PregledGostiju gosti = new PregledGostiju();
         
            gosti.Show();
          
        }
    }
}
