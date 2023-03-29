using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace KK_Crvena_Zvezda
{
    /// <summary>
    /// Interaction logic for Sadrzaj.xaml
    /// </summary>
    public partial class Sadrzaj : Window
    {

        private DataIO serializer = new DataIO();
        public static BindingList<Igraci> listaIgraca { get; set; }

        public static List<Igraci> zaObrisati = new List<Igraci>();


        public Sadrzaj()
        {
            listaIgraca = serializer.DeSerializeObject<BindingList<Igraci>>("spisakIgraca.xml");
            if (listaIgraca == null)
            {
                listaIgraca = new BindingList<Igraci>();
            }


            DataContext = this;
            InitializeComponent();

            if (GlobalVar.posetilacPrijava == true)
            {
                btnDodajIgraca.Visibility = Visibility.Hidden;
                btnIzbrisigraca.Visibility = Visibility.Hidden;
                btnIzlaz.Margin = new Thickness(235, 5, 5, 0);
                checkBoxObrisi.Visibility = Visibility.Hidden;
                dataGridDatum.Visibility = Visibility.Hidden;

            }

           
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnDodajIgraca_Click(object sender, RoutedEventArgs e)
        {
            DodajIgraca noviIgrac = new DodajIgraca();
            noviIgrac.ShowDialog();
        }

        #region Brisanje 
        private void btnIzbrisigraca_Click(object sender, RoutedEventArgs e)
        {
            for (int j = 0; j < zaObrisati.Count; j++)
            {
                listaIgraca.Remove(zaObrisati[j]);
            }

            for (int i = 0; i < zaObrisati.Count; i++)
            {
                if (zaObrisati[i] != null)
                {
                    string putanja = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, zaObrisati[i].File);
                    try
                    {
                        File.Delete(putanja);
                    }
                    catch (IOException exp)
                    {
                        Console.WriteLine(exp.Message);
                    }
                }
            }

        }

        private void OnChecked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < listaIgraca.Count; i++)
            {
                if (i == dataGridIgraci.SelectedIndex)
                {
                    zaObrisati.Add((Igraci)dataGridIgraci.SelectedItem);
                }
            }

        }

        private void Unchecked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < listaIgraca.Count; i++)
            {
                if (i == dataGridIgraci.SelectedIndex)
                {
                    zaObrisati.Remove((Igraci)dataGridIgraci.SelectedItem);
                }
            }
        }

        #endregion

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            serializer.SerializeObject<BindingList<Igraci>>(listaIgraca, "spisakIgraca.xml");
        }

        private void OnHyperlinkClick(object sender, RoutedEventArgs e)
        {
            if (GlobalVar.adminPrijava)
            {
                IzmeniIgraca izmena = new IzmeniIgraca(dataGridIgraci.SelectedIndex);
                izmena.ShowDialog();
            }
            else if (GlobalVar.posetilacPrijava)
            {
                PrikazSadrzaja prikaz = new PrikazSadrzaja(dataGridIgraci.SelectedIndex);
                prikaz.ShowDialog();
            }
        }
    }
}
