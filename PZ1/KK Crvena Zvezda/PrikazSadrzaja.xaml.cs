using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KK_Crvena_Zvezda
{
    /// <summary>
    /// Interaction logic for PrikazSadrzaja.xaml
    /// </summary>
    public partial class PrikazSadrzaja : Window
    {

        static bool  animacijaIzvrsena = false;
        TimeSpan duzinaAnimacije = new TimeSpan(0, 0, 0, 1,5);
        string filePath;

        public PrikazSadrzaja(int i)
        {
            InitializeComponent();
            lblBrojDresa.Content = "#" + Sadrzaj.listaIgraca[i].BrojIgraca.ToString();
            lblIme.Content = Sadrzaj.listaIgraca[i].Ime + " " + Sadrzaj.listaIgraca[i].Prezime;
            slikaIgraca.Source = new BitmapImage(new Uri(Sadrzaj.listaIgraca[i].Slika));
            filePath = Sadrzaj.listaIgraca[i].File;
            lblDrzava.Content = Sadrzaj.listaIgraca[i].Drzava;
            lblDatumRodjenja.Content = Sadrzaj.listaIgraca[i].DatumRodjenja;
            lblVisina.Content = Sadrzaj.listaIgraca[i].Visina + " cm";


            TextRange textRange;
            System.IO.FileStream fileStream;

            if (System.IO.File.Exists(filePath))
            {
                textRange = new TextRange(rtbPrikazOpisa.Document.ContentStart, rtbPrikazOpisa.Document.ContentEnd);
                using (fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.OpenOrCreate))
                {
                    textRange.Load(fileStream, System.Windows.DataFormats.Rtf);
                }
            }

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnClose_MouseEnter(object sender, MouseEventArgs e)
        {
            imgClose.Source = new BitmapImage(new Uri("..\\..\\Slike/close-img2.png", UriKind.Relative));
        }

        private void btnClose_MouseLeave(object sender, MouseEventArgs e)
        {
            imgClose.Source = new BitmapImage(new Uri("..\\..\\Slike/close-img1.png", UriKind.Relative));
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            animacijaIzvrsena = false;
            this.Close();
        }

        private void btnPrikaziVise_Click(object sender, RoutedEventArgs e)
        {
            if (animacijaIzvrsena)
            {
                btnPrikaziVise.Content = "Prikazi vise +";
                btnPrikaziVise.Foreground = Brushes.Black;
                visinaSlike(187.5, 337.5, duzinaAnimacije);
                visinaRtb(0, duzinaAnimacije);
                animacijaIzvrsena = false;
            }
            else
            {
                btnPrikaziVise.Foreground = Brushes.Red;
                btnPrikaziVise.Content = "Prikazi manje -";
                visinaSlike(337.5, 187.5, duzinaAnimacije);
                visinaRtb(150, duzinaAnimacije);
                animacijaIzvrsena = true;
            }
        }

        private void visinaSlike(double velicinaPocetna, double velicina, TimeSpan trajanje)
        {
            DoubleAnimation animation = new DoubleAnimation(velicinaPocetna, velicina, trajanje);
            slikaIgraca.BeginAnimation(Image.HeightProperty, animation);
        }

        private void visinaRtb(double velicina, TimeSpan trajanje)
        {
            DoubleAnimation animation = new DoubleAnimation(velicina, trajanje);
            rtbPrikazOpisa.BeginAnimation(RichTextBox.HeightProperty, animation);
        }
    }
}
