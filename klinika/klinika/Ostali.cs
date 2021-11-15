using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klinika
{
    public class Ostali : Uposlenici
    {
        private decimal placa;
        public string zanimanje { get; set; }
        public decimal Placa { get => placa; set => placa = value; }

        public Ostali(string ime, string prezime, string username, string sifra, string zanimanje) : base(ime, prezime, username, sifra)
        {
            this.Placa = sigurnaplata;
            this.zanimanje = zanimanje;
        }
        public Ostali(string ime, string prezime, string zanimanje) : base(ime, prezime)
        {
            this.Placa = sigurnaplata;
            this.zanimanje = zanimanje;
        }
        public Ostali() : base()
        {
        }

        public override decimal plata()
        {
            return sigurnaplata;
        }
        public string vratiTip()
        {
            return "Ostali";
        }
    }
}
