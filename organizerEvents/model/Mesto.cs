using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizerEvents.model
{
    public class Mesto
    {   
        public String NazivMesta { get; set; }
        public String Broj { get; set; }
        public String Ulica { get; set; }
        public double PovrsinaSale { get; set; }

        public List<Sto> Stolovi { get; set; }

        public Mesto(String nazivMesta, String broj, String ulica, double povrsinaSale, ref List<Sto> stolovi) {

            this.NazivMesta = nazivMesta;
            this.Broj = broj;
            this.Ulica = ulica;
            this.PovrsinaSale = povrsinaSale;
            this.Stolovi = stolovi;
        
        }
        public Mesto() { }

    }
}
