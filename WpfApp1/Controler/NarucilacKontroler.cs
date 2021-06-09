using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using organizerEvents.model;
using organizerEvents.Controler;

namespace WpfApp1.Controler
{
    class NarucilacKontroler
    {
        public List<Narucilac> SviNarucioci { get; set; }

        public List<Narucilac> ucitaj()
        {
           // DataBase.inicijalizujPodatke();
            //DataBase.sacuvajNarucioce();
            //DataBase.sacuvajPodatke();
            //DataBase.ucitajPodatke();
            return DataBase.narucioci;
           /* SviNarucioci = DataBase.narucioci;

            Narucilac n1 = new Narucilac("Natasa", "Rajtarov", "natasa@gmail.com", "natasa1");
            Narucilac n2 = new Narucilac("Zorana", "Kajla", "zorana@gmail.com", "zorana1");
            Narucilac n3 = new Narucilac("Jelena", "Arsenov", "jelena@gmail.com", "jelena1");

            SviNarucioci.Add(n1);
            SviNarucioci.Add(n2);
            SviNarucioci.Add(n3);
            return SviNarucioci;*/
        }

        internal Narucilac pronadji(long v)
        {
            DataBase.ucitajPodatke();
            foreach (Narucilac n in DataBase.narucioci) {
                if (n.Id==v) { return n; } }
            return null;
        }
    }
}
