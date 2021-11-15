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
    public partial class Portir : Form
    {
        private Klinika k;
        private klinika.Portir port;
        public Portir()
        {
            InitializeComponent();
        }

        public Portir(Klinika k, klinika.Portir port)
        {
            this.k = k;
            this.port = port;
        }

        public Klinika K { get => k; set => k = value; }
        public klinika.Portir Port { get => port; set => port = value; }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.Hide();
                Form f = new Naplata(k,this);
                f.ShowDialog();
            }
            else if (radioButton2.Checked)
            {
                this.Hide();
               Form f = new Ispis_racuna();
           //    this.groupBox1.Visible = true;
               f.ShowDialog();
            }
            else
            {
                statusStrip1.Text = "Nijedna opcija nije oznacena!";
            }
        }

        private void Portir_Load(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Form f = new Registracija_doktor(k, this);
            this.Hide();
            f.ShowDialog();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Form f = new Registracija_medicinskog_tehnicara(k, this);
            this.Hide();
            f.ShowDialog();
        }
    }
}
