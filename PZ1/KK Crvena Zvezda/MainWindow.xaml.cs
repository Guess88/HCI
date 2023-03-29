using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KK_Crvena_Zvezda
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public static class GlobalVar
    {
        public static bool  adminPrijava = false;
        public static bool  posetilacPrijava = false;
    }
    public partial class MainWindow : Window
    {

        private string imeAdmin = "Pera";
        private string sifraAdmin = "NTP";
        private string imePosetilac = "Marko";
        private string sifraPosetilac = "Telefon";
       
        

        public MainWindow()
        {   
            InitializeComponent();
            tbUsername.Text = "Username";
            tbUsername.Foreground = Brushes.LightSlateGray;
            tbPW.Text = "Passowrd";
            tbPW.Foreground = Brushes.LightSlateGray;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        #region Izlaz i minimizacija
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

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow;
            mainWindow.WindowState = WindowState.Minimized;
        }
        #endregion

        #region Eventovi texbox-ova za prijavu
        private void tbPW_GotFocus(object sender, RoutedEventArgs e)
        {
            tbPW.Visibility = Visibility.Hidden;
            PassowrdB.Focus();
        }

        private void tbUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbUsername.Text.Trim().Equals("Username"))
            {
                tbUsername.Text = "";
                tbUsername.Foreground = Brushes.Black;
            }
            
        }

        private void tbUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbUsername.Text.Trim().Equals(string.Empty))
            {
                tbUsername.Text = "Username";
                tbUsername.Foreground = Brushes.LightSlateGray;
            }
        }

        private void Passowrd_GotFocus(object sender, RoutedEventArgs e)
        {
            tbPW.Text="";
        }

        private void Passowrd_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PassowrdB.Password.Trim().Equals(string.Empty))
            {
                tbPW.Visibility = Visibility.Visible;
                tbPW.Text = "Password";
                tbPW.Foreground = Brushes.LightSlateGray;
            }
        }
        #endregion

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (validate())
            {
               if(tbUsername.Text == imeAdmin && PassowrdB.Password == sifraAdmin)
                {
                    this.Hide();

                    GlobalVar.adminPrijava = true;
                    Sadrzaj sadrzajAdmin = new Sadrzaj();
                    sadrzajAdmin.ShowDialog();
                    
                    this.Show();
                    PassowrdB.Password = "";
                    tbUsername.Text = "Username";
                    tbUsername.Foreground = Brushes.LightSlateGray;
                    tbPW.Visibility = Visibility.Visible;
                    tbPW.Text = "Password";
                    tbPW.Foreground = Brushes.LightSlateGray;
                    GlobalVar.adminPrijava = false;

                }
               else if (tbUsername.Text == imePosetilac && PassowrdB.Password == sifraPosetilac)
                {
                    this.Hide();
                    GlobalVar.posetilacPrijava = true;
                    Sadrzaj posetilacSadrzaj = new Sadrzaj();
                    posetilacSadrzaj.ShowDialog();

                    this.Show();
                    PassowrdB.Password = "";
                    tbUsername.Text = "Username";
                    tbUsername.Foreground = Brushes.LightSlateGray;
                    tbPW.Visibility = Visibility.Visible;
                    tbPW.Text = "Password";
                    tbPW.Foreground = Brushes.LightSlateGray;
                    GlobalVar.posetilacPrijava = false;
                }
                else
                {
                    MessageBox.Show("Provarite da li ste dobro uneli podatke!","Greska!",MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Polja nisu popunjena!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool validate()
        {
            bool result = true;

            if (tbUsername.Text.Trim().Equals("") || tbUsername.Text.Trim().Equals("Username"))
            {
                result = false;

                tbUsername.BorderBrush = Brushes.Red;
            }
            else
            {
                tbUsername.BorderBrush = Brushes.Gray;
            }


            if (PassowrdB.Password.Trim().Equals(string.Empty))
            {
                result = false;
                PassowrdB.BorderBrush = Brushes.Red;
                tbPW.BorderBrush = Brushes.Red;
            }
            else
            {
                PassowrdB.BorderBrush = Brushes.Gray;
            }

            return result;
        }

       
    }
}
