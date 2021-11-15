using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using klinika;

namespace klinika_forma
{
    public partial class Ispis_racuna : Form
    {
        private Klinika k;
        private Form bivsa;
        private klinika.Pacijent pac;
        public Ispis_racuna()
        {
            InitializeComponent();
        }
        public Ispis_racuna(Klinika kl, Form bivsa)
        {
            this.bivsa = bivsa;
            this.k = kl;
            Izbor_pacijenta f = new Izbor_pacijenta(k, this);
            Pac = f.Pac;
            
        }
        public Ispis_racuna(Form bivsa, klinika.Pacijent pac)
        {
            this.bivsa = bivsa;
            this.pac = pac;
            
        }

        public Form Bivsa { get => bivsa; set => bivsa = value; }
        public klinika.Pacijent Pac { get => pac; set => pac = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            Bivsa.ShowDialog();
            this.Close();
        }

        private void Ispis_racuna_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = pac.IspisiRacun();
        }
    }
}
