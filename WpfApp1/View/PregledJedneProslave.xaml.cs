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
using System.ComponentModel;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for PregledJedneProslave.xaml
    /// </summary>
    public partial class PregledJedneProslave : Window
    {
        ProslavaKontroler kontroler { get; set; }
        public PregledJedneProslave()
        {
            InitializeComponent();
            dobaviInfoProslave();
            ConnectionViewModel vm = new ConnectionViewModel();
            DataContext = vm;
        }

        private void dobaviInfoProslave()
        {
            kontroler = new ProslavaKontroler(); //Todo ili proslediti ili da se dobije neki id
            Proslava p = kontroler.dobaviProslavu(1);
            this.kIme.Text = p.Narucilac.Ime + " " + p.Narucilac.Prezime;
            this.org.Text = p.Organizator.Ime + " " + p.Organizator.Prezime;
            this.Datum.Text = p.DatumVreme + "";
            this.brGostiju.Text = p.BrojGostiju + "";
            this.mesto.Text = p.Mesto.NazivMesta;
            this.budzet.Text = p.Budzet + "";
        }
        private void cmbColors_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
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
                        String textCenovnik = "Cenovnik: \n"; //TODO uradi i mnozenje i ako je odbijena plus slike!!! i budzet na kraju za tu ponudu
                        
                        foreach(String ime in d.Ponuda.Cenovnik.Keys)
                        {
                            textCenovnik += ime + " : " + d.Ponuda.Cenovnik[ime] + "\n";
                        }
                        this.cenovnik.Text = textCenovnik;
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
                Proslava p = kontroler.dobaviProslavu(1);
                IList<Saradnik> list = new List<Saradnik>();
                foreach (Dogovor d in p.Dogovori)
                {
                    Console.WriteLine("da");
                    list.Add(d.Ponuda.Saradnik);
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
    

