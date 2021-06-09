using organizerEvents.Controler;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Linq;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for PregledStolova.xaml
    /// </summary>

    public class Temp
    {
        public Point Position { get; set; }
        public long Id { get; set; }

        public String Tip { get; set; } // OSOBA ILI STO
        public Temp() { }

        public Temp(Point p, long Id, String tip)
        {
            this.Position = p;
            this.Id = Id;
            this.Tip = tip;
        }
    }
    public partial class PregledStolova : Window
    {
        const int BROJ_GOSTIJU_MAX = 5;
        const int BROJ_STOLOVA_MAX = 2;

        const int BROJ_GOSTIJU = 0;
        const int BROJ_STOLOVA = 0;

        UIElement dragObject = null;
        Point offset;
        Point mainPoint;

        private Dictionary<UIElement, Temp> stanje = new Dictionary<UIElement, Temp>();

        public PregledStolova()
        {
            InitializeComponent();

            if (!DataBase.trenutnaProslava.Raspored)
                inicijalnePozicije();
            else
                ucitajPozicije();
        }

        private void inicijalnePozicije()
        {
            for (int i = 0; i < BROJ_GOSTIJU_MAX; ++i)
            {
                Ellipse userCTRL = new Ellipse();
                userCTRL.Fill = Brushes.Black;
                userCTRL.Width = 20;
                userCTRL.Height = 20;
                Canvas.SetTop(userCTRL, 20);
                Canvas.SetLeft(userCTRL, 20);
                userCTRL.PreviewMouseDown += UserCTRL_PreviewMouseDown;
                CanvasMain.Children.Add(userCTRL);

                stanje.Add(userCTRL, new Temp(new Point(30, 30), 0, "Osoba"));
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

                stanje.Add(userCTRL, new Temp(new Point(60, 60), 0, "Sto"));
            }
        }

        private void ucitajPozicije()
        {
            XElement xmlData = XElement.Load("..\\..\\resources\\stanja.xml");
            var odgovarajuceStanje = xmlData.Descendants("stanje").First(x => x.Attribute("id").Value == DataBase.trenutnaProslava.Id.ToString());
            Console.WriteLine(odgovarajuceStanje);
            var objekti = odgovarajuceStanje.Descendants("objekat");
            foreach (var el in objekti)
            {
                Ellipse userCTRL = new Ellipse();
                if (el.Attribute("tip").Value == "Osoba")
                {
                    userCTRL.Fill = Brushes.Black;
                    userCTRL.Width = 20;
                    userCTRL.Height = 20;
                } else
                {
                    userCTRL.Fill = Brushes.Red;
                    userCTRL.Width = 30;
                    userCTRL.Height = 30;
                }
                Canvas.SetTop(userCTRL, double.Parse(el.Attribute("y").Value));
                Canvas.SetLeft(userCTRL, double.Parse(el.Attribute("x").Value));
                userCTRL.PreviewMouseDown += UserCTRL_PreviewMouseDown;
                CanvasMain.Children.Add(userCTRL);

                stanje.Add(userCTRL, new Temp(new Point(double.Parse(el.Attribute("x").Value),
                    double.Parse(el.Attribute("y").Value)), 0, el.Attribute("tip").Value));
            }
        }
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
            mainPoint.X = position.X - this.offset.X;
            mainPoint.Y = position.Y - this.offset.Y;
        }

        private void CanvasMain_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            UIElement ui = this.dragObject as UIElement;
            if (ui != null)
                stanje[ui].Position = new Point(mainPoint.X, mainPoint.Y);

            this.dragObject = null;
            this.CanvasMain.ReleaseStylusCapture();
        }

        private void button_Click_gosti(object sender, RoutedEventArgs e)
        {
            PregledGostiju gosti = new PregledGostiju();
            gosti.Show();
        }

        private void button_Click_sacuvaj(object sender, RoutedEventArgs e)
        {
            DataBase.trenutnaProslava.Raspored = true;

            sacuvajUXml();
        }

        private void sacuvajUXml()
        {
            XElement podaci = XElement.Load("..\\..\\resources\\stanja.xml");

            var stanja = podaci.Descendants("stanje").FirstOrDefault(
                x => x.Attribute("id").Value == DataBase.trenutnaProslava.Id.ToString());

            if (stanja != null)
                podaci.Descendants("stanje").FirstOrDefault(x => x.Attribute("id").Value == DataBase.trenutnaProslava.Id.ToString()).Remove();

            XElement stanjeEl =
                new XElement("stanje",
                from tag in stanje.Values
                where tag is Temp
                select
                new XElement("objekat", tag.Id,
                new XAttribute("x", tag.Position.X),
                new XAttribute("y", tag.Position.Y),
                new XAttribute("tip", tag.Tip)), new XAttribute("id", DataBase.trenutnaProslava.Id.ToString()));
            podaci.Add(stanjeEl);

            using (StreamWriter output = new StreamWriter("..\\..\\resources\\stanja.xml"))
            {
                output.WriteLine(podaci.ToString());
            }
        }
    }

}
