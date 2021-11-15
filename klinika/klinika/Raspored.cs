using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klinika
{
    public class Raspored
    {
        private List<Ordinacija> ordinacije;
        private List<int> cekanje;
        public Raspored()
        {
            ordinacije = new List<Ordinacija>();
            cekanje = new List<int>();
        }

        public Raspored(List<Ordinacija> ordinacije, List<int> cekanje)
        {
            this.ordinacije = ordinacije;
            this.cekanje = cekanje;
        }

        public List<Ordinacija> Ordinacije { get => ordinacije; set => ordinacije = value; } //lambda izraze koristimo najcesce u geteri jer izuzetano pojednostavljuju njihovu impementaciju
        public List<int> Cekanje { get => cekanje; set => cekanje = value; }
        private void sortirajOrdinacije() { }
        public string ispisiRaspored()
        {
            string suma = "Raspored vasih pregleda(redni broj u redu cekanja - ordinacija):\n";
            foreach (Ordinacija ord in ordinacije)
                suma += ord.Br + ". " + ord.naziv + "\n";
            return suma;

        }
    }
}
