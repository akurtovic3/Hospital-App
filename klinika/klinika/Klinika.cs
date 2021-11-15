using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace klinika
{
    public partial class Klinika
    {
        private List<Pacijent> pacijenti;
        private List<Ordinacija> ordinacije;
        private List<Ostali> ostali;
        private List<Doktor> doktori;

        public Klinika()
        {
        }

        public Klinika(List<Pacijent> pacijenti, List<Ordinacija> ordinacije, List<Doktor> doktori, List<Ostali> ostali)
        {
            Pacijenti = pacijenti;
            Ordinacije = ordinacije;
            Doktori = doktori;
            Ostali = ostali;
        }
        public static string MD5Hashdes(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
        public bool imaLiDoktora(string korisnik, string sifra)
        {
            foreach(Uposlenici d in Doktori)
            {
                if ((d as Doktor).Username.Equals(korisnik) && (d as Doktor).Password.Equals(MD5Hashdes(sifra))) return true;
            }
            return false;
        }
        public bool imaLiMedicinske(string korisnik, string sifra)
        {
            foreach (Ostali d in Ostali)
            {
                if (d.Username==korisnik && d.Password==MD5Hashdes(sifra) && d.zanimanje=="Medicinski tehnicar") return true;
            }
            return false;
        }
        public bool imaLiPortira(string korisnik, string sifra)
        {
            foreach (Portir d in Ostali)
            {
                if (d.Username.Equals(korisnik) && d.Password.Equals(MD5Hashdes(sifra))) return true;
            }
            return false;
        }
        public bool imaLiPacijenta(string username, string password)
        {
            foreach (Pacijent d in Pacijenti)
            {
                if (d.Username.Equals(username) && d.Password.Equals(MD5Hashdes(password))) return true;
            }
            return false;
        }
        public bool imaLiPacijenta(string JMBG)
        {
            foreach (Pacijent d in Pacijenti)
            {
                if (d.Zdravstvena_knjizica.JMBG1.Equals(JMBG)) return true;
            }
            return false;
        }
        public Doktor vratiDoktora(string korisnik, string sifra)
        {
            foreach (Doktor d in Doktori)
            {
                if (d.Username.Equals(korisnik) && d.Password.Equals(MD5Hashdes(sifra))) return d;
            }
            return new Doktor();
        }
        public Medicinski_tehnicar vratiMedicinsku(string korisnik, string sifra)
        {
            foreach (Medicinski_tehnicar d in Ostali)
            {
                if (d.Username.Equals(korisnik) && d.Password.Equals((MD5Hashdes(sifra)))) return d;
            }
            return new Medicinski_tehnicar();
        }
        public Portir vratiPortira(string korisnik, string sifra)
        {
            foreach (Portir d in Ostali)
            {
                if (d.Username.Equals(korisnik) && d.Password.Equals(MD5Hashdes(sifra))) return d;
            }
            return new Portir();
        }
        public Pacijent vratiPacijenta(string JMBG)
        {
            foreach(Pacijent p in Pacijenti)
            {
                if (p.Zdravstvena_knjizica.JMBG1.Equals(JMBG))
                {
                    return p;
                }
            }
            return new Normalni();
        }
        public Pacijent vratiPacijenta(string username, string password)
        {
            foreach (Pacijent d in Pacijenti)
            {
                if (d.Username.Equals(username) && d.Password.Equals(MD5Hashdes(password))) return d;
            }
            return new Normalni();
        }
        public List<Pacijent> Pacijenti { get => pacijenti; set => pacijenti = value; }
        public List<Ordinacija> Ordinacije { get => ordinacije; set => ordinacije = value; }
        public List<Ostali> Ostali { get => ostali; set => ostali = value; }
        public List<Doktor> Doktori { get => doktori; set => doktori = value; }
    }
}
