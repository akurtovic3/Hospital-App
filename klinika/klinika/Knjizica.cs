using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klinika
{
    public class Knjizica
    {
        public string ime { get; set; }
        public string prezime { get; set; }
        private string adresa;
        private string JMBG;
        private string spol; // M-Musko Z-Zensko
        private DateTime datum_rodjenja;
        public string Adresa { get => adresa; set => adresa = value; }
        public string JMBG1 { get => JMBG; set => JMBG = value; }
        public string Spol { get => spol; set => spol = value; }
        public DateTime Datum_rodjenja { get => datum_rodjenja; set => datum_rodjenja = value; }

        public Knjizica(string ime, string prezime, string adresa, string jMBG, string spol, DateTime datum_rodjenja)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.Adresa = adresa;
            JMBG1 = jMBG;
            this.Spol = spol;
            this.Datum_rodjenja = datum_rodjenja;
        }

        public Knjizica()
        {
        }
    }
}
