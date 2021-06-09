﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Controler;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for DodavanjeMesta.xaml
    /// </summary>
    public partial class DodavanjeMesta : Window
    {
        MestoKontroler kontroler { get; set; }
        public DodavanjeMesta()
        {
            kontroler = new MestoKontroler();
            InitializeComponent();
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            String naziv = this.NazivMesta.Text;
            String ulica = this.Ulica.Text;
            String broj = this.Broj.Text;
            int ljudi = Int32.Parse( this.brLjudi.Text);
            int stolovi = Int32.Parse(this.BrojStolova.Text);
            int posvrdina = Int32.Parse(this.PovrsinaSale.Text);
            kontroler.dodajMesto(naziv, ulica,broj,ljudi,stolovi,posvrdina);
        }
    }
}
