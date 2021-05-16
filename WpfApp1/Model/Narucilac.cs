using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizerEvents.model
{
    public class Narucilac: Korisnik
    {
        public List<ZahtevZaProslavu> Zahtevi { get; set; }
        public List<Proslava> Proslave { get; set; }

        public Narucilac()
        {

        }
        public Narucilac(String ime, String prezime, String brojTelefona, String email, String korisnickoIme, String sifra,  ref List<ZahtevZaProslavu> zahtevi, ref List<Proslava> proslave) : base(ime, prezime, brojTelefona, email, korisnickoIme, sifra)
        {
            
            this.Zahtevi = zahtevi;
            this.Proslave = proslave;
        }
    }
}
