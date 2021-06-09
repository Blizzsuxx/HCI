using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace organizerEvents.model
{
    public class Organizator: Korisnik
    {

        public double Plata { get; set; }


        public List<long> ZahteviId { get; set; }
        [JsonIgnore]
        public List<ZahtevZaProslavu> Zahtevi { get; set; }
        public List<long> ProslaveId { get; set; }
        [JsonIgnore]
        public List<Proslava> Proslave { get; set; }
        public List<long> DogovoriId { get; set; }
        [JsonIgnore]
        public List<Dogovor> Dogovori { get; set; }

        public List<long> SaradniciID { get; set; }
        [JsonIgnore]

        public List<Saradnik> Saradnici { get; set; }

        public Organizator()
        {
            this.Proslave = new List<Proslava>();
            this.Zahtevi = new List<ZahtevZaProslavu>();
            this.Dogovori = new List<Dogovor>();
            this.Saradnici = new List<Saradnik>();
            this.ProslaveId = new List<long>();
            this.DogovoriId = new List<long>();
            this.ZahteviId = new List<long>();
            this.SaradniciID = new List<long>();
        }
        public Organizator(String ime, String prezime, String brojTelefona, String email, String korisnickoIme, String sifra, double plata, ref List<ZahtevZaProslavu> zahtevi,ref List<Proslava> proslave) : base(ime, prezime, brojTelefona, email, korisnickoIme, sifra)
        {
            this.Proslave = new List<Proslava>();
            this.Zahtevi = new List<ZahtevZaProslavu>();
            this.Dogovori = new List<Dogovor>();
            this.ProslaveId = new List<long>();
            this.DogovoriId = new List<long>();
            this.ZahteviId = new List<long>();
            this.Plata = plata;
            this.Zahtevi = zahtevi;
            this.Proslave = proslave;
        }
    }
}
