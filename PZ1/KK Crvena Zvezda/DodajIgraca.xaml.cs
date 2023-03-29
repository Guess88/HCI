using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KK_Crvena_Zvezda
{
    /// <summary>
    /// Interaction logic for DodajIgraca.xaml
    /// </summary>
    public partial class DodajIgraca : Window
    {

        int rtbBrojReci; //Za proveru u validaciji da li ima nesto uspisano u rtf


        public DodajIgraca()
        {
            InitializeComponent();
            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);

            cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48 };

            cmbFontColor.ItemsSource = typeof(Colors).GetProperties();
            cmbFontColor.SelectedIndex = 7;


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
            this.Close();
        }

        #region RichTextBox
        private void cmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontFamily.SelectedItem != null && !rtbOpis.Selection.IsEmpty)
            {
                rtbOpis.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
            }
        }

        private void cmbFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontSize.SelectedItem != null && !rtbOpis.Selection.IsEmpty)
            {
                rtbOpis.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmbFontSize.SelectedValue);
            }
        }

        private void cmbFontColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cmbFontColor.SelectedItem != null && !rtbOpis.Selection.IsEmpty)
            {
                Color selectedColor = (Color)(cmbFontColor.SelectedItem as PropertyInfo).GetValue(null, null);
                SolidColorBrush boja2 = new SolidColorBrush(selectedColor);
                rtbOpis.Selection.ApplyPropertyValue(Inline.ForegroundProperty, boja2);
            }
        }

        private void rtbOpis_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = rtbOpis.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));

            temp = rtbOpis.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));

            temp = rtbOpis.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = rtbOpis.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cmbFontFamily.SelectedItem = temp;

            temp = rtbOpis.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmbFontSize.SelectedItem = temp;

            temp = rtbOpis.Selection.GetPropertyValue(Inline.ForegroundProperty);
            cmbFontColor.SelectedItem = temp;

        }

        private void BrojReci()
        {
            int brojReci = 0;
            int index = 0;
            string richText = new TextRange(rtbOpis.Document.ContentStart, rtbOpis.Document.ContentEnd).Text;

            while (index < richText.Length && char.IsWhiteSpace(richText[index]))
                index++;

            while (index < richText.Length)
            {
                while (index < richText.Length && !char.IsWhiteSpace(richText[index]))
                    index++;

                brojReci++;

                while (index < richText.Length && char.IsWhiteSpace(richText[index]))
                    index++;
            }

            tbBrojReci.Text = "Broj reci: " + brojReci.ToString();
            rtbBrojReci = brojReci;
        }

        private void rtbOpis_TextChanged(object sender, TextChangedEventArgs e)
        {
            BrojReci();
        }

        #endregion

        private void btnDodajSliku_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg";
            if (ofd.ShowDialog() == true)
            {
                string imgSrc = ofd.FileName;
                string relativna = imgSrc.Substring(imgSrc.LastIndexOf("Slike"));
                slikaIgraca.Source = new BitmapImage(new Uri(relativna, UriKind.Relative));
            }
        }

        private void bntDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (validate())
            {
                string nazivRtfFajla = "";
                nazivRtfFajla = tbImeIgraca.Text + tbPrezimeIgraca.Text + ".rtf";

                TextRange range;
                FileStream fStream;
                range = new TextRange(rtbOpis.Document.ContentStart, rtbOpis.Document.ContentEnd);
                fStream = new FileStream(nazivRtfFajla, FileMode.Create);
                range.Save(fStream, DataFormats.Rtf);
                fStream.Close();



                Sadrzaj.listaIgraca.Add(new Igraci(Int32.Parse(tbBrojIgraca.Text), tbImeIgraca.Text, tbPrezimeIgraca.Text, slikaIgraca.Source.ToString(), nazivRtfFajla, DateTime.Now, tbDrzava.Text, dtDatumRodjenja.SelectedDate.Value.Date, Int32.Parse(tbVisina.Text)));



                this.Close();
            }
            else
            {
                MessageBox.Show("Polja nisu dobro popunjena!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #region Validacija unosa
        private bool validate()
        {
            bool result = true;

            //Provera za unos imena
            if (tbImeIgraca.Text.Trim().Equals(""))
            {
                result = false;

                tbImeIgraca.BorderBrush = Brushes.Red;
            }
            else
            {
                tbImeIgraca.BorderBrush = Brushes.Gray;
            }



            //Provera za unos prezimena
            if (tbPrezimeIgraca.Text.Trim().Equals(""))
            {
                result = false;

                tbPrezimeIgraca.BorderBrush = Brushes.Red;
            }
            else
            {
                tbPrezimeIgraca.BorderBrush = Brushes.Gray;
            }



            //Provera za unos broja igraca
            if (!Int32.TryParse(tbBrojIgraca.Text, out int broj))
            {
                result = false;

                tbBrojIgraca.BorderBrush = Brushes.Red;
            }
            else if (postojiBroj())
            {
                result = false;

                tbBrojIgraca.BorderBrush = Brushes.Red;

                for (int i = 0; i < Sadrzaj.listaIgraca.Count(); i++)
                {
                    if (broj == Sadrzaj.listaIgraca[i].BrojIgraca)
                    {
                        labelBrojIgraca.Text = "Igrac " + Sadrzaj.listaIgraca[i].Ime + " " + Sadrzaj.listaIgraca[i].Prezime + " vec koristi taj broj";
                    }
                }

                labelBrojIgraca.Visibility = Visibility.Visible;
            }
            else
            {
                tbBrojIgraca.BorderBrush = Brushes.Gray;
                labelBrojIgraca.Visibility = Visibility.Hidden;
            }

            //Provera za unos drzave
            if (tbDrzava.Text.Trim().Equals(""))
            {
                result = false;

                tbDrzava.BorderBrush = Brushes.Red;
            }
            else
            {
                tbDrzava.BorderBrush = Brushes.Gray;
            }


            //Provera za unos datuma rodjenja
            if (dtDatumRodjenja.SelectedDate == null)
            {
                result = false;

                dtDatumRodjenja.BorderBrush = Brushes.Red;
            }
            else
            {
                dtDatumRodjenja.BorderBrush = Brushes.Gray;
            }


            //Provera za unos visine
            if (!Int32.TryParse(tbVisina.Text, out int visina))
            {
                result = false;

                tbVisina.BorderBrush = Brushes.Red;
            }
            else if (visina < 170)
            {
                result = false;

                tbVisina.BorderBrush = Brushes.Red;

                labelVisinaIgraca.Text = "Da li ste sigurni da je visina igraca " + visina + "cm?";
                labelVisinaIgraca.Visibility = Visibility.Visible;
            }
            else if (visina > 240)
            {
                result = false;

                tbVisina.BorderBrush = Brushes.Red;

                labelVisinaIgraca.Text = "Da li ste sigurni da je visina igraca " + visina + "cm?";
                labelVisinaIgraca.Visibility = Visibility.Visible;
            }
            else
            {

                tbVisina.BorderBrush = Brushes.Gray;
                labelVisinaIgraca.Visibility = Visibility.Hidden;
            }

            //Provera za unos u rtf
            if (rtbBrojReci == 0)
            {
                result = false;

                rtbOpis.BorderBrush = Brushes.Red;
            }
            else
            {
                rtbOpis.BorderBrush = Brushes.Gray;
            }

            return result;
        }


        //Provera postojanja broja kod nekog igraca koji je vec u listi
        private bool postojiBroj()
        {

            bool postojiBroj = false;

            for (int i = 0; i < Sadrzaj.listaIgraca.Count(); i++)
            {
                if (Sadrzaj.listaIgraca[i].BrojIgraca == Int32.Parse(tbBrojIgraca.Text))
                {
                    postojiBroj = true;
                    break;
                }

            }
            return postojiBroj;
        }
        #endregion
    }
}
