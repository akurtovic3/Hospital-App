using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace klinika
{
    public class HitanSlucaj : Pacijent
    {
        private string prva_pomoc;
        private string uzrok_smrti;
        private DateTime vrijeme_obdukcije;

        public HitanSlucaj() : base()
        {
        }

        public HitanSlucaj(Knjizica knjizica, Karton karton, Racun racun, Image slika, string username, string password, string prva_pomoc, string uzrok_smrti, DateTime vrijeme_obdukcije) : base(knjizica, karton, racun, slika, username, password)
        {
            Prva_pomoc = prva_pomoc;
            Uzrok_smrti = uzrok_smrti;
            Vrijeme_obdukcije = vrijeme_obdukcije;
        }
        public HitanSlucaj(Knjizica knjizica, Karton karton, Racun racun, Image slika, string prva_pomoc, string uzrok_smrti, DateTime vrijeme_obdukcije) : base(knjizica, karton, racun, slika)
        {
            Prva_pomoc = prva_pomoc;
            Uzrok_smrti = uzrok_smrti;
            Vrijeme_obdukcije = vrijeme_obdukcije;
        }
        public string Prva_pomoc { get => prva_pomoc; set => prva_pomoc = value; }
        public string Uzrok_smrti { get => uzrok_smrti; set => uzrok_smrti = value; }
        public DateTime Vrijeme_obdukcije { get => vrijeme_obdukcije; set => vrijeme_obdukcije = value; }

    }
}
