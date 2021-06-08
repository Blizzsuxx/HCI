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
using WpfApp1.View;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class KalendarWindow : Window
    {
        public List<Proslava> proslave { get; set; }
        public int minCol, maxCol, minRow, maxRow;
        public bool[,] zauzetaMesta = new bool[10,16];
        public KalendarWindow()
        {
            InitializeComponent();
            if (DataBase.trenutniKorisnik is Organizator)
                proslave = (DataBase.trenutniKorisnik as Organizator).Proslave;
            else
                proslave = (DataBase.trenutniKorisnik as Narucilac).Proslave;

            minCol = 2; minRow = 1; maxRow = 15; maxCol = 9;

            foreach(var proslava in proslave)
            {
                int dan = (int)proslava.DatumVreme.DayOfWeek + 1;
                if (dan == 1) dan = 8;
                int sati = proslava.DatumVreme.Hour - 6;

                CardUserControl karta = new CardUserControl(proslava);
                
                Kalendar.Children.Add(karta);
                Grid.SetColumn(karta, dan);
                Grid.SetRow(karta, sati);
                zauzetaMesta[dan,sati] = true;
            }
            for(int i = minCol; i < maxCol; i++)
            {
                for(int j = minRow; j < maxRow; j++)
                {
                    if (zauzetaMesta[i, j]) continue;
                    PlusButtonUserControl plusButtonUserControl = new PlusButtonUserControl();
                    Kalendar.Children.Add(plusButtonUserControl);
                    Grid.SetColumn(plusButtonUserControl, i);
                    Grid.SetRow(plusButtonUserControl, j);
                }
            }
        }
    }
}
