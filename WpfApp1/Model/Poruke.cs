using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace organizerEvents.model
{
    public class Poruke
    {
        public long Id { get; set; }
        public long AutorId { get; set; }
        [JsonIgnore]
        public Korisnik Autor { get; set; }
        public String Text { get; set; }

        public static long trenutniID = 1;

        public Poruke() {
            this.Id = trenutniID++;
            
        }
        public Poruke(Korisnik k, String text)
        {
            this.Autor = k;
            this.Text = text;
        }
    }
}
