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
    public partial class Medicinski_tehnicar : Form
    {
        private Klinika k;
        private klinika.Medicinski_tehnicar med;
        private klinika.HitanSlucaj hitpac;
        private klinika.Normalni norpac;
        private klinika.Pacijent pac;

        public Medicinski_tehnicar()
        {
            
            InitializeComponent();
        }

        public Medicinski_tehnicar(Klinika k, klinika.Medicinski_tehnicar med)
        {
            this.k = k;
            this.med = med;
            
            InitializeComponent();
        }

        public Klinika K { get => k; set => k = value; }
        public klinika.Medicinski_tehnicar Med { get => med; set => med = value; }
        public HitanSlucaj Hitpac { get => hitpac; set => hitpac = value; }
        public Normalni Norpac { get => norpac; set => norpac = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "") {
                Hitpac = new HitanSlucaj();
                Hitpac.Prva_pomoc = textBox1.Text;
                if (textBox2.Text != "")
                {
                    Hitpac.Uzrok_smrti = textBox2.Text;
                    Hitpac.Vrijeme_obdukcije = Convert.ToDateTime(maskedTextBox1.Text);
                }
                groupBox1.Visible = false;
                groupBox3.Visible = true;
                slike3.Visible = true;
                button3.Visible = true;
                button5.Visible = true;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new Form1(k);
            f.ShowDialog();
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new Medicinski_tehnicar(k, med);
            f.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || maskedTextBox5.Text == "" || maskedTextBox4.Text == "") statusStrip1.Text = "Nisu uneseni svi podaci";
            Hitpac.Slika = slike3.vratiSliku();
            Hitpac.Zdravstvena_knjizica.ime = textBox7.Text;
            Hitpac.Zdravstvena_knjizica.prezime = textBox8.Text;
            Hitpac.Zdravstvena_knjizica.Adresa = textBox9.Text;
            Hitpac.Zdravstvena_knjizica.Datum_rodjenja = Convert.ToDateTime(maskedTextBox5.Text);
            Hitpac.Zdravstvena_knjizica.JMBG1 = maskedTextBox4.Text;
            if (radioButton3.Checked)
                Hitpac.Zdravstvena_knjizica.Spol = "M";
            else Hitpac.Zdravstvena_knjizica.Spol = "Z";
            k.Pacijenti.Add(Hitpac);
            Hitpac = new HitanSlucaj();
        }

        private void slike3_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            norpac = new klinika.Normalni();
            Norpac.Slika = slike4.vratiSliku();
            Norpac.Zdravstvena_knjizica.ime = textBox6.Text;
            Norpac.Zdravstvena_knjizica.prezime = textBox5.Text;
            Norpac.Zdravstvena_knjizica.Adresa = textBox4.Text;
            Norpac.Zdravstvena_knjizica.JMBG1 = maskedTextBox3.Text;
            Norpac.Zdravstvena_knjizica.Datum_rodjenja = Convert.ToDateTime(maskedTextBox2.Text);
            k.Pacijenti.Add(norpac);
            norpac = new Normalni();
            MessageBox.Show("Uspjesno registrovan pacijent!", "Informacije", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Izadji_Click(object sender, EventArgs e)
        {
            Form f = new Form1(k);
            f.ShowDialog();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = k.ispisiOrdinacije();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!k.imaLiPacijenta(maskedTextBox6.Text))

                statusStrip1.Text = "Nema registrovanog pacijenta sa unesenim maticnim brojem.";
            else {
                pac = k.vratiPacijenta(maskedTextBox6.Text);
                foreach (klinika.Ordinacija o in k.Ordinacije)
                    if (o.Aktivna)
                        checkedListBox1.Items.Add(o.naziv);
            }
        }
    

    //    private void tabPage4_Click(object sender, EventArgs e)
      //  {

        //}

        private void button7_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach(klinika.Ordinacija o in k.Ordinacije)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    pac.Karton.Rasporedi.Ordinacije.Add(o);
                    pac.Karton.Rasporedi.Cekanje.Add(o.Br + 1);
                    o.Br = o.Br + 1;
                    i++;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form f = new Form1(k);
            f.ShowDialog();
            this.Close();
        }

        private void Medicinski_tehnicar_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox3.Visible = false;
            slike3.Visible = false;
            button3.Visible = false;
            button5.Visible = false;
        }
    }
}
