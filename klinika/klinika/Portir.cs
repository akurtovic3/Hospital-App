using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klinika
{
    public class Portir:Ostali
    {

        public Portir(string ime, string prezime, string username, string sifra):base(ime, prezime, username, sifra,"portir")
        {
        }
        public Portir(string ime, string prezime) : base(ime, prezime, "portir")
        {
        }
        public Portir()
        {

        }
        public override decimal plata()
        {
            return sigurnaplata;
        }
    }
}
