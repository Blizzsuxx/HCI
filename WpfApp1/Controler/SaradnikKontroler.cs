using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using organizerEvents.model;
using organizerEvents.Controler;

namespace WpfApp1.Controler
{
    public class SaradnikKontroler
    {
        List<Saradnik> saradnici { get; set; }


        public void dodajSaradnika(String naziv, String mesto, String opis, String tip) {
            //ovo dodaje admin i njemu ne trebaju saaradnici tkd ih on ne treba ccuvati kod sebe
            long id = 1;
            foreach (Saradnik s in DataBase.saradnici) {
                if (s.Id > id)
                {
                    id = s.Id;
                }
            }
            ++id;
            Saradnik novSaradnik = new Saradnik(naziv, mesto, opis, tip);
            novSaradnik.Id = id;
            DataBase.saradnici.Add(novSaradnik);
            DataBase.sacuvajSaradnike();
           
        
        }
        public List<Saradnik> ucitaj() {

            return DataBase.saradnici;

            /*
            saradnici = new List<Saradnik>();
            Saradnik s1 = new Saradnik("cvecara pcelica", "novi sad", "neki","cvecara");
            Saradnik s2 = new Saradnik("cvecara pcelica", "novi sad", "neki", "cvecara");
            Saradnik s3 = new Saradnik("cvecara pcelica", "novi sad", "neki", "cvecara");
            saradnici.Add(s1);saradnici.Add(s2);saradnici.Add(s3);

            return saradnici;*/

        }
    }
}
