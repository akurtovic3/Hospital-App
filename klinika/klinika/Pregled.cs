using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klinika
{
    public class Pregled
    {
        private DateTime datum;
        private string misljenje, rezultat;
        private Terapija terapije;
        private bool gotov;
        private Doktor doktor;
        private Ordinacija ordinacija;
        private decimal cijena;
        public Pregled(DateTime datum, string misljenje, string rezultat, Terapija terapije, bool gotov, Ordinacija ordinacija, Doktor doktor, decimal cijena)
        {
            this.Datum = datum;
            this.misljenje = misljenje;
            this.rezultat = rezultat;
            this.Terapije = terapije;
            this.gotov = gotov;
            this.ordinacija = ordinacija;
            this.doktor = doktor;
            this.Cijena = cijena;
        }

        public Pregled()
        {
        }

        public string Misljenje { get => misljenje; set => misljenje = value; }
        public string Rezultat { get => rezultat; set => rezultat = value; }
        public bool Gotov
        {
            get => gotov; set
            {
                gotov = value;
                //              if(gotov==1) smanji brojac ordinacije
            }
        }
        public string ispisiPregled()
        {
            return "Datum pregleda: " + datum.ToString() + "\n    Misljenje doktora: " + misljenje + "\n    Rezultat pregleda: " + rezultat + "\n    Terapija: " + Terapije.Terapije + "\n    Doktor: " + Doktor.ime + " " + Doktor.prezime;
        }
        public DateTime Datum { get => datum; set => datum = value; }
        public Terapija Terapije { get => terapije; set => terapije = value; }
        public Ordinacija Ordinacija { get => ordinacija; set => ordinacija = value; }
        public Doktor Doktor { get => doktor; set => doktor = value; }
        public decimal Cijena { get => cijena; set => cijena = value; }
    }
}
