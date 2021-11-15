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
    public partial class Raspored_pregleda : Form
    {
        private Klinika k;
        private klinika.Pacijent pac;
        private Form bivsa;

        public Raspored_pregleda()
        {
            InitializeComponent();
        }

        public Raspored_pregleda(Klinika k, klinika.Pacijent pac, Form bivsa)
        {
            this.K = k;
            this.Pac = pac;
            this.Bivsa = bivsa;
        }

        public Klinika K { get => k; set => k = value; }
        public klinika.Pacijent Pac { get => pac; set => pac = value; }
        public Form Bivsa { get => bivsa; set => bivsa = value; }

        private void Raspored_pregleda_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = Pac.Karton.Rasporedi.ispisiRaspored();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bivsa.ShowDialog();
            this.Close();
        }
    }
}
