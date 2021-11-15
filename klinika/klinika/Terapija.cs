using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klinika
{
    public class Terapija
    {
        private bool greska;
        private DateTime datum;
        private bool garancija;
        private string terapije;
        private bool trajanje;//kratkorocna=0 --- dugorocna=1
        public bool Greska { get => greska; set => greska = value; }
        public DateTime Datum { get => datum; set => datum = value; }
        public bool Garancija { get => garancija; set => garancija = value; }
        public string Terapije { get => terapije; set => terapije = value; }
        public bool Trajanje { get => trajanje; set => trajanje = value; }

        public Terapija(bool greska, DateTime datum, bool garancija, string terapija, bool trajanje)
        {
            this.Greska = greska;
            this.Datum = datum;
            this.Garancija = garancija;
            this.Terapije = terapija;
            this.Trajanje = trajanje;
        }

        public Terapija()
        {
        }
    }
}
