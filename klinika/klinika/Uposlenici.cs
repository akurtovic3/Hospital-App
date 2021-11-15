using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace klinika
{
    public abstract class Uposlenici
    {
        public static readonly decimal sigurnaplata = 1000;
        public string ime { get; set; }
        public string prezime { get; set; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = MD5Hashdes(value); }

        private string username;
        private string password;
        public Uposlenici(string ime, string prezime, string username, string password)
        {
            this.ime = ime;
            this.prezime = prezime;
            Username = username;
            Password = password;
        }
        public Uposlenici(string ime, string prezime)
        {
            this.ime = ime;
            this.prezime = prezime;
        }
        public Uposlenici()
        {
        }
      /*  public static string MD5Hashsif(string text)
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
        }*/
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
        public abstract Decimal plata();
    }
}
