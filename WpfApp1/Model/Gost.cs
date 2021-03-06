using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizerEvents.model
{
    public class Gost
    {
        public long Id { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public String PosebanZahtev{ get; set; }
        public String BrTelefona { get; set; }

        public static long SledeciId = 1;

        public Gost() { this.Id = SledeciId++; }
        public Gost(String ime, String prezime, String pZahtev, String brTelefona) {
            this.Ime = ime;
            this.Prezime = prezime;
            this.PosebanZahtev = pZahtev;
            this.BrTelefona = brTelefona;
        }

        public Gost(long Id, String ime, String prezime, String pZahtev, String brTelefona)
        {
            this.Id = Id;
            this.Ime = ime;
            this.Prezime = prezime;
            this.PosebanZahtev = pZahtev;
            this.BrTelefona = brTelefona;
        }

    }
}
