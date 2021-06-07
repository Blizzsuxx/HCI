using organizerEvents.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using organizerEvents.model.ZahteviZaProslavu;


namespace WpfApp1.Controler
{
    public class OrganizatorKontroler
    {
        List<Organizator> SviOrganizatori { get; set; } //TODO mozda hes i sacuvaj
        
        public bool dodajOrganizatora(String KorisnickoIme, String Lozinka, String BrTel, String Email, String Ime, String Prezime, double plata )
        {
            if (SviOrganizatori == null) { SviOrganizatori = new List<Organizator>(); }
            foreach(Organizator org in SviOrganizatori) {
                if (org.Email.Equals(Email))
                {
                    List<ZahtevZaProslavu> zahtevi = new List<ZahtevZaProslavu>();
                    List<Proslava> proslave = new List<Proslava>();
                    Organizator novOrganizator = new Organizator(Ime, Prezime, BrTel, Email, KorisnickoIme, Lozinka, plata, ref zahtevi,ref proslave);
                    SviOrganizatori.Add(novOrganizator);
                    break;
                }
            }
            
            
            return true;
        }

        internal IEnumerable dobaviSveOrganizatore()
        {
            this.SviOrganizatori = new List<Organizator>();
            this.SviOrganizatori.Add(nabaviOrg("a"));
            this.SviOrganizatori.Add(nabaviOrg("a"));
            return this.SviOrganizatori;
        }

        internal Organizator nabaviOrg(string v)
        {
            Organizator nov = new Organizator();
            nov.BrojTelefona = "090090990";
            nov.Email = v;
            nov.Ime = "Sanja";
            nov.KorisnickoIme = "sanja1";
            nov.Plata = 70000;
            nov.Prezime = "Simic";
            Proslava p = new Proslava();
            p.BrojGostiju = 40;
            p.Mesto = new Mesto();p.Mesto.NazivMesta = "2 galeba";
            p.DatumVreme = DateTime.Now;

            Proslava p2 = new Proslava();
            p2.BrojGostiju = 40;
            p2.Mesto = new Mesto(); p2.Mesto.NazivMesta = "3 sesira";
            p2.DatumVreme = DateTime.Now;
            nov.Proslave = new List<Proslava>();
            nov.Proslave.Add(p);
            nov.Proslave.Add(p2);
            return nov;
        }
    }
}
