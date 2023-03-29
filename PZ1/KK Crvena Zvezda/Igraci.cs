using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK_Crvena_Zvezda
{
    [Serializable]
    public class Igraci
    {
        private int brojIgraca;
        private string ime;
        private string prezime;
        private string slika;
        private string file;
        private DateTime datumDodavanja;
        private string drzava;
        private DateTime datumRodjenja;
        private int visina;
        

        public Igraci(int brojIgraca, string ime, string prezime, string slika, string file, DateTime datumDodavanja, string drzava, DateTime datumRodjenja, int visina)
        {
            this.brojIgraca = brojIgraca;
            this.ime = ime;
            this.prezime = prezime;
            this.slika = slika;
            this.file = file;
            this.datumDodavanja = datumDodavanja;
            this.drzava = drzava;
            this.datumRodjenja = datumRodjenja;
            this.visina = visina;
        }

        public int BrojIgraca
        {
            get { return brojIgraca; }
            set { brojIgraca = value; }
        }

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }

        public string Slika
        {
            get { return slika; }
            set { slika = value; }
        }

        public string File
        {
            get { return file; }
            set { file = value; }
        }

        public DateTime DatumDodavanja
        {
            get { return datumDodavanja; }
            set { datumDodavanja = value; }
        }

        public string Drzava
        {
            get { return drzava; }
            set { drzava = value; }
        }

        public DateTime DatumRodjenja
        {
            get { return datumRodjenja; }
            set { datumRodjenja = value; }
        }

        public int Visina
        {
            get { return visina; }
            set { visina = value; }
        }

        public string ImePrezime
        {
            get { return string.Format("{0} {1}", this.ime, this.prezime); }
        }

        public Igraci()
        {
        }
    }

}
