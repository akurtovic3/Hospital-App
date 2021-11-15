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
    public partial class Terapija : Form
    {
        private Klinika k;
        private klinika.Pacijent p;
        private klinika.Doktor d;
        private klinika.Terapija t;
        private Doktor bivsa;
        public Terapija()
        {
            InitializeComponent();
        }

        public Terapija(Klinika k,  klinika.Doktor d, klinika.Pacijent p, Doktor bivsa)
        {
            this.k = k;
            this.p = p;
            this.d = d;
            this.bivsa = bivsa;
            
        }

        public Klinika K { get => k; set => k = value; }
        public klinika.Pacijent P { get => p; set => p = value; }
        public klinika.Doktor D { get => d; set => d = value; }
        public Doktor Bivsa { get => bivsa; set => bivsa = value; }
        public klinika.Terapija T { get => t; set => t = value; }

        private void Terapija_Load(object sender, EventArgs e)
        {
            textBox2.Text = p.Zdravstvena_knjizica.ime + " " + p.Zdravstvena_knjizica.prezime;
            textBox1.Text = d.ime + " " + d.prezime;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((radioButton1.Checked || radioButton2.Checked) && richTextBox1.Text != "")
            {
                t = new klinika.Terapija(false, dateTimePicker1.Value, true, richTextBox1.Text, radioButton2.Checked);
                this.Close();
                Bivsa.ShowDialog();
            }
            else statusStrip1.Text = "Nisu uneseni svi potrebni podaci";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bivsa.ShowDialog();
            Bivsa.T = this.T;
            this.Close();
        }
    }
}
