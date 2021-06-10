using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace organizerEvents.model
{
    public class ZahtevZaProslavu
    {
        public long Id { get; set; }
        public String Naslov { get; set; }
        public DateTime DatumVreme { get; set; }
        public int BrojGostiju { get; set; }
        public double Budzet { get; set; }
        public String Tip { get; set; }

        public long MestoId { get; set; }
        [JsonIgnore]
        public Mesto Mesto { get; set; }
        public String Opis { get; set; }
        public long OrganizatorId { get; set; }
        [JsonIgnore]
        public Organizator Organizator { get; set; }
        public long NarucilacId { get; set; }
        [JsonIgnore]
        public Narucilac Narucilac { get; set; }

        public int Odobren { get; set; }
        public static long SledeciId = 1;
        public ZahtevZaProslavu()
        {

        }
        public ZahtevZaProslavu(String naslov, DateTime datum, int brGostiju, double budzet, String tip, Mesto mesto, String opis, Narucilac narucilac, Organizator organizator)
        {
            this.Id = SledeciId++;
            this.Odobren = 0;
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
