using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace organizerEvents.model
{
    public class Mesto
    {
        public long Id { get; set; }
        public String NazivMesta { get; set; }
        public String Broj { get; set; }
        public String Ulica { get; set; }
        public double PovrsinaSale { get; set; }

        public List<long> StoloviId { get; set; }
        [JsonIgnore]
        public List<Sto> Stolovi { get; set; }

        public Mesto(String nazivMesta, String broj, String ulica, double povrsinaSale, ref List<Sto> stolovi) {
            this.Stolovi = new List<Sto>();
            this.StoloviId = new List<long>();
            this.NazivMesta = nazivMesta;
            this.Broj = broj;
            this.Ulica = ulica;
            this.PovrsinaSale = povrsinaSale;
            this.Stolovi = stolovi;
        
        }
        public Mesto() { }

    }
}
