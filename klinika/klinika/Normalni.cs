using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace klinika
{
    public class Normalni : Pacijent
    {
        public Normalni() : base()
        {
        }

        public Normalni(Knjizica knjizica, Karton karton, Racun racun, Image slika, string username, string password ) : base(knjizica, karton, racun, slika, username, password)
        {
        }
        public Normalni(Knjizica knjizica, Karton karton, Racun racun, Image slika) : base(knjizica, karton, racun, slika)
        {
        }
    }
}
