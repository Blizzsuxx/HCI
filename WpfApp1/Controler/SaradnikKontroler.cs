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
            
            //long id = 1;
            //foreach (Saradnik s in DataBase.saradnici) {
            //    if (s.Id > id)
            //    {
            //        id = s.Id;
            //    }
            //}
            //++id;
            //zasto komplikovati kao gore zar nije bolje
            long id = DataBase.saradnici[DataBase.saradnici.Count - 1].Id + 1;
            Saradnik novSaradnik = new Saradnik(naziv, mesto, opis, tip);
            novSaradnik.Id = id;
            DataBase.saradnici.Add(novSaradnik);
            if(DataBase.trenutniKorisnik is Organizator)
            {
                (DataBase.trenutniKorisnik as Organizator).Saradnici.Add(novSaradnik);
                (DataBase.trenutniKorisnik as Organizator).SaradniciID.Add(novSaradnik.Id);
                DataBase.sacuvajOrganizatore();

            }
            DataBase.sacuvajSaradnike();
           
        
        }
        public List<Saradnik> ucitaj() {
            DataBase.trenutniKorisnik = DataBase.organizatori[0];
           
            //return (DataBase.trenutniKorisnik as Organizator).Saradnici;

            
            saradnici = new List<Saradnik>();
            Saradnik s1 = new Saradnik("cvecara pcelica", "novi sad", "neki","cvecara");
            Saradnik s2 = new Saradnik("cvecara pcelica", "novi sad", "neki", "cvecara");
            Saradnik s3 = new Saradnik("cvecara pcelica", "novi sad", "neki", "cvecara");
            saradnici.Add(s1);saradnici.Add(s2);saradnici.Add(s3);

            return saradnici;

        }
    }
}
