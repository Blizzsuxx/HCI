using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizerEvents.model
{
    public class Administrator: Korisnik
    {
        public Administrator()
        {

        }
        public Administrator(String ime, String prezime, String brojTelefona, String email, String korisnickoIme, String sifra): base(ime, prezime, brojTelefona, email, korisnickoIme, sifra)
        {
           
        }
    }
}
