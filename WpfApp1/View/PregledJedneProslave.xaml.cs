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
using WpfApp1.Model;
using organizerEvents.model;
using System.ComponentModel;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for PregledJedneProslave.xaml
    /// </summary>
    public partial class PregledJedneProslave : Window
    {
        ProslavaKontroler kontroler { get; set; }
        public PregledJedneProslave(long id)
        {
            
            InitializeComponent();
            dobaviInfoProslave(id);
            ConnectionViewModel vm = new ConnectionViewModel();
            DataContext = vm;
        }

        private void dobaviInfoProslave(long id)
        {
            
            kontroler = new ProslavaKontroler(); //Todo ili proslediti ili da se dobije neki id
            Proslava p = kontroler.dobaviProslavu(id);
            
            if (p != null)
            {
                if (p.Narucilac != null && p.Organizator!=null)
                {
                    this.org.Text = p.Organizator.Ime + " " + p.Organizator.Prezime;
                    this.kIme.Text = p.Narucilac.Ime + " " + p.Narucilac.Prezime;
                }
               
                
                this.Datum.Text = p.DatumVreme + "";
                this.brGostiju.Text = p.BrojGostiju + "";
                this.mesto.Text = p.Mesto.NazivMesta;
                this.budzet.Text = p.Budzet + "";
            }
           
        }
        public void cmbColors_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Saradnik selected = (Saradnik)this.odabir.SelectedItem ;
            Console.WriteLine(selected);
            if (selected != null)
            {
                Proslava p = kontroler.dobaviProslavu(1);
                //this.cenovnik.Text = selected.Naziv;
                foreach(Dogovor d in p.Dogovori)
                {
                    if (d.Ponuda.Saradnik.Naziv.Equals(selected.Naziv))
                    {
                       
                        List<CenovnikProslave> cene = new List<CenovnikProslave>();
                        foreach(String ime in d.Ponuda.Cenovnik.Keys)
                        {
                            CenovnikProslave cp = new CenovnikProslave(ime, d.Ponuda.Cenovnik[ime]);
                            cene.Add(cp);
                           
                        }
                        this.cenovnik.ItemsSource = cene;
                        break;
                    }
                }
            }
        }
    }
    }



    public class ConnectionViewModel : INotifyPropertyChanged
        {
            ProslavaKontroler kontroler { get; set; }
            public ConnectionViewModel()
            {
                kontroler = new ProslavaKontroler();
                Proslava p = kontroler.dobaviProslavu(1L);
                IList<Saradnik> list = new List<Saradnik>();
                if (p != null)
                {
                    if (p.Dogovori != null)
                    {
                        foreach (Dogovor d in p.Dogovori)
                        {
                            Console.WriteLine("da");
                            list.Add(d.Ponuda.Saradnik);
                        }
                    }
                }
                _saradnici = new CollectionView(list);
            }

            private readonly CollectionView _saradnici;
            private string _saradnik;

            public CollectionView saradnici
            {
                get { return _saradnici; }
            }

            public string Saradnik
            {
                get { return _saradnik; }
                set
                {
                    if (_saradnik == value) return;
                    _saradnik = value;
                    OnPropertyChanged("saradnici");
                }
            }

            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                   
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }
    

