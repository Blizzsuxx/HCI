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

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for Demo.xaml
    /// </summary>
    public partial class Demo : Window
    {
        public static int index = 0;
        public static List<string> nazivi;

        public Demo()
        {
            nazivi = new List<string>
            {
                "pristupDogadjaju.mp4",
                "prihvatanjeOrg.mp4",
                "kreirajSaradnika.mp4",
                "kreiranjePonude.mp4",
                "kreiranjeDogovora.mp4",
                "prihvatanjePonude.mp4",


            };
            InitializeComponent();
            VideoControl.MediaEnded += OnMediaEnded;
            VideoControl.LoadedBehavior = MediaState.Manual;
            VideoControl.Source = new Uri(@"kreiranjeDogadjaja.mp4", UriKind.Relative);
            VideoControl.Play();
        }


        private void OnMediaEnded(object sender, RoutedEventArgs e)
        {
            if (index >= nazivi.Count)
                return;
            var nextMediaSource = nazivi[index];
            index++;
            if (nextMediaSource != null)
            {
                VideoControl.Source = new Uri(nextMediaSource, UriKind.Relative);
                VideoControl.Play();
            }
             

        }
    }
}
