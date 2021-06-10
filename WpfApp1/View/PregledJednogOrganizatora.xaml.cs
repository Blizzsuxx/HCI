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
using organizerEvents.Controler;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for PregledJednogOrganizatora.xaml
    /// </summary>
    public partial class PregledJednogOrganizatora : Window
    {
        OrganizatorKontroler kontroler { get; set; }
        public PregledJednogOrganizatora(Organizator org)
        {
            kontroler = new OrganizatorKontroler();
            InitializeComponent();
            if (org != null)
            {
                this.ime.Text = org.Ime + " " + org.Prezime;
                this.email.Text = org.Email;
                this.brTel.Text = org.BrojTelefona;
                this.kIme.Text = org.KorisnickoIme;
                this.Proslave.ItemsSource = org.Proslave;
            }
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            this.Close();
            DataBase.LogoutProzor.Show();
            foreach (Window window in Application.Current.Windows)
            {
                if (!window.Equals((Window)DataBase.LogoutProzor))
                {
                    window.Close();
                }
            }
        }
    }
}
