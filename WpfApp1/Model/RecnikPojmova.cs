using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizerEvents.model
{
    public class RecnikPojmova
    {
        public long Id { get; set; }

        public static long SledeciId = 1;
        public Dictionary<String, String> Pojmovi { get; set; }
        public Dictionary<String, String> ZahteviZaRecnik { get; set; }

        public RecnikPojmova()
        {
            this.Id = SledeciId++;
        }
        public RecnikPojmova(ref Dictionary<String, String> pojmovi, ref Dictionary<String,String> zahtevi)
        {
            this.Pojmovi = pojmovi;
            this.ZahteviZaRecnik = zahtevi;
        }
    }
}
