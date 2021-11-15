using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klinika
{
    public class Ordinacija
    {
        public string naziv { get; set; }
        private int br;
        private bool aktivna;
        private bool aparat;

        public Ordinacija(string naziv, bool aktivna, bool aparat)
        {
            this.naziv = naziv;
            Br = 0;
            Aktivna = aktivna;
            Aparat = aparat;
        }

        public Ordinacija()
        {
        }

        public bool Aktivna { get => aktivna; set => aktivna = value; }
        public int Br { get => br; set => br = value; }
        public bool Aparat { get => aparat; set => aparat = value; }
    }
}
