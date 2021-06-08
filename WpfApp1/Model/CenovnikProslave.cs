using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class CenovnikProslave //Ovu klasu koristi samo natasa trenutno, i ne treba je dirati, ucitavati ili upisivati u fajl!!!!!
    {

        public String naziv { get; set; }
        public Double cena { get; set; }

        public CenovnikProslave(String naziv, double cena)
        {
            this.naziv = naziv;
            this.cena = cena;

        }
        public CenovnikProslave() { }
    }
}
