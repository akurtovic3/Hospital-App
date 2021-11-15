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
    public partial class Doktor : Form
    {
        private klinika.Doktor dok;
        private Klinika k;
        private Form bivsa;
        private klinika.Pacijent pac;
        private klinika.Terapija t;
        public Doktor(Klinika k1, klinika.Doktor d)
        {
            Dok = d;
            k = k1;
            
            InitializeComponent();
        }
        public Doktor(Klinika k1, klinika.Doktor d,  Form bivsaa)
        {
            Dok = d;
            k = k1;
            
            Bivsa = bivsaa;
            InitializeComponent();
        }

        public klinika.Doktor Dok { get => dok; set => dok = value; }
        public Klinika Klinika { get => k; set => k = value; }
        public Form Bivsa { get => bivsa; set => bivsa = value; }
        public klinika.Pacijent Pac { get => pac; set => pac = value; }
        public klinika.Terapija T { get => t; set => t = value; }

        private void Doktor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Bivsa!=null) { Bivsa.Show(); }
            else
            {
                Form form2 = new Form1(k);
                form2.ShowDialog();
            }
        }

        private void kartonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Ispis_kartona();
            Form f2 = new Izbor_pacijenta(k, this, f);
            f2.ShowDialog();
        }

        private void ordinacijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new IspisOrdinacijaCekanje(k,this);
            f.ShowDialog();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pregledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new Terapija(k, dok, pac, this);
            this.Hide();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Bivsa != null)
            {
                this.Close();
                Bivsa.ShowDialog();
            }
            else
            {
                Form f = new Form1(k);
                this.Close();
                f.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (T != null)
            {
                pac.Karton.Pregledi.Add(new klinika.Pregled(dateTimePicker1.Value, richTextBox1.Text, richTextBox2.Text, T, true, Dok.Ordinacija, Dok, Convert.ToDecimal(textBox1.Text)));
                if (!(richTextBox1.Text != "" || richTextBox2.Text != "" || textBox1.Text != ""))
                {
                    MessageBox.Show("Uspjesno unesen pregled!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                t = new klinika.Terapija();
            }
            else statusStrip1.Text = "Nije dodana terapija!";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "" && k.imaLiPacijenta(maskedTextBox1.Text))
            {
                pac = k.vratiPacijenta(maskedTextBox1.Text);
            }
            else
                MessageBox.Show("Nema registrovanog pacijenta s tim maticnim brojem!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void izadjiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form f = new Form1(k);
            f.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Doktor_Load(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            groupBox2.Visible = false;
        }
    }
}
