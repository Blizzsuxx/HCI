using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizerEvents.model
{
    public class Saradnik
    {
        public long Id { get; set; }
        public String Naziv { get; set; }
        public String Mesto { get; set; }
        public String Opis { get; set; }
        public String Tip { get; set; }

        public Saradnik() { }
        public Saradnik(String naziv, String mesto, String opis, String tip)
        {
            this.Opis = opis;
            this.Tip = tip;
            this.Naziv = naziv;
            this.Mesto = mesto;
        }
    }
}
