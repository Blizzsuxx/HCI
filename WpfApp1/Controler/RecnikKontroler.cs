﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using organizerEvents.model;
using organizerEvents.Controler;

namespace WpfApp1.Controler
{
    public class RecnikKontroler
    {
        public RecnikPojmova recnik { get; set; }

        public bool OdobriRec(String naziv)
        {
            DataBase.inicijalizujPodatke();
            recnik = DataBase.recniciPojmova.First();
            if (recnik.Pojmovi.ContainsKey(naziv) || !recnik.ZahteviZaRecnik.ContainsKey(naziv)) { return false; }
            recnik.Pojmovi[naziv] = recnik.ZahteviZaRecnik[naziv];
            recnik.ZahteviZaRecnik.Remove(naziv);
            return true;
        }

        internal bool izbrisiRec(string text)
        {
            recnik = DataBase.recniciPojmova.First();
            if (recnik.ZahteviZaRecnik.ContainsKey(text))
            {
                recnik.ZahteviZaRecnik.Remove(text);
                return true;
            }return false;
        }
    }
}
