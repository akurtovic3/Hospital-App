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
    public partial class Izbor_pacijenta : Form
    {
        private Klinika k;
        private Form forma;
        private klinika.Pacijent pac;
        private Form sljedeca;

        public Klinika K { get => k; set => k = value; }
        public Form Forma { get => forma; set => forma = value; }
        public klinika.Pacijent Pac { get => pac; set => pac = value; }
        public Form Sljedeca { get => sljedeca; set => sljedeca = value; }

        public Izbor_pacijenta()
        {
            InitializeComponent();
        }
        public klinika.Pacijent vratiPacijenta()
        {
            return Pac;
        }
        public Izbor_pacijenta(Klinika k, Form forma)
        {
            this.k = k;
            this.forma = forma;
        }
        public Izbor_pacijenta(Klinika k, Form forma, Form sljedeca)
        {
            this.k = k;
            this.forma = forma;
            this.sljedeca = sljedeca;
        }
        public Izbor_pacijenta(Klinika k, Form forma, Ispis_kartona sljedeca)
        {
            this.k = k;
            this.forma = forma;
            this.sljedeca = sljedeca;
        }

        private void Izbor_pacijenta_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "")
            {
                statusStrip1.Text = "Morate unijeti JMBG";
            }
            if (sljedeca == null)
            {
                if (K.imaLiPacijenta(maskedTextBox1.Text))
                {
                    Pac = K.vratiPacijenta(maskedTextBox1.Text);
                }
                forma.ShowDialog();
                this.Close();
            }
            else if((Sljedeca as Ispis_kartona) != null)
            {
                if (K.imaLiPacijenta(maskedTextBox1.Text))
                {
                    Pac = K.vratiPacijenta(maskedTextBox1.Text);
                }
                (Sljedeca as Ispis_kartona).Pac = this.Pac;
                Sljedeca.ShowDialog();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            forma.ShowDialog();
            this.Close();

        }
    }
}
