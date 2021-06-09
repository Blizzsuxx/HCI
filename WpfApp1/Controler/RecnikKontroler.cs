using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using organizerEvents.model;
using organizerEvents.Controler;

namespace WpfApp1.Controler
{
    public class RecnikKontroler
    {
        public RecnikPojmova recnik { get; set; }

        public bool OdobriRec(String naziv)
        {
            //DataBase.inicijalizujPodatke();
            recnik = DataBase.recniciPojmova;
            if (recnik.Pojmovi.ContainsKey(naziv)) { Console.WriteLine("da"); return false; }
            if( !recnik.ZahteviZaRecnik.ContainsKey(naziv)) { Console.WriteLine("ne"); return false; }
            recnik.Pojmovi[naziv] = recnik.ZahteviZaRecnik[naziv];
            recnik.ZahteviZaRecnik.Remove(naziv);
            return true;
        }

        internal bool izbrisiRec(string text)
        {
            recnik = DataBase.recniciPojmova;
            if (recnik.ZahteviZaRecnik.ContainsKey(text))
            {
                recnik.ZahteviZaRecnik.Remove(text);
                return true;
            }return false;
        }
    }
}
