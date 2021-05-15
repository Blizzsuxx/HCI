using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizerEvents.model
{
    public class Sto
    {
        public int BrojStola { get; set; }
        public String TipStola { get; set; }
        public String Opis { get; set; }
        public int BrojLjudi { get; set; }
        public List<Gost> Gosti { get; set; }
        public Dogovor Dogovor { get; set; }


        public Sto(){}
        public Sto(int brStola, String tipS, string opis, int brLjudi, ref List<Gost> gosti, Dogovor dogovor) {
            this.BrojStola = brStola;
            this.BrojLjudi = brLjudi;
            this.TipStola = tipS;
            this.Opis = opis;
            this.Gosti = gosti;
            this.Dogovor = dogovor;


        }
    }
}
