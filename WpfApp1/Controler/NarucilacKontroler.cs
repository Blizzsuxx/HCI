using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Controler
{
    class NarucilacKontroler
    {
        public List<organizerEvents.model.Narucilac> SviNarucioci { get; set; }

        public List<organizerEvents.model.Narucilac> ucitaj()
        {
            SviNarucioci = new List<organizerEvents.model.Narucilac>();

            organizerEvents.model.Narucilac n1 = new organizerEvents.model.Narucilac("Natasa", "Rajtarov", "natasa@gmail.com", "natasa1");
            organizerEvents.model.Narucilac n2 = new organizerEvents.model.Narucilac("Zorana", "Kajla", "zorana@gmail.com", "zorana1");
            organizerEvents.model.Narucilac n3 = new organizerEvents.model.Narucilac("Jelena", "Arsenov", "jelena@gmail.com", "jelena1");

            SviNarucioci.Add(n1);
            SviNarucioci.Add(n2);
            SviNarucioci.Add(n3);
            return SviNarucioci;
        }



    }
}
