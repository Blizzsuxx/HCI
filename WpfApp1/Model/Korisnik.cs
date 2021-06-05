using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizerEvents.model
{
    public abstract class Korisnik
    {   
        public String Ime { get; set; }
        public long Id { get; set; }
        public String Prezime { get; set; }
        public String BrojTelefona { get; set; }
        public String Email { get; set; }
        public String KorisnickoIme { get; set; }
        public String Sifra { get; set; }

        public Korisnik() { }
        public Korisnik(String ime, String prezime, String brojTelefona, String email, String korisnickoIme, String sifra) 
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.BrojTelefona = brojTelefona;
            this.Email = email;
            this.KorisnickoIme = korisnickoIme;
            this.Sifra = sifra;
        }

    }
}
