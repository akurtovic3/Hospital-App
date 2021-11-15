using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klinika
{
    public class Racun
    {
        private decimal dug, sadasnjiracun;
        private int rate;
        private decimal cijenaRate;
        public Racun(decimal dug, decimal sadasnjiracun)
        {
            Dug = dug;
            Sadasnjiracun = sadasnjiracun;
            Rate = 6;
            CijenaRate = sadasnjiracun/6;
        }

        public Racun()
        {
        }

        public decimal Dug { get => dug; set => dug = value; }
        public decimal Sadasnjiracun { get => sadasnjiracun; set => sadasnjiracun = value; }
        public int Rate { get => rate; set => rate = value; }
        public decimal CijenaRate { get => cijenaRate; set => cijenaRate = value; }
       
        

    }
}
