using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace organizerEvents.model
{
    public class Narucilac: Korisnik
    {
       
        public List<long> ZahteviId { get; set; }
        [JsonIgnore]
        public List<ZahtevZaProslavu> Zahtevi { get; set; }

        public List<long> ProslaveId { get; set; }
        [JsonIgnore]
        public List<Proslava> Proslave { get; set; }

        public Narucilac()
        {
            this.Zahtevi = new List<ZahtevZaProslavu>();
            this.ZahteviId = new List<long>();
            this.Proslave = new List<Proslava>();
            this.ProslaveId = new List<long>();
        }
        public Narucilac(String ime, String prezime, String brojTelefona, String email, String korisnickoIme, String sifra,  ref List<ZahtevZaProslavu> zahtevi, ref List<Proslava> proslave) : base(ime, prezime, brojTelefona, email, korisnickoIme, sifra)
        {
            
            this.Zahtevi = zahtevi;
            this.Proslave = proslave;
        }

        public Narucilac(string ime, string prezime, string email, string korisnickoIme)
        {
            this.Proslave = new List<Proslava>();
            this.ProslaveId = new List<long>();
            this.Zahtevi = new List<ZahtevZaProslavu>();
            this.ZahteviId = new List<long>();
            this.Ime = ime;
            this.Prezime = prezime;
            this.Email = email;
            this.KorisnickoIme = korisnickoIme;
        }
    }
}
