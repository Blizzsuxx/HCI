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
        public static RecnikPojmova recniciPojmova = new RecnikPojmova();
        public static List<Saradnik> saradnici = new List<Saradnik>();
        public static List<Sto> stolovi = new List<Sto>();
        public static List<ToDo> toDos = new List<ToDo>();
        public static List<ZahtevZaProslavu> zahtevZaProslave =  new List<ZahtevZaProslavu>();
        public static Korisnik trenutniKorisnik;
        public static Proslava trenutnaProslava;

        public static List<Ponuda> kreiranjeDogadjajaPonude = new List<Ponuda>();

        public static void ucitajPodatke()
        {
            DataBase.ucitajAdministratore();
            DataBase.ucitajGoste();
            DataBase.ucitajSaradnike();

            DataBase.ucitajDogovore();
            DataBase.ucitajMesta();  
            DataBase.ucitajNarucioce();
            DataBase.ucitajOrganizatore();
            DataBase.ucitajPonude();
            DataBase.ucitajPoruke();
            DataBase.ucitajProslave();
            DataBase.ucitajRecnikePojmova();
            DataBase.ucitajStolove();
            DataBase.ucitajToDos();
            DataBase.ucitajZahteveZaProslavu();

            DataBase.uveziDogovore();
            DataBase.uveziMesta();
            DataBase.uveziNarucioce();
            DataBase.uveziOrganizatore();
            DataBase.uveziPonude();
            DataBase.uveziPoruke();
            DataBase.uveziProslave();
            DataBase.uveziStolove();
            DataBase.uveziToDos();
            foreach(Proslava proslava in DataBase.proslave)
            {
                if (proslava.Mesto != null)
                {
                    Console.WriteLine(proslava.Id);
                    Console.WriteLine(proslava.Mesto.NazivMesta);
                }
            }

        }
        public static void sacuvajPodatke()
        {
            sacuvajAdministratore();
            sacuvajGoste();
            sacuvajSaradnike();
            sacuvajMesta();
            sacuvajStolove();
            sacuvajDogovore();
            sacuvajNarucioce();
            sacuvajOrganizatore();
            sacuvajPonude();
            sacuvajPoruke();
            sacuvajProslave();
            sacuvajRecnikePojmova();
            sacuvajToDos();
            sacuvajZahteveZaProslavu();
        }

        internal static List<Saradnik> dobaviPostojeceSaradnike()
        {
            List<Saradnik> novi = new List<Saradnik>();
            foreach (Saradnik org in saradnici)
            {
                if (org.izbrisan == false)
                {
                    novi.Add(org);
                }
            }
            return novi;
        }

        internal static List<Mesto> dobaviPostojecaMesta()
        {
            List<Mesto> novi = new List<Mesto>();
            foreach (Mesto org in mesta)
            {
                if (org.izbrisan == false)
                {
                    novi.Add(org);
                }
            }
            return novi;
        }

        public static long dobaviKorisnikId()
        {
            long id = 0;
            foreach(Administrator admin in DataBase.administratori)
            {
                if (admin.Id > id)
                {
                    id = admin.Id;
                }
            }
            foreach (Narucilac narucilac in DataBase.narucioci)
            {
                if (narucilac.Id > id)
                {
                    id = narucilac.Id;
                }
            }

            foreach (Organizator organizator in DataBase.organizatori)
            {
                if (organizator.Id > id)
                {
                    id = organizator.Id;
                }
            }

            return id;
        }
        public static void inicijalizujPodatke()
        {
            Administrator admin = new Administrator
            {
                BrojTelefona = "1231",
                Id = 1,
                Ime = "Andrija",
                Prezime = "Vojvnovic",
                KorisnickoIme = "Andrija",
                Sifra="password"

            };
            DataBase.administratori.Add(admin);
            Gost gost = new Gost
            {
                Ime = "Marko",
                Prezime = "Markovic",
                Id = 1
            };
            DataBase.gosti.Add(gost);

            Saradnik saradnik = new Saradnik
            {
                Id = 1,
                Naziv = "Firma"
            };
            DataBase.saradnici.Add(saradnik);
            Mesto mesto = new Mesto
            {
                Id = 1,
                NazivMesta = "Prvo mjest",
                Broj = "1",
                Ulica = "Prva",
                MaxBrLjudi = 3,
                MaxBrStolova = 3

            };
            DataBase.mesta.Add(mesto);


            Sto sto = new Sto
            {
                Id = 1,
                BrojLjudi = 100,
                BrojStola = 10,
                Opis = "prvi sto"
            };
            Sto sto2 = new Sto
            {
                Id = 2,
                BrojLjudi = 100,
                BrojStola = 10,
                Opis = "drugi sto"
            };

            Dogovor dogovor = new Dogovor
            {
                Id = 1,
                Stanje = Stanje.Dogovoreno,
                ProslavaId = 11,
                Ime="Ime dogovora"
            };
            Narucilac narucilac = new Narucilac
            {
                Id = 1,
                Ime = "Nrucilac",
                Prezime = "Naruciocic",
                KorisnickoIme = "momcina",
                Sifra = "123",
                ProslaveId= new List<long>() { 11}
            };

            Organizator ogranizator = new Organizator
            {
                Id = 2,
                Ime = "Suki",
                Prezime = "Suljic",
                KorisnickoIme = "sule",
                Sifra = "123",
                ProslaveId = new List<long> { 11 },
                ZahteviId = new List<long> { 1, 2, 3}
            };
            Ponuda ponuda = new Ponuda
            {
                Id = 1,
                Naziv = "Prejaka pnuda",
                Opis = "Ne moze bolje"
            };
            Poruke poruka = new Poruke
            {
                Id = 1,
                Text = "Ovo je tako dobar sadrzaj"
            };

            Proslava proslava = new Proslava
            {
                BrojGostiju = 10,
                Id = 1,
                Budzet = 100000
            };
            RecnikPojmova recnik = new RecnikPojmova
            {
                Id = 2,
                ZahteviZaRecnik = new Dictionary<string, string>(),
                Pojmovi = new Dictionary<string, string>() { { "a", "b" }, {"REC", "definicija reci je" }, { "c", "b" }, { "d", "definicija reci je" }, { "e", "b" }, { "f", "definicija reci je" } }
            };
            ToDo zadatak = new ToDo
            {
                Id = 2,
                OpisZadatka = "Ovo je inicijalni zadatak",
                DogovorId=1
            };
            ZahtevZaProslavu zahtevZaProslavu = new ZahtevZaProslavu
            {
                Id = 1,
                Opis = "Zahtjev",
                Naslov = "Ovo je naslov",
                DatumVreme = DateTime.Now,
                BrojGostiju = 15,
                Budzet = 1222.2,
                NarucilacId = 1,
                OrganizatorId = 2,
                Tip = "Sahrana",
                Mesto =new Mesto
                {
                    Id=10,
                    NazivMesta="Prvo mjesto"
                }
            };
            ZahtevZaProslavu zahtevZaProslavu2 = new ZahtevZaProslavu
            {
                Id = 2,
                Opis = "Zahtjev",
                Naslov = "Ovo je naslov1231231",
                DatumVreme = DateTime.Now,
                BrojGostiju = 11,
                Budzet = 1222.2,
                NarucilacId = 1,
                OrganizatorId = 2,
                Tip = "Svadba",
                Mesto = new Mesto
                {
                    Id = 10,
                    NazivMesta = "Prvo mjesto"
                }
            };
            ZahtevZaProslavu zahtevZaProslavu3 = new ZahtevZaProslavu
            {
                Id = 3,
                Opis = "Zahtjev",
                Naslov = "Ovo je asd",
                DatumVreme = DateTime.Now,
                BrojGostiju = 152,
                Budzet = 12312.12,
                NarucilacId = 1,
                OrganizatorId = 2,
                Tip = "Rodjendan",
                Mesto = new Mesto
                {
                    Id = 10,
                    NazivMesta = "Prvo mjesto"
                }
            };




            Poruke poruka11 = new Poruke
            {
                Id = 2,
                Text = "E sta radis",
                AutorId = 2
            };
            Poruke poruka12 = new Poruke
            {
                Id = 3,
                Text = "Ma pusti me",
                AutorId = 1
            };
            Poruke poruka13 = new Poruke
            {
                Id = 4,
                Text = "Radim HCI",
                AutorId = 1
            };
            Poruke poruka14 = new Poruke
            {
                Id = 5,
                Text = "OOF, RIP, sto nisi ranije poceo da radis",
                AutorId = 2
            };
            Poruke poruka15 = new Poruke
            {
                Id = 6,
                Text = ";-;",
                AutorId = 1
            };

            Gost g1 = new Gost(1, "Marko", "Bjelica", "Zelim sto 1", "123");
            Gost g2 = new Gost(2, "Dragan", "Arsic", "Zelim sto 1", "123");
            Gost g3 = new Gost(3, "Natasa", "Rajtarov", "Zelim sto 1", "123");

            DataBase.gosti.Add(g1);
            DataBase.gosti.Add(g2);
            DataBase.gosti.Add(g3);

            Proslava novaProslava =new Proslava { OrganizatorId=2, Id=11, ZadaciId = new List<long> { 11 }, Opis="opis proslave", Naslov="Naslov Proslave", PorukeId = new List<long> { 2, 3, 4, 5, 6}, DatumVreme=DateTime.Now,
             DogovoriId = new List<long> { 1 }, NarucilacId=1 , GodstiId = new List<long> { 1, 2, 3}, BrojGostiju = 3};

            ToDo novTodo = new  ToDo { Id=11, OpisZadatka="Opis Zadatka", StanjeZadatka=Stanje.Uradjeno, DogovorId=1};
            Ponuda novaPonuda = new Ponuda { Id=11, Naziv = "naziv", Opis = "Opis" };

            DataBase.zahtevZaProslave.Add(zahtevZaProslavu);
            DataBase.zahtevZaProslave.Add(zahtevZaProslavu2);
            DataBase.zahtevZaProslave.Add(zahtevZaProslavu3);
            DataBase.narucioci.Add(narucilac);
            DataBase.toDos.Add(zadatak);
            DataBase.toDos.Add(novTodo);
            DataBase.recniciPojmova = (recnik);
            novaProslava.Mesto = mesto;
            novaProslava.MestoId = mesto.Id;
            DataBase.proslave.Add(proslava);
            DataBase.proslave.Add(novaProslava);

            DataBase.poruke.Add(poruka);
            DataBase.poruke.Add(poruka11);
            DataBase.poruke.Add(poruka12);
            DataBase.poruke.Add(poruka13);
            DataBase.poruke.Add(poruka14);
            DataBase.poruke.Add(poruka15);

            DataBase.ponude.Add(novaPonuda);
            DataBase.organizatori.Add(ogranizator);
            DataBase.dogovori.Add(dogovor);
            DataBase.stolovi.Add(sto);
            DataBase.stolovi.Add(sto2);
            mesto.Stolovi.Add(sto);
            mesto.StoloviId.Add(sto.Id);
            mesto.Stolovi.Add(sto2);
            mesto.StoloviId.Add(sto2.Id);
            
            

        }

        internal static List<Organizator> dobaviPostojeceOrganizatore()
        {
            List<Organizator> novi = new List<Organizator>();
            foreach(Organizator org in organizatori)
            {
                if (org.izbrisan == false)
                {
                    novi.Add(org);
                }
            }return novi ;
        }

        private static void uveziToDos()
        {
            foreach(ToDo todo in DataBase.toDos)
            {
                foreach(Dogovor dogovor in DataBase.dogovori)
                {
                    if(dogovor.Id == todo.DogovorId)
                    {
                        todo.Dogovor = dogovor;
                    }
                }
            }
        }

        private static void uveziStolove()
        {
            foreach(Sto sto in DataBase.stolovi)
            {
                foreach (long gostId in sto.GostiId)
                {
                    foreach (Gost gost in DataBase.gosti)
                    {
                        if (gost.Id == gostId)
                        {
                            sto.Gosti.Add(gost);
                        }
                    }
                }

                
                    foreach (Dogovor dogovor in DataBase.dogovori)
                    {
                        
                        if (dogovor.Id == sto.DogovorId)
                        {
                        sto.Dogovor = dogovor;
                        }
                    }
                
            }
        }

        private static void uveziProslave()
        {
            foreach(Proslava proslava in DataBase.proslave)
            {
                foreach(Mesto mesto in DataBase.mesta)
                {
                    if(mesto.Id == proslava.MestoId)
                    {
                        proslava.Mesto = mesto;
                    }
                }
                foreach(long porukaId in proslava.PorukeId)
                {
                    foreach (Poruke poruke in DataBase.poruke)
                    {
                        Console.WriteLine(poruke.Text);

                        if (poruke.Id == porukaId)
                        {
                            proslava.Poruke.Add(poruke);
                        }
                    }
                }

                foreach (long zadatakId in proslava.ZadaciId)
                {
                    foreach (ToDo zadatak in DataBase.toDos)
                    {
                        if (zadatak.Id == zadatakId)
                        {
                            proslava.Zadaci.Add(zadatak);
                        }
                    }
                }


                foreach (long dogovorId in proslava.DogovoriId)
                {
                    foreach (Dogovor dogovor in DataBase.dogovori)
                    {
                        if (dogovor.Id == dogovorId)
                        {
                            proslava.Dogovori.Add(dogovor);
                        }
                    }
                }

                foreach (long gostId in proslava.GodstiId)
                {
                    foreach (Gost gost in DataBase.gosti)
                    {
                        if (gost.Id == gostId)
                        {
                            proslava.Gosti.Add(gost);
                        }
                    }
                }
            }
        }

        private static void uveziPoruke()
        {
           foreach(Poruke poruke in DataBase.poruke)
            {
                foreach(Administrator admin in DataBase.administratori)
                {
                    if (poruke.AutorId == admin.Id)
                    {
                        poruke.Autor = (Korisnik)admin;
                    }
                }
                foreach(Narucilac   gost in DataBase.narucioci)
                {
                    if(poruke.AutorId == gost.Id)
                    {
                        poruke.Autor = (Korisnik)gost;
                    }
                }
                foreach (Organizator ogranizator in DataBase.organizatori)
                {
                    if (poruke.AutorId == ogranizator.Id)
                    {
                        poruke.Autor = (Korisnik)ogranizator;
                    }
                }

            }
        }

        private static void uveziPonude()
        {
            foreach(Ponuda ponuda in DataBase.ponude){
                foreach(Saradnik saradnik in DataBase.saradnici)
                {
                    if (ponuda.SaradnikId == saradnik.Id)
                    {
                        ponuda.Saradnik = saradnik;
                    }
                }
            }
        }

        private static void uveziOrganizatore()
        {
            foreach(Organizator organizator in DataBase.organizatori)
            {
                foreach(long zahtevId in organizator.ZahteviId)
                {
                    foreach (ZahtevZaProslavu zahtev in DataBase.zahtevZaProslave)
                    {
                        if (zahtev.Id == zahtevId)
                        {
                            if (organizator.Zahtevi == null) { organizator.Zahtevi = new List<ZahtevZaProslavu>(); }
                            organizator.Zahtevi.Add(zahtev);
                            zahtev.Organizator = organizator;
                        }
                    }


                }
                foreach(long saradnikId  in organizator.SaradniciID)
                {
                    foreach(Saradnik saradnik in DataBase.saradnici)
                    {
                        if(saradnik.Id== saradnikId)
                        {
                            organizator.Saradnici.Add(saradnik);
                        }
                    }
                }
                foreach (long proslavaId in organizator.ProslaveId)
                {

                    foreach (Proslava proslava in DataBase.proslave)
                    {
                        if (proslava.Id == proslavaId)
                        {
                            organizator.Proslave.Add(proslava);
                            proslava.Organizator = organizator;
                        }
                    }
                }

                foreach(long dogovorId in organizator.DogovoriId)
                {
                    foreach (Dogovor dogovor in DataBase.dogovori)
                    {
                        if (dogovor.Id == dogovorId)
                        {
                            organizator.Dogovori.Add(dogovor);
                        }
                    }
                }
            }
        }

        private static void uveziNarucioce()
        {
           foreach(Narucilac narucilac in DataBase.narucioci)
            {
                foreach(long zahtevId in narucilac.ZahteviId)
                {
                    foreach(ZahtevZaProslavu zahtev in DataBase.zahtevZaProslave)
                    {
                        if (zahtev.Id == zahtevId)
                        {
                            narucilac.Zahtevi.Add(zahtev);
                            zahtev.Narucilac = narucilac;
                        }
                    }
                }
                foreach (long proslavaId in narucilac.ProslaveId)
                {
                    foreach (Proslava proslava in DataBase.proslave)
                    {
                        if (proslava.Id == proslavaId)
                        {
                            narucilac.Proslave.Add(proslava);
                            proslava.Narucilac = narucilac;
                        }
                    }
                }
            }
        }

        private static void uveziMesta()
        {
            foreach(Mesto mesto in DataBase.mesta){
                foreach(long stoId in mesto.StoloviId)
                {
                    foreach(Sto sto in DataBase.stolovi)
                    {
                        if (stoId == sto.Id)
                        {
                            mesto.Stolovi.Add(sto);
                        }
                    }
                }
            }
        }

        private static void uveziDogovore()
        {
            //setovane ponude u podogovrima
           foreach(Dogovor dogovor in DataBase.dogovori){
               
                    foreach (long ponudaId in dogovor.PonudeId)
                    {
                        foreach (Ponuda ponuda in DataBase.ponude)
                        {
                            if (ponuda.Id == ponudaId)
                            {
                            dogovor.Ponude.Add(ponuda);
                            }
                        }
                    }
                    foreach(Proslava prosla in DataBase.proslave)
                    {
                        if(prosla.Id == dogovor.ProslavaId)
                    {
                        dogovor.Proslava = prosla;
                    }
                    }
            }

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

        public static void ucitajAdministratore()
        {
            string administratori = File.ReadAllText("Administratori.json");
            DataBase.administratori =
               JsonSerializer.Deserialize<List<Administrator>>(administratori);
        }

        public static void sacuvajAdministratore()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string administratori = JsonSerializer.Serialize<List<Administrator>>(DataBase.administratori, options);
            File.WriteAllText("Administratori.json", administratori);
        }


        public static void ucitajDogovore()
        {
            string dogovor = File.ReadAllText("Dogovori.json");
            DataBase.dogovori =
               JsonSerializer.Deserialize<List<Dogovor>>(dogovor);
            foreach(var token in dogovori)
            {
                Dogovor.trenutniId = Math.Max(token.Id, Dogovor.trenutniId);
            }
        }

        public static void sacuvajDogovore()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string dogovori = JsonSerializer.Serialize<List<Dogovor>>(DataBase.dogovori, options);
            File.WriteAllText("Dogovori.json", dogovori);
        }

        public static void ucitajGoste()
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

        public static  void ucitajMesta()
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


        public static void ucitajNarucioce()
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

        public static void ucitajPonude()
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



        public static void ucitajPoruke()
        {
            string poruke = File.ReadAllText("Poruke.json");
            DataBase.poruke =
               JsonSerializer.Deserialize<List<Poruke>>(poruke);
            foreach(var poruka in DataBase.poruke)
            {
                Poruke.trenutniID = Math.Max(Poruke.trenutniID, poruka.Id);
            }
        }

        public static void sacuvajPoruke()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string poruke = JsonSerializer.Serialize<List<Poruke>>(DataBase.poruke, options);
            File.WriteAllText("Poruke.json", poruke);
        }


        public static void ucitajProslave()
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


        public static void ucitajRecnikePojmova()
        {
            string recniciPojmova = File.ReadAllText("RecniciPojmova.json");
            DataBase.recniciPojmova =
               JsonSerializer.Deserialize<RecnikPojmova>(recniciPojmova);
        }

        public static void sacuvajRecnikePojmova()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string recniciPojmova = JsonSerializer.Serialize<RecnikPojmova>(DataBase.recniciPojmova, options);
            File.WriteAllText("RecniciPojmova.json", recniciPojmova);
        }


        public static void ucitajSaradnike()
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

        public static void ucitajStolove()
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

        public static void ucitajToDos()
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


        public static void ucitajZahteveZaProslavu()
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

        public static Korisnik nadjiKorisnika(string username)
        {
            foreach (var admin in administratori)
            {
                if (admin.KorisnickoIme.Equals(username))
                {
                    return admin;
                }

            }
            foreach (var organuzator in organizerEvents.Controler.DataBase.organizatori)
            {
                if (organuzator.KorisnickoIme.Equals(username))
                {
                    return organuzator;
                }

            }
            foreach (var narucioci in organizerEvents.Controler.DataBase.narucioci)
            {
                if (narucioci.KorisnickoIme.Equals(username))
                {
                    return narucioci;
                }

            }
            return null;
        }


        public static Korisnik nadjiKorisnika(string username, string password)
        {
            foreach (var admin in administratori)
            {
                if (admin.KorisnickoIme.Equals(username) && password.Equals(admin.Sifra))
                {
                    
                    return admin;
                }

            }
            foreach (var organuzator in organizerEvents.Controler.DataBase.organizatori)
            {
                Console.WriteLine(organuzator.KorisnickoIme);
                if (organuzator.KorisnickoIme.Equals(username) && password.Equals(organuzator.Sifra))
                {
                    return organuzator;
                }

            }
            foreach (var narucioci in organizerEvents.Controler.DataBase.narucioci)
            {
                Console.WriteLine(narucioci.KorisnickoIme + " - " + username);
                if (narucioci.KorisnickoIme.Equals(username) && password.Equals(narucioci.Sifra))
                {
                    return narucioci;
                }

            }
            return null;
        }

    }
}
