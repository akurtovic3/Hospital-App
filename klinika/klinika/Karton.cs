using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klinika
{
    public class Karton
    {
        private Anamneza anamneza;
        private List<Pregled> pregledi;
        private List<Doktor> posjeceni_doktori;
        private Raspored rasporedi;

        public Karton(Anamneza anamneza, List<Pregled> pregledi, List<Doktor> posjeceni_doktori, Raspored rasporedi)
        {
            this.Pregledi = pregledi;
            this.posjeceni_doktori = posjeceni_doktori;
            this.rasporedi = rasporedi;
            this.Anamneza = anamneza;
        }
        public Karton()
        {
            this.pregledi = new List<Pregled>();
            this.posjeceni_doktori = new List<Doktor>();
        }
        public List<Pregled> Pregledi { get => pregledi; set => pregledi = value; }
        public List<Doktor> Posjeceni_doktori { get => posjeceni_doktori; set => posjeceni_doktori = value; }
        public Raspored Rasporedi { get => rasporedi; set => rasporedi = value; }
        public Anamneza Anamneza { get => anamneza; set => anamneza = value; }
        public string ispisiTerapije()
        {
            string s = "";
            foreach (Pregled p in Pregledi)
                s += p.Terapije.Terapije+"\n";
            return s;
        }
    }
}
