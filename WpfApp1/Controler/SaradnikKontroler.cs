using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using organizerEvents.model;

namespace WpfApp1.Controler
{
    public class SaradnikKontroler
    {
        List<Saradnik> saradnici { get; set; }


        public void dodajSaradnika(String naziv, String mesto, String opis, String tip) {
            saradnici = new List<Saradnik>();
            Saradnik novSaradnik = new Saradnik(naziv, mesto, opis, tip);
            
            Console.WriteLine(novSaradnik.Naziv);
            saradnici.Add(novSaradnik);
        
        }
        public List<Saradnik> ucitaj() {

            saradnici = new List<Saradnik>();
            Saradnik s1 = new Saradnik("cvecara pcelica", "novi sad", "neki","cvecara");
            Saradnik s2 = new Saradnik("cvecara pcelica", "novi sad", "neki", "cvecara");
            Saradnik s3 = new Saradnik("cvecara pcelica", "novi sad", "neki", "cvecara");
            saradnici.Add(s1);saradnici.Add(s2);saradnici.Add(s3);

            return saradnici;

        }
    }
}
