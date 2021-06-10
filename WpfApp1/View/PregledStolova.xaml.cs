using organizerEvents.Controler;
using organizerEvents.model;
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

        public Gost Gost { get; set; }

        public Temp() { }

        public Temp(Point p, long Id, String tip, Gost gost)
        {
            this.Position = p;
            this.Id = Id;
            this.Tip = tip;
            this.Gost = gost;
        }
    }
    public partial class PregledStolova : Window
    {
     
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
            for (int i = 0; i < DataBase.trenutnaProslava.BrojGostiju; ++i)
            {
                Ellipse userCTRL = new Ellipse();
                userCTRL.Fill = Brushes.Black;
                userCTRL.Width = 20;
                userCTRL.Height = 20;
                Canvas.SetTop(userCTRL, 20);
                Canvas.SetLeft(userCTRL, 20);
                userCTRL.PreviewMouseDown += UserCTRL_PreviewMouseDown;
                CanvasMain.Children.Add(userCTRL);

                stanje.Add(userCTRL, new Temp(new Point(30, 30), 0, "Osoba", DataBase.trenutnaProslava.Gosti[i]));
            }

            for (int i = 0; i < DataBase.trenutnaProslava.Mesto.MaxBrStolova; ++i)
            {
                Ellipse userCTRL = new Ellipse();
                userCTRL.Fill = Brushes.Red;
                userCTRL.Width = 30;
                userCTRL.Height = 30;
                Canvas.SetTop(userCTRL, 60);
                Canvas.SetLeft(userCTRL, 60);
                userCTRL.PreviewMouseDown += UserCTRL_PreviewMouseDown;
                CanvasMain.Children.Add(userCTRL);
                stanje.Add(userCTRL, new Temp(new Point(60, 60), i+1, "Sto", null));
                
            }
        }

        private void ucitajPozicije()
        {
            XElement xmlData = XElement.Load("stanja.xml");
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

                Gost g = null;
                if (el.Attribute("gost").Value != "nema")
                {
                    Console.WriteLine("Aaaaaaaaaaaaaaaa");
                    Console.WriteLine(DataBase.trenutnaProslava.Gosti.Count);
                    foreach (Gost gostic in DataBase.trenutnaProslava.Gosti)
                        if (gostic.Id.ToString() == el.Attribute("gost").Value)
                        {
                            g = gostic;
                            break;
                        }
                }
                stanje.Add(userCTRL, new Temp(new Point(double.Parse(el.Attribute("x").Value),
                    double.Parse(el.Attribute("y").Value)), int.Parse(el.Value), el.Attribute("tip").Value, g));
            }
        }
        private void UserCTRL_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.dragObject = sender as UIElement;
            if (stanje[sender as UIElement].Gost != null)
                Kutija.Text = "Ime i prezime: " + stanje[sender as UIElement].Gost.Ime + " " + 
                    stanje[sender as UIElement].Gost.Prezime + ". Zahtjev: " + stanje[sender as UIElement].Gost.PosebanZahtev;
            else
                Kutija.Text = "Redni broj stola je " + stanje[sender as UIElement].Id + ".";
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
            double yCordinate = position.Y - this.offset.Y;
            double xCordinate = position.X - this.offset.X;

            if (yCordinate >= 0 && yCordinate <= CanvasMain.ActualHeight-20 && xCordinate >= 0 && xCordinate <= CanvasMain.ActualWidth-20)
            {
                Canvas.SetTop(this.dragObject, yCordinate);
                Canvas.SetLeft(this.dragObject, xCordinate);
                mainPoint.X = xCordinate;
                mainPoint.Y = yCordinate;
            }
        }

        private void CanvasMain_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            UIElement ui = this.dragObject as UIElement;
            if (ui != null)
            {
                stanje[ui].Position = new Point(mainPoint.X, mainPoint.Y);
                if (stanje[ui].Gost != null)
                {
                    if (udaljenost(ui) != 0)
                    {
                        Kutija2.Text = "Gost " + stanje[ui].Gost.Ime + " " + stanje[ui].Gost.Prezime + " je za stolom "
                        + udaljenost(ui) + ".";
                    } else
                    {
                        Kutija2.Text = "Gost " + stanje[ui].Gost.Ime + " " + stanje[ui].Gost.Prezime + " nije mu dodjeljen sto.";
                    }
                   
                       
                }
            }
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
            XElement podaci = XElement.Load("stanja.xml");

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
                new XAttribute("tip", tag.Tip),
                new XAttribute("gost", tag.Gost == null ? "nema" : tag.Gost.Id.ToString())), new XAttribute("id", DataBase.trenutnaProslava.Id.ToString()));
            podaci.Add(stanjeEl);

            using (StreamWriter output = new StreamWriter("stanja.xml"))
            {
                output.WriteLine(podaci.ToString());
            }
        }

        private long udaljenost(UIElement el)
        {
            long id = 0; // id stola najblizeg
            double minUdaljenost = Double.MaxValue;
            foreach (var item in stanje.Values)
            {
                if (item.Tip == "Sto")
                {
                    double udaljenost = Math.Sqrt((mainPoint.X - item.Position.X) * (mainPoint.X - item.Position.X)
                        + (mainPoint.Y - item.Position.Y) * (mainPoint.Y - item.Position.Y));
                    if (minUdaljenost > udaljenost)
                    {
                        minUdaljenost = udaljenost;
                        id = item.Id;
                    }
                }
            }
            if (minUdaljenost == Double.MaxValue || minUdaljenost >= 50)
            {
                id = 0;
            }
            return id;
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            this.Close();
            DataBase.LogoutProzor.Show();
            foreach (Window window in Application.Current.Windows)
            {
                if (!window.Equals((Window)DataBase.LogoutProzor))
                {
                    window.Close();
                }
            }
        }

    }

}
