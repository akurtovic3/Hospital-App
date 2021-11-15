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
    public partial class Naplata : Form
    {
        private Klinika k;
        private Form bivsa;
        private klinika.Pacijent pac;

        public Naplata()
        {
            InitializeComponent();
        }

        public Naplata(Klinika k, Form bivsa)
        {
            this.k = k;
            this.bivsa = bivsa;
        }

        public Klinika K { get => k; set => k = value; }
        public Form Bivsa { get => bivsa; set => bivsa = value; }
        public klinika.Pacijent Pac { get => pac; set => pac = value; }

        private void button3_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "") toolStripStatusLabel1.Text = "Morate unijeti JMBG";
            if (!K.imaLiPacijenta(maskedTextBox1.Text))
            {
                toolStripStatusLabel1.Text = "Nema pacijenta sa unesenim maticnim brojem!";
            }
            else pac = k.vratiPacijenta(maskedTextBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                pac.naplatiRate(Convert.ToInt32(textBox1.Text));
            else if (radioButton1.Checked)
                pac.naplatigotovina(Convert.ToDecimal(textBox1.Text));
            else statusStrip1.Text = "Morate odabrati tip uplate";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bivsa.ShowDialog();
            this.Close();
        }

        private void Naplata_Load(object sender, EventArgs e)
        {

        }
    }
}
