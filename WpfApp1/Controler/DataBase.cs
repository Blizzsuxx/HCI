using organizerEvents.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace organizerEvents.Controler
{
    public class DataBase
    {

        public static List<Organizator> organizatori = new List<Organizator>();
        public static List<Administrator> administratori = new List<Administrator>();
        public static List<Dogovor> dogovori = new List<Dogovor>();
        public static List<Gost> gosti = new List<Gost>();
        public static List<Mesto> mesta = new List<Mesto>();
        public static List<Narucilac> narucioci = new List<Narucilac>();
        public static List<Ponuda> ponude = new List<Ponuda>();
        public static List<Poruke> poruke = new List<Poruke>();
        public static List<Proslava> proslave = new List<Proslava>();
        public static List<RecnikPojmova> recniciPojmova = new List<RecnikPojmova>();
        public static List<Saradnik> saradnici = new List<Saradnik>();
        public static List<Sto> stolovi = new List<Sto>();
        public static List<ToDo> toDos = new List<ToDo>();
        public static List<ZahtevZaProslavu> zahtevZaProslave =  new List<ZahtevZaProslavu>();

        public static void ucitajPodatke()
        {
           
        }

        public static void sacuvajPodatke()
        {
            
            DataBase.sacuvajOrganizatore();
            
        }

        public static  void sacuvajOrganizatore()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string organizatori = JsonSerializer.Serialize<List<Organizator>>(DataBase.organizatori, options);
            File.WriteAllText("Organizatori.json", organizatori);
        }

        public static void ucitajOrganizatore()
        {
            string organizatori = File.ReadAllText("Organizatori.json");
             DataBase.organizatori =
                JsonSerializer.Deserialize<List<Organizator>>(organizatori);
        }

        public void ucitajAdministratore()
        {
            string administratori = File.ReadAllText("Administartori.json");
            DataBase.administratori =
               JsonSerializer.Deserialize<List<Administrator>>(administratori);
        }

        public static void sacuvajAdministratore()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string administratori = JsonSerializer.Serialize<List<Administrator>>(DataBase.administratori, options);
            File.WriteAllText("Administratori.json", administratori);
        }


        public void ucitajDogovore()
        {
            string dogovor = File.ReadAllText("Dogovori.json");
            DataBase.dogovori =
               JsonSerializer.Deserialize<List<Dogovor>>(dogovor);
        }

        public static void sacuvajDogovore()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string dogovori = JsonSerializer.Serialize<List<Dogovor>>(DataBase.dogovori, options);
            File.WriteAllText("Dogovori.json", dogovori);
        }

        public void ucitajGoste()
        {
            string gosti = File.ReadAllText("Gosti.json");
            DataBase.gosti =
               JsonSerializer.Deserialize<List<Gost>>(gosti);
        }

        public static void sacuvajGoste()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string gosti = JsonSerializer.Serialize<List<Gost>>(DataBase.gosti, options);
            File.WriteAllText("Gosti.json", gosti);
        }

        public void ucitajMesta()
        {
            string mesta = File.ReadAllText("Mesta.json");
            DataBase.mesta =
               JsonSerializer.Deserialize<List<Mesto>>(mesta);
        }

        public static void sacuvajMesta()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string mesta = JsonSerializer.Serialize<List<Mesto>>(DataBase.mesta, options);
            File.WriteAllText("Mesta.json", mesta);
        }


        public void ucitajNarucioce()
        {
            string narucioci = File.ReadAllText("Narucioci.json");
            DataBase.narucioci =
               JsonSerializer.Deserialize<List<Narucilac>>(narucioci);
        }

        public static void sacuvajNarucioce()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string narucioci = JsonSerializer.Serialize<List<Narucilac>>(DataBase.narucioci, options);
            File.WriteAllText("Narucioci.json", narucioci);
        }

        public void ucitajPonude()
        {
            string ponude = File.ReadAllText("Ponude.json");
            DataBase.ponude =
               JsonSerializer.Deserialize<List<Ponuda>>(ponude);
        }

        public static void sacuvajPonude()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string ponude = JsonSerializer.Serialize<List<Ponuda>>(DataBase.ponude, options);
            File.WriteAllText("Ponude.json", ponude);
        }



        public void ucitajPoruke()
        {
            string poruke = File.ReadAllText("Poruke.json");
            DataBase.poruke =
               JsonSerializer.Deserialize<List<Poruke>>(poruke);
        }

        public static void sacuvajPoruke()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string poruke = JsonSerializer.Serialize<List<Poruke>>(DataBase.poruke, options);
            File.WriteAllText("Poruke.json", poruke);
        }


        public void ucitajProslave()
        {
            string proslave = File.ReadAllText("Proslave.json");
            DataBase.proslave =
               JsonSerializer.Deserialize<List<Proslava>>(proslave);
        }

        public static void sacuvajProslave()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string proslave = JsonSerializer.Serialize<List<Proslava>>(DataBase.proslave, options);
            File.WriteAllText("Proslave.json", proslave);
        }


        public void ucitajRecnikePojmova()
        {
            string recniciPojmova = File.ReadAllText("RecniciPojmova.json");
            DataBase.recniciPojmova =
               JsonSerializer.Deserialize<List<RecnikPojmova>>(recniciPojmova);
        }

        public static void sacuvajRecnikePojmova()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string recniciPojmova = JsonSerializer.Serialize<List<RecnikPojmova>>(DataBase.recniciPojmova, options);
            File.WriteAllText("RecniciPojmova.json", recniciPojmova);
        }


        public void ucitajSaradnike()
        {
            string saradnici = File.ReadAllText("Saradnici.json");
            DataBase.saradnici =
               JsonSerializer.Deserialize<List<Saradnik>>(saradnici);
        }

        public static void sacuvajSaradnike()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string saradnici = JsonSerializer.Serialize<List<Saradnik>>(DataBase.saradnici, options);
            File.WriteAllText("Saradnici.json", saradnici);
        }

        public void ucitajStolove()
        {
            string stolovi = File.ReadAllText("Stolovi.json");
            DataBase.stolovi =
               JsonSerializer.Deserialize<List<Sto>>(stolovi);
        }

        public static void sacuvajStolove()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string stolovi = JsonSerializer.Serialize<List<Sto>>(DataBase.stolovi, options);
            File.WriteAllText("Stolovi.json", stolovi);
        }

        public void ucitajToDos()
        {
            string toDos = File.ReadAllText("ToDos.json");
            DataBase.toDos =
               JsonSerializer.Deserialize<List<ToDo>>(toDos);
        }

        public static void sacuvajToDos()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string toDos = JsonSerializer.Serialize<List<ToDo>>(DataBase.toDos, options);
            File.WriteAllText("ToDos.json", toDos);
        }


        public void ucitajZahteveZaProslavu()
        {
            string zahtevZaProslave = File.ReadAllText("ZahteviZaProslave.json");
            DataBase.zahtevZaProslave =
               JsonSerializer.Deserialize<List<ZahtevZaProslavu>>(zahtevZaProslave);
        }

        public static void sacuvajZahteveZaProslavu()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string zahtevZaProslave = JsonSerializer.Serialize<List<ZahtevZaProslavu>>(DataBase.zahtevZaProslave, options);
            File.WriteAllText("ZahteviZaProslave.json", zahtevZaProslave);
        }

    }
}
