using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klinika
{
    public interface MojInterfejs
    {
        void NoviDan(int i);
        void NoviMjesec();
    }
    public class Doktor : Uposlenici, MojInterfejs
    {
        static Int64 globalID;
        public static readonly decimal dodatak = 30;
        Int64 id;
        public string struka { get; set; }
        private List<int> br_pregledanih;
        private Ordinacija ordinacija;
        private decimal placa;
        public Doktor(string ime, string prezime, string username, string sifra, string struka, Ordinacija ordinacija) : base(ime, prezime, username, sifra)
        {
            id = globalID + 1;
            globalID += 1;
            this.struka = struka;
            this.br_pregledanih = new List<int>();
            this.Ordinacija = ordinacija;
            this.placa = sigurnaplata;
            this.br_pregledanih.Add(0);
        }
        public Doktor() : base()
        {
        }
        public string vratiTip()
        {
            return "doktor";
        }
        public List<int> Br_pregledanih { get => br_pregledanih; set => br_pregledanih = value; }
        public static decimal Dodatak => dodatak;

        public Ordinacija Ordinacija { get => ordinacija; set => ordinacija = value; }
        public decimal Placa { get => placa; }
        public long Id { get => id; }
        void MojInterfejs.NoviDan(int i)
        {
            if (i == 1) br_pregledanih.Add(0);
        }
        void MojInterfejs.NoviMjesec()
        {
            if (DateTime.Now.Day == 1) br_pregledanih.Clear();
        }
        public override decimal plata()
        {
            decimal suma = sigurnaplata;
            foreach (decimal br in br_pregledanih)
            {
                if (br <= 20)
                    suma += dodatak * br;
                else suma += dodatak * 20;
            }
            placa = suma;
            return suma;
        }
    }
}
