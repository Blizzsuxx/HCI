using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizerEvents.model
{
    public class Ponuda //aranzman ce biti u sklopu ponude, dakle ponuda moze imati i slike :)
    {
        public String Naziv { get; set; }
        public String Opis { get; set; }

        public String Tip { get; set; }
        

        public Saradnik Saradnik { get; set; }

        public Dictionary<String, double> Cenovnik { get; set; }

        public Ponuda() { }
        public Ponuda(String naziv, String opis, String tip,  Saradnik saradnik, ref Dictionary<String, double> cenovnik) {

            this.Naziv = naziv;
            this.Opis = opis;
            this.Tip = tip;
           
            this.Saradnik = saradnik;
            this.Cenovnik = cenovnik;
        
        }
    }
}
