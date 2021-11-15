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
    
    public partial class Form1 : Form
    {
        private Klinika k;
        
        public Form1(Klinika kl)
        {
            K = kl;
            InitializeComponent();
        }

        public Klinika K { get => k; set => k = value; }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if(!(radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked)){
                    toolStripStatusLabel1.Text = "Nije oznacen tip korisnika";
               }
            else if (textBox1.Text.Equals("")){
                toolStripStatusLabel1.Text = "Nije unesen username";
            }
            else if (textBox2.Text.Equals(""))
            {
                toolStripStatusLabel1.Text = "Nije unesen password";
            }
            else if(radioButton1.Checked && k.imaLiDoktora(textBox1.Text, textBox2.Text))
            {
                this.Hide();
                Doktor form2 = new Doktor(k,k.vratiDoktora(textBox1.Text, textBox2.Text));
                form2.ShowDialog();
                this.Close();
                

            }
            else if(radioButton2.Checked && k.imaLiPortira(textBox1.Text, textBox2.Text))
            {
                this.Hide();
                Portir form2 = new Portir(k, k.vratiPortira(textBox1.Text, textBox2.Text));
                form2.ShowDialog();
                this.Close();
                
            }
            else if (radioButton3.Checked && k.imaLiMedicinske(textBox1.Text, textBox2.Text))
            {
                Medicinski_tehnicar form2 = new Medicinski_tehnicar(k, k.vratiMedicinsku(textBox1.Text, textBox2.Text));
                form2.ShowDialog();
                this.Close();
                
            }
            else if (radioButton4.Checked && k.imaLiPacijenta(textBox1.Text, textBox2.Text))
            {
                this.Hide();
                Pacijent form2 = new Pacijent(k, k.vratiPacijenta(textBox1.Text, textBox2.Text));
                form2.ShowDialog();
                this.Close();
                
            }
            else
            {
                toolStripStatusLabel1.Text = "Niste registrovani ili niste unijeli tacne podatke.";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void statusStrip1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(305, 60, 35, 105);
            Rectangle rect3 = new Rectangle(265, 55, 116, 116);
            e.Graphics.FillRectangle(Brushes.Black, rect3);
            e.Graphics.FillEllipse(Brushes.White, rect3);
            e.Graphics.FillRectangle(Brushes.Red, rect);
            Font drawFont = new Font("Arial", 23);
            e.Graphics.DrawString(" \nM\n ", drawFont, Brushes.Black, rect);
            Rectangle rect1 = new Rectangle(270, 95, 35, 35);
            e.Graphics.FillRectangle(Brushes.Red, rect1);
            e.Graphics.DrawString("N", drawFont, Brushes.Black, rect1);
            Rectangle rect2 = new Rectangle(340, 95, 35, 35);
            e.Graphics.FillRectangle(Brushes.Red, rect2);
            e.Graphics.DrawString("K", drawFont, Brushes.Black, rect2);
            
          //  e.Graphics.DrawEllipse(Pens.Red, rect3);
            e.Graphics.DrawLine(Pens.Black, new Point(264, 54), new Point(381, 54));
            e.Graphics.DrawLine(Pens.Black, new Point(264, 54), new Point(264, 171));
            e.Graphics.DrawLine(Pens.Black, new Point(264, 171), new Point(381, 171));
            e.Graphics.DrawLine(Pens.Black, new Point(381, 54), new Point(381, 171));

            //e.Graphics.FillRectangle(Brushes.Red, rect2);

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form f = new Portir___registracija_pacijenta(k, this);
            this.Hide();
            f.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            string poruka;
            if (textBox1.Text == "") { poruka = "Morate unijeti username"; e.Cancel = true; }
            else poruka = "";
            this.errorProvider1.SetError(textBox1, poruka);
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            string poruka;
            if (textBox2.Text == "") { poruka = "Morate unijeti password"; e.Cancel = true; }
            else poruka = "";
            this.errorProvider1.SetError(textBox2, poruka);
        }

        private void groupBox1_Validating(object sender, CancelEventArgs e)
        {
            string poruka = "";
            if(!(radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked))
            {
                poruka = "Morate odabrati tip korisnika!";
              
            }
            this.errorProvider1.SetError(groupBox1, poruka);
        }
    }
}
