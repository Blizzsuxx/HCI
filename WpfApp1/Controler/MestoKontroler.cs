using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using organizerEvents.model;
using organizerEvents.Controler;

namespace WpfApp1.Controler
{
    public class MestoKontroler
    {
        List<Mesto> SvaMesta { get; set; }

        public void dodajMesto(string naziv, string ulica, string broj, int ljudi, int stolovi, int posvrdina) {
            List<Sto> s = new List<Sto>();
            Mesto novo = new Mesto(naziv,broj,ulica, posvrdina,ref s,stolovi,ljudi   );
            DataBase.mesta.Add(novo);
            DataBase.sacuvajMesta();
        }
        public List<Mesto> dobaviMesta()
        {
             DataBase.ucitajMesta();
            this.SvaMesta = DataBase.mesta;
            return this.SvaMesta;


        }

    }
}
