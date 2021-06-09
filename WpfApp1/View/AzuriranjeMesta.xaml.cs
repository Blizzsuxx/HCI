using System;
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
using organizerEvents.model;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for AzuriranjeMesta.xaml
    /// </summary>
    public partial class AzuriranjeMesta : Window
    {
        Mesto m { get; set; }
        MestoKontroler kontroler { get; set; }
        public AzuriranjeMesta(Mesto mesto )
        {
            m = mesto;
            kontroler = new MestoKontroler();
            InitializeComponent();
            this.NazivMesta.Text=m.NazivMesta;
             this.Ulica.Text=m.Ulica;
            this.Broj.Text = m.Broj ;
            this.PovrsinaSale.Text = m.PovrsinaSale+"";
            this.BrojStolova.Text = m.MaxBrStolova + "";
            this.brLjudi.Text = m.MaxBrLjudi+"";
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            String naziv = this.NazivMesta.Text;
            String ulica = this.Ulica.Text;
            String broj = this.Broj.Text;
            int ljudi = Int32.Parse(this.brLjudi.Text);
            int stolovi = Int32.Parse(this.BrojStolova.Text);
            int posvrdina = Int32.Parse(this.PovrsinaSale.Text);
            kontroler.AzurirajMesto(m.Id,naziv, ulica, broj, ljudi, stolovi, posvrdina);
        }
    }
}
