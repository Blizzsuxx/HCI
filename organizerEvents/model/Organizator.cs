using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizerEvents.model
{
    public class Organizator: Korisnik
    {
        public double Plata { get; set; }
        public List<ZahtevZaProslavu> Zahtevi { get; set; }
        public List<Proslava> Proslave { get; set; }

        public Organizator()
        {

        }
        public Organizator(String ime, String prezime, String brojTelefona, String email, String korisnickoIme, String sifra, double plata, ref List<ZahtevZaProslavu> zahtevi,ref List<Proslava> proslave) : base(ime, prezime, brojTelefona, email, korisnickoIme, sifra)
        {
            this.Plata = plata;
            this.Zahtevi = zahtevi;
            this.Proslave = proslave;
        }
    }
}
