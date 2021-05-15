using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizerEvents.model
{
    public class ZahtevZaProslavu
    {
        public String Naslov { get; set; }
        public DateTime DatumVreme { get; set; }
        public int BrojGostiju { get; set; }
        public double Budzet { get; set; }
        public String Tip { get; set; }
        public String Mesto { get; set; }
        public String Opis { get; set; }

        public Organizator Organizator { get; set; }

        public Narucilac Narucilac { get; set; }

        public ZahtevZaProslavu()
        {

        }
        public ZahtevZaProslavu(String naslov, DateTime datum, int brGostiju, double budzet, String tip, String mesto, String opis, Narucilac narucilac, Organizator organizator)
        {
            this.Naslov = naslov;
            this.DatumVreme = datum;
            this.BrojGostiju = brGostiju;
            this.Budzet = budzet;
            this.Tip = tip;
            this.Mesto = mesto;
            this.Opis = opis;
            this.Organizator = organizator;
            this.Narucilac = narucilac;
        }
    }
}
