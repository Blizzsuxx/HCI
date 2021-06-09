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

        public long DogovorId { get; set; }

        [JsonIgnore]
        public Dogovor Dogovor { get; set; }        
        public String OpisZadatka { get; set; }
        public Stanje StanjeZadatka { get; set; }

        [JsonIgnore]
        public String ImeDogovora { get { return Dogovor?.Ime; } }

        public Boolean Odradjen
        {
            get
            {
                return StanjeZadatka.Equals(Stanje.Uradjeno);
            }
            set
            {
                if(StanjeZadatka == Stanje.Dogovoreno)
                {
                    StanjeZadatka = Stanje.Uradjeno;
                } else if (StanjeZadatka == Stanje.UProcesuDogovora)
                {
                    StanjeZadatka = Stanje.Dogovoreno;
                }
                else if (StanjeZadatka == Stanje.Odbijeno)
                {
                    StanjeZadatka = Stanje.UProcesuDogovora;
                }
                else if (StanjeZadatka == Stanje.Uradjeno)
                {
                    StanjeZadatka = Stanje.Odbijeno;
                }
            }
        }
        public ToDo() {
            
        }
        public ToDo(String opis, Stanje stanje)
        {
            this.OpisZadatka = opis;
            this.StanjeZadatka = stanje;
        }
    }
}
