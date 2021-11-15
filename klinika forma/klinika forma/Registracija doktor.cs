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
    public partial class Registracija_doktor : Form
    {
        Klinika k;
        Form bivsa;
        klinika.Doktor d;
        public Klinika K { get => k; set => k = value; }
        public Form Bivsa { get => bivsa; set => bivsa = value; }
        public klinika.Doktor D { get => d; set => d = value; }

        public Registracija_doktor()
        {
            InitializeComponent();
        }

        public Registracija_doktor(Klinika k, Form bivsa)
        {
            this.K = k;
            this.Bivsa = bivsa;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
            else if (textBox4.Text != textBox5.Text) { poruka = "Passwordi se ne poklapaju"; e.Cancel = true; }
            else poruka = "";
            this.errorProvider1.SetError(textBox5, poruka);
        }

        private void Registracija_doktor_Load(object sender, EventArgs e)
        {
            foreach(klinika.Ordinacija o in k.Ordinacije)
            {
                checkedListBox1.Items.Add(o.naziv);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            klinika.Ordinacija o = new Ordinacija();
            int i = 0, br=0;
            foreach (Ordinacija ord in k.Ordinacije)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    br++;
                    o = ord;
                }
                i++;
            }
            if (br > 1)
            {
                this.errorProvider1.SetError(checkedListBox1, "Moze se oznaciti samo jedna ordinacija");
            }
            else
            {
                k.Doktori.Add(new klinika.Doktor(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox6.Text, o));
       
                this.Close();
                Bivsa.ShowDialog();
                MessageBox.Show("Uspjesno registrovan doktor!", "Informacije", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            string poruka;
            if (textBox6.Text == "") { poruka = "Morate unijeti struku"; e.Cancel = true; }
            else poruka = "";
            this.errorProvider1.SetError(textBox6, poruka);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Bivsa.ShowDialog();
        }
    }
}
