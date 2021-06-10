using organizerEvents.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using organizerEvents.Controler;


namespace WpfApp1.Controler
{
    public class ProslavaKontroler
    {
        List<organizerEvents.model.Proslava> sveProslave { get; set; }

        internal List<Proslava> ucitaj()
        {
            //DataBase.ucitajPodatke();
            this.sveProslave = DataBase.proslave;
            /* this.sveProslave = new List<Proslava>();
            Proslava p1 = new Proslava(DateTime.Now, 10000, "rodjendan");
             Proslava p2 = new Proslava(DateTime.Now, 10000, "svadba");
             Proslava p3 = new Proslava(DateTime.Now, 10000, "zurka");
             this.sveProslave.Add(p1);
             this.sveProslave.Add(p2);
             this.sveProslave.Add(p3);
            this.sveProslave.Add(dobaviProslavu(1));
            this.sveProslave.Add(dobaviProslavu(1));
            this.sveProslave.Add(dobaviProslavu(1));*/
            return this.sveProslave;
        }

        internal Proslava dobaviProslavu(long id)
        {
            // DataBase.inicijalizujPodatke();
            //DataBase.ucitajPodatke();
            sveProslave = DataBase.proslave;
            foreach (Proslava p in sveProslave) {
                Console.WriteLine(p.Id);
                if (p.Id == id) {
                    return p;
                }
            }
            return null; 
            /*Proslava proslava = new Proslava();
            Narucilac narucilac = new Narucilac();
            narucilac.Ime = "Natasa";
            narucilac.Prezime = "Rajtarov";
            Organizator org = new Organizator();
            org.Ime = "Milos";
            org.Prezime = "Milinkovic";
            proslava.Narucilac = narucilac;
            proslava.Organizator = org;
            proslava.DatumVreme = DateTime.Now;
            proslava.Budzet = 900000;
            proslava.BrojGostiju = 100;
            proslava.Mesto = new Mesto();
            proslava.Mesto.NazivMesta = "2 Galeba";
            Saradnik s1 = new Saradnik(); s1.Naziv = "cvecara" ;
            Saradnik s2 = new Saradnik(); s2.Naziv = "2 galeba";
            Ponuda p = new Ponuda();
            p.Saradnik = s1;
            p.Cenovnik = new Dictionary<string, double>();
            p.Cenovnik.Add("Bele kale",40);
            p.Cenovnik.Add("Beli ljiljani", 80);
            p.Cenovnik.Add("Bele orhideje", 130);
            Ponuda p2 = new Ponuda();
            p2.Saradnik = s2;
            p2.Cenovnik = new Dictionary<string, double>();
            p2.Cenovnik.Add("1 stolica", 1000);
            p2.Cenovnik.Add("samo prostor",40000);
            Dogovor d = new Dogovor();
            
            Dogovor d2 = new Dogovor();
            
            proslava.Dogovori = new List<Dogovor>();
            proslava.Dogovori.Add(d);
            proslava.Dogovori.Add(d2); return proslava;*/
            
        }
    }
}
