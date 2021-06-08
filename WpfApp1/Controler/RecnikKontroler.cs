using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using organizerEvents.model;

namespace WpfApp1.Controler
{
    public class RecnikKontroler
    {
        public RecnikPojmova recnik { get; set; }

        public bool OdobriRec(String naziv)
        {
            if (recnik.Pojmovi.ContainsKey(naziv)) { return false; }
            recnik.Pojmovi[naziv] = recnik.ZahteviZaRecnik[naziv];
            recnik.ZahteviZaRecnik.Remove(naziv);
            return true;
        }

        internal bool izbrisiRec(string text)
        {
            recnik.ZahteviZaRecnik.Remove(text);
            return true;
        }
    }
}
