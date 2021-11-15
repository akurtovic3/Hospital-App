using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Drawing;

namespace klinika
{
    public abstract class Pacijent
    {
        static Int64 globalID;
        Int64 id;
        private Image slika;
        private string username;
        private string password;
        private Knjizica zdravstvena_knjizica;
        private Karton karton;
        private Racun racun;
        private int br;
        public int Br { get => br; set => br = value; }
        public Pacijent(Knjizica knjizica, Karton karton, Racun racun, Image slika, string username, string password)
        {
            id = globalID + 1;
            globalID += 1;
            this.Zdravstvena_knjizica = knjizica;
            this.Karton = karton;
            this.Racun = racun;
            Slika = slika;
            Br = 0;
            Username = username;
            Password = password;
        }
        public Pacijent(Knjizica knjizica, Karton karton, Racun racun, Image slika)
        {
            id = globalID + 1;
            globalID += 1;
            this.Zdravstvena_knjizica = knjizica;
            this.Karton = karton;
            this.Racun = racun;
            Slika = slika;
            Br = 0;
        }
        public Pacijent()
        {
        }
        public Karton Karton { get => karton; set => karton = value; }
        public Racun Racun { get => racun; set => racun = value; }
        public Knjizica Zdravstvena_knjizica { get => zdravstvena_knjizica; set => zdravstvena_knjizica = value; }
        public long Id { get => id; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = MD5Hashdes(value); }
        public Image Slika { get => slika; set => slika = value; }

        public decimal RacunGotovina()
        {
            if (Br >= 3)
            {
                Racun.Sadasnjiracun *= decimal.Parse("0.9");
            }
            return Racun.Sadasnjiracun;
        }
        public decimal RacunRate()
        {
            if (Br < 3) Racun.Sadasnjiracun += racun.Sadasnjiracun * decimal.Parse("0.15");
            return Racun.Sadasnjiracun;
        }
        public void naplatigotovina(decimal uplaceno)
        {
            Racun.Sadasnjiracun = RacunGotovina();
            Racun.Dug = Racun.Dug + Racun.Sadasnjiracun - uplaceno;
        }
        public void naplatiRate(int rate)
        {
            Racun.Sadasnjiracun = RacunRate();
            
            Racun.Dug += Racun.Sadasnjiracun - rate * Racun.CijenaRate;
            Racun.Sadasnjiracun = rate * Racun.CijenaRate;
        }
        public string IspisiRacun()
        {
            decimal ukupno = Racun.Sadasnjiracun + Racun.Dug;
            string suma = "-----------------------\n\n  NASA MALA KLINIKA\n\n-----------------------\n\n  FISKALNI RACUN\n\n-----------------------\n";
            foreach (Pregled pregl in Karton.Pregledi)
                suma += pregl.Ordinacija.naziv + "-> " + pregl.Cijena + "KM\n";
            suma += "Dug-> " + Racun.Dug + "KM\n" +"\nIznos jedne rate-> " + Racun.CijenaRate + " KM\n\n-----------------------\n\nUKUPNO------>" + ukupno;
            Racun.Sadasnjiracun = 0;
            return suma;
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
        /*
         public static string MD5Hashsif(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
         */
    }
}
