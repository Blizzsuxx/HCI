using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace organizerEvents.model
{
    public class Sto
    {
        public long Id { get; set; }
        public int BrojStola { get; set; }
        public String TipStola { get; set; }
        public String Opis { get; set; }
        public int BrojLjudi { get; set; }

        public List<long> GostiId { get; set; }
        [JsonIgnore]
        public List<Gost> Gosti { get; set; }

        public long DogovorId { get; set; }

        [JsonIgnore]
        public Dogovor Dogovor { get; set; }
        public static long SledeciId = 1;

        public Sto(){
            this.Id = SledeciId++;
            this.Gosti = new List<Gost>();
            this.GostiId = new List<long>();
           
        
        }
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
