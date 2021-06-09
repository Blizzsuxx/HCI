using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace organizerEvents.model
{
    public class Proslava
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

        public List<long> PorukeId { get; set; }
        [JsonIgnore]
        public List <Poruke> Poruke { get; set; }
        public List<long> ZadaciId { get; set; }
        [JsonIgnore]
        public List<ToDo> Zadaci { get; set; }
        public List<long> DogovoriId { get; set; }
        [JsonIgnore]
        public List<Dogovor> Dogovori { get; set; }
        public List<long> GodstiId { get; set; }
        [JsonIgnore]
        public List<Gost> Gosti { get; set; }

        public bool Raspored { get; set; }
        public Proslava()
        {
            this.Poruke = new List<Poruke>();
            this.PorukeId = new List<long>();
            this.Zadaci = new List<ToDo>();
            this.ZadaciId = new List<long>();
            this.Dogovori = new List<Dogovor>();
            this.DogovoriId = new List<long>();
            this.GodstiId = new List<long>();
            this.Gosti = new List<Gost>();

        }
        public Proslava(ZahtevZaProslavu zahtev) {
            this.Poruke = new List<Poruke>();
            this.PorukeId = new List<long>();
            this.Zadaci = new List<ToDo>();
            this.ZadaciId = new List<long>();
            this.Dogovori = new List<Dogovor>();
            this.DogovoriId = new List<long>();
            this.GodstiId = new List<long>();
            this.Gosti = new List<Gost>();
            this.Naslov = zahtev.Naslov;
            this.DatumVreme = zahtev.DatumVreme;
            this.Budzet = zahtev.Budzet;
            this.BrojGostiju = zahtev.BrojGostiju;
            //this.Mesto = zahtev.Mesto;
            this.Opis = zahtev.Opis;
            this.Tip = zahtev.Tip;



        }
        public Proslava(String naslov, DateTime datum, int brGostiju, double budzet, String tip, Mesto mesto, String opis, Narucilac narucilac, Organizator organizator,
            ref List<Poruke> poruke, ref List<ToDo> zadaci,ref  List<Dogovor> dogovori, ref List<Gost> gosti )
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

            this.Poruke = poruke;
            this.Zadaci = zadaci;
            this.Dogovori = dogovori;
            this.Gosti = gosti;
        }

        public Proslava(DateTime now, int budzet, String tip)
        {
            this.DatumVreme = now;
            this.Budzet = budzet;
            this.Tip = tip;
        }
    }
}
