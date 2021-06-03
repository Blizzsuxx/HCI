using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using organizerEvents.model.ZahteviZaProslavu;


namespace WpfApp1.Controler
{
    public class OrganizatorKontroler
    {
        List<organizerEvents.model.Organizator> SviOrganizatori { get; set; } //TODO mozda hes i sacuvaj
        
        public bool dodajOrganizatora(String KorisnickoIme, String Lozinka, String BrTel, String Email, String Ime, String Prezime, double plata )
        {

            foreach(organizerEvents.model.Organizator org in SviOrganizatori) {
                if (org.Email.Equals(Email))
                {
                    List<organizerEvents.model.ZahtevZaProslavu> zahtevi = new List<organizerEvents.model.ZahtevZaProslavu>();
                    List<organizerEvents.model.Proslava> proslave = new List<organizerEvents.model.Proslava>();
                    organizerEvents.model.Organizator novOrganizator = new organizerEvents.model.Organizator(Ime, Prezime, BrTel, Email, KorisnickoIme, Lozinka, plata, ref zahtevi,ref proslave);
                    SviOrganizatori.Add(novOrganizator);
                    break;
                }
            }
            
            
            return true;
        }

    }
}
