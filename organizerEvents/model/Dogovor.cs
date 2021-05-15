using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizerEvents.model
{
    public enum Stanje
    {
        Dogovoreno,
        Uradjeno,
        Odbijeno,
        UProcesuDogovora
    }
    public class Dogovor
    {
        public Stanje Stanje { get; set; }
        public Ponuda Ponuda { get; set; }

        public Dogovor() { }
        public Dogovor(Stanje stanje, ref Ponuda ponude) {

            this.Stanje = stanje;
            this.Ponuda = ponude;
        }
    }
}
