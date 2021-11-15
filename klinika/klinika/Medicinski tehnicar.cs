using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klinika
{
    public class Medicinski_tehnicar : Ostali
    {

        public Medicinski_tehnicar(string ime, string prezime, string username, string sifra) : base(ime, prezime, username, sifra, "Medicinski tehnicar")
        {
        }
        public Medicinski_tehnicar(string ime, string prezime) : base(ime, prezime, "Medicinski tehnicar")
        {
        }
        public Medicinski_tehnicar()
        {

        }
        public override decimal plata()
        {
            return sigurnaplata;
        }
    }
}
