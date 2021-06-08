using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        public long Id { get; set; }
        public Stanje Stanje { get; set; }

        public string Ime { get; set; }

        public List<long> PonudeId { get; set; }
        [JsonIgnore]
        public List<Ponuda> Ponude { get; set; }

        public long ProslavaId { get; set; }
        [JsonIgnore]
        public Proslava Proslava { get; set; }

        public Dogovor() {
            this.PonudeId = new List<long>();
            this.Ponude = new List<Ponuda>();
        
            }
        public Dogovor(Stanje stanje, ref List<Ponuda> ponude) {

            this.Stanje = stanje;
            this.Ponude = ponude;
        }
    }
}
