using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace organizerEvents.model
{
    public class ToDo
    {
        public long Id { get; set; }

        public List<long> PonudeId { get; set; }
        [JsonIgnore]
        public List<Ponuda> Ponude { get; set; }
        public String OpisZadatka { get; set; }
        public Stanje StanjeZadatka { get; set; }

        public Boolean Odradjen
        {
            get
            {
                return StanjeZadatka.Equals(Stanje.Dogovoreno);
            }
            set
            {
                StanjeZadatka = Stanje.Dogovoreno;
            }
        }
        public ToDo() {
            this.Ponude = new List<Ponuda>();
            this.PonudeId = new List<long>();
        }
        public ToDo(List<Ponuda> ponude, String opis, Stanje stanje)
        {
            this.Ponude = ponude;
            this.OpisZadatka = opis;
            this.StanjeZadatka = stanje;
        }
    }
}
