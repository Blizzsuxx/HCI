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
using System.Xml.Linq;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for ProzorZaDogadjajKorisnika.xaml
    /// </summary>

    

    public partial class ProzorZaDogadjajKorisnika : Window
    {
        UIElement dragObject = null;
        Point offset;
        Point mainPoint;

        private Dictionary<UIElement, Temp> stanje = new Dictionary<UIElement, Temp>();

        public ProzorZaDogadjajKorisnika()
        {
            InitializeComponent();
            if (DataBase.trenutnaProslava.Raspored)
                ucitajPozicije();

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
                }
                else
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
            {
                Kutija.Text = "Ime i prezime: " + stanje[sender as UIElement].Gost.Ime + " " +
                    stanje[sender as UIElement].Gost.Prezime + ". Zahtjev: " + stanje[sender as UIElement].Gost.PosebanZahtev;

                //stanje[sender as UIElement].Position = new Point(mainPoint.X, mainPoint.Y);
                mainPoint.X = stanje[sender as UIElement].Position.X;
                mainPoint.Y = stanje[sender as UIElement].Position.Y;

                if (udaljenost(sender as UIElement) != 0)
                {
                    Kutija2.Text = "Gost " + stanje[sender as UIElement].Gost.Ime + " " + stanje[sender as UIElement].Gost.Prezime + " je za stolom "
                        + udaljenost(sender as UIElement) + ".";
                }
                else
                {
                    Kutija2.Text = "Gost " + stanje[sender as UIElement].Gost.Ime + " " + stanje[sender as UIElement].Gost.Prezime + " nije mu dodjeljen sto.";
                }
            }
            else
            {
                Kutija.Text = "Redni broj stola je " + stanje[sender as UIElement].Id + ".";
            }
                
            //this.offset = e.GetPosition(this.CanvasMain);
            //this.offset.Y -= Canvas.GetTop(this.dragObject);
            //this.offset.X -= Canvas.GetLeft(this.dragObject);
            //this.CanvasMain.CaptureMouse();

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
                    }
                    else
                    {
                        Kutija2.Text = "Gost " + stanje[ui].Gost.Ime + " " + stanje[ui].Gost.Prezime + " nije mu dodjeljen sto.";
                    }


                }
            }
            this.dragObject = null;
            this.CanvasMain.ReleaseStylusCapture();
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

        private void button_Click_gosti(object sender, RoutedEventArgs e)
        {
            PregledGostiju gosti = new PregledGostiju();
            gosti.Show();
        }

        private void button_Click_info(object sender, RoutedEventArgs e)
        {
            InfoDogadjaja info = new InfoDogadjaja();
            info.Show();
        }
    }
}
