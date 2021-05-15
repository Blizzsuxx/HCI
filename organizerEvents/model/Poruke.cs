using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizerEvents.model
{
    public class Poruke
    {
         public Korisnik Autor { get; set; }
        public String Text { get; set; }

        public Poruke() { }
        public Poruke(Korisnik k, String text)
        {
            this.Autor = k;
            this.Text = text;
        }
    }
}
