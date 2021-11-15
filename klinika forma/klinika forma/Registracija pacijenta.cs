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
    public partial class Portir___registracija_pacijenta : Form
    {
        private Klinika k;
        private Form bivsa;
        private klinika.Pacijent p;
        public Klinika K { get => k; set => k = value; }
        public Form Bivsa { get => bivsa; set => bivsa = value; }
        public klinika.Pacijent P { get => p; set => p = value; }

        public Portir___registracija_pacijenta()
        {
            InitializeComponent();
        }

        public Portir___registracija_pacijenta(Klinika k, Form bivsa)
        {
            this.K = k;
            this.Bivsa = bivsa;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            string poruka;
            if (textBox1.Text == "") { poruka = "Morate unijeti ime"; e.Cancel = true; }
            else poruka = "";
            this.errorProvider1.SetError(textBox1, poruka);
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            string poruka;
            if (textBox2.Text == "") { poruka = "Morate unijeti prezime"; e.Cancel = true; }
            else poruka = "";
            this.errorProvider1.SetError(textBox2, poruka);
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            string poruka;
            if (maskedTextBox1.Text == "" || maskedTextBox1.Text.Length<13 || maskedTextBox1.Text.Length>13) { poruka = "JMBG nije validan(13 cifri)";  }
            else poruka = "";
            this.errorProvider1.SetError(maskedTextBox1, poruka);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s="";
            if (k.imaLiPacijenta(maskedTextBox1.Text))
            {

                if (k.vratiPacijenta(maskedTextBox1.Text).Zdravstvena_knjizica.ime != textBox1.Text || k.vratiPacijenta(maskedTextBox1.Text).Zdravstvena_knjizica.prezime != textBox2.Text)
                    s = "JMBG se ne slaze sa ostalim podacima";
                else P = k.vratiPacijenta(maskedTextBox1.Text);
            }
            else s = "Nema osobe s tim JMBGom";
            this.errorProvider1.SetError(button1, s);
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            string poruka;
            if (textBox3.Text == "") { poruka = "Morate unijeti username"; e.Cancel = true; }
            else poruka = "";
            this.errorProvider1.SetError(textBox3, poruka);
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            string poruka;
            if (textBox4.Text == "") { poruka = "Morate unijeti password"; e.Cancel = true; }
            else poruka = "";
            this.errorProvider1.SetError(textBox4, poruka);
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            string poruka;
            if (textBox5.Text == "") { poruka = "Morate unijeti password"; e.Cancel = true; }
            else if(textBox4.Text!=textBox5.Text) { poruka = "Passwordi se ne poklapaju"; e.Cancel = true; }
            else poruka = "";
            this.errorProvider1.SetError(textBox5, poruka);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            P.Username = textBox3.Text;
            p.Password = textBox5.Text;
            MessageBox.Show("Uspjesno ste se registrovali", "Informacije", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Bivsa.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Bivsa.ShowDialog();
        }

        private void Portir___registracija_pacijenta_Load(object sender, EventArgs e)
        {

        }
    }
}
