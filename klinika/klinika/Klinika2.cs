using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klinika
{
    public partial class Klinika
    {
        public string Brisi(Pacijent pacijent)
        {
            if (pacijenti.Remove(pacijent)) return "Pacijent " + pacijent.Zdravstvena_knjizica.ime + " " + pacijent.Zdravstvena_knjizica.prezime + "je uspjesno obrisan!";
            else return pacijent.Zdravstvena_knjizica.ime + " " + pacijent.Zdravstvena_knjizica.prezime + " nije registrovan!";
        }
        public string Registruj(Pacijent pacijent)
        {
            pacijenti.Add(pacijent);
            return "Pacijent" + pacijent.Zdravstvena_knjizica.ime + " " + pacijent.Zdravstvena_knjizica.prezime + "je uspjesno registrovan!";
        }
        public string ispisiOrdinacije()
        {
            int i = 1;
            string suma = "Ordinacije koje su aktivne i broj ljudi koji cekaju u redu za tu ordinaciju:\n";
            foreach (Ordinacija ord in ordinacije)
            {
                if (ord.Aktivna == true)
                {
                    suma += i + "--" + ord.naziv + "---"+ord.Br+ "\n";
                    i++;
                }
            }
            return suma;
        }
        public string ispisiOrdinacijeCekanje()
        {
            int i = 1;
            string suma = "Ordinacije koje su aktivne i njihove liste cekanja:\n";
            foreach (Ordinacija ord in ordinacije)
            {
                if (ord.Aktivna == true)
                {
                    suma += i + "--" + ord.naziv + ":\n";
                    int j = 0;
                    while (j != ord.Br)
                    {
                        foreach (Pacijent p in Pacijenti)
                        {
                            if (p.Karton.Rasporedi.Ordinacije.Equals(ord) && p.Karton.Rasporedi.Cekanje.Equals(j))
                            {
                                suma += "/t" + p.Zdravstvena_knjizica.ime + " " + p.Zdravstvena_knjizica.prezime + "\n";
                            }
                        }
                        j++;
                    }
                    i++;
                }
            }
            return suma;
        }
        public string ispisiPacijente()
        {
            string suma = "Registrovani pacijenti su:\n";
            int i = 1;
            foreach (Pacijent pac in Pacijenti)
            {
                suma += i + "--ID: " + pac.Id + ". " + pac.Zdravstvena_knjizica.ime + " " + pac.Zdravstvena_knjizica.prezime + ":\n    Datum rodjenja: " + pac.Zdravstvena_knjizica.Datum_rodjenja.ToString() + "\n    JMBG: " + pac.Zdravstvena_knjizica.JMBG1 + "\n    Spol: " + pac.Zdravstvena_knjizica.Spol + "\n";
                i++;
            }
            return suma;
        }
        public string IspisiDoktore()
        {
            string suma = "Registrovani doktori su:\n";
            foreach (Doktor dok in Doktori)
                suma += dok.Id + " " + dok.ime + " " + dok.prezime + "\n";
            return suma;
        }
    }
}
