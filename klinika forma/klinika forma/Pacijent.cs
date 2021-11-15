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
    public partial class Pacijent : Form
    {
        private Klinika k;
        private klinika.Pacijent pac;

        public Klinika K { get => k; set => k = value; }
        public klinika.Pacijent Pac { get => pac; set => pac = value; }

        public Pacijent()
        {
            InitializeComponent();
        }

        public Pacijent(Klinika k, klinika.Pacijent pac)
        {
            this.K = k;
            this.Pac = pac;
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void Pacijent_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (treeView2.SelectedNode.Text.Equals("Karton"))
            {
                Form f = new Ispis_kartona(this, pac);
                this.Hide();
                richTextBox1.Text = "";
                f.ShowDialog();
            }
            else if (treeView2.SelectedNode.Text.Equals("Raspored"))
            {
                Form f = new Raspored_pregleda(k, pac, this);
                richTextBox1.Text = "";
                this.Hide();
                f.ShowDialog();
            }
            else if (treeView2.SelectedNode.Text.Equals("Aktivne ordinacije"))
            {
                richTextBox1.Text = k.ispisiOrdinacije();
            }
            else statusStrip1.Text = "Morate oznaciti neku opciju";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new Form1(k);
            
            this.Close();
            f.ShowDialog();

        }
    }
}
