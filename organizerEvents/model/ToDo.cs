using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizerEvents.model
{
    public class ToDo
    {
        public List<Ponuda> Ponude { get; set; }
        public String OpisZadatka { get; set; }
        public Stanje StanjeZadatka { get; set; }
        public ToDo() { }
        public ToDo(List<Ponuda> ponude, String opis, Stanje stanje)
        {
            this.Ponude = ponude;
            this.OpisZadatka = opis;
            this.StanjeZadatka = stanje;
        }
    }
}
