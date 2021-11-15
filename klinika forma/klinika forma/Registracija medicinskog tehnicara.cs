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
    public partial class Registracija_medicinskog_tehnicara : Form
    {
        Klinika k;
        Form bivsa;

        public Klinika K { get => k; set => k = value; }
        public Form Bivsa { get => bivsa; set => bivsa = value; }

        public Registracija_medicinskog_tehnicara()
        {
            InitializeComponent();
        }

        public Registracija_medicinskog_tehnicara(Klinika k, Form bivsa)
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

        private void button1_Click(object sender, EventArgs e)
        {
            k.Ostali.Add(new klinika.Medicinski_tehnicar(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text));
            this.Close();
            Bivsa.ShowDialog();
            MessageBox.Show("Uspjesno dodan medicinski tehnicar", "Informacije", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Bivsa.ShowDialog();
        }

        private void Registracija_medicinskog_tehnicara_Load(object sender, EventArgs e)
        {

        }
    }
}
