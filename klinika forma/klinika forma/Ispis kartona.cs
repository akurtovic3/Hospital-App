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
    public partial class Ispis_kartona : Form
    {
        private Form bivsa;
        private klinika.Pacijent pac;
        public Ispis_kartona()
        {
            
            InitializeComponent();
        }

        public Ispis_kartona(Form bivsa, klinika.Pacijent pac)
        {
            this.Bivsa = bivsa;
            this.Pac = pac;
        }

        public Form Bivsa { get => bivsa; set => bivsa = value; }
        public klinika.Pacijent Pac { get => pac; set => pac = value; }

        private void Ispis_kartona_Load(object sender, EventArgs e)
        {
            textBox2.Text = pac.Zdravstvena_knjizica.ime;
            textBox1.Text = pac.Zdravstvena_knjizica.prezime;
            maskedTextBox1.Text = Convert.ToString(pac.Zdravstvena_knjizica.Datum_rodjenja);
            maskedTextBox2.Text = pac.Zdravstvena_knjizica.JMBG1;
            textBox3.Text = pac.Zdravstvena_knjizica.Adresa;
            textBox4.Text = pac.Zdravstvena_knjizica.Spol;
            richTextBox1.Text = pac.Karton.Anamneza.ispisiAnamnezu();
            richTextBox2.Text = pac.Karton.ispisiTerapije();
            pictureBox1.Image = Pac.Slika;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bivsa.ShowDialog();
            this.Close();
        }
    }
}
