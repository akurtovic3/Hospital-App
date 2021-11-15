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
    public partial class IspisOrdinacijaCekanje : Form
    {
        private Klinika k;
        private Form bivsa;
        public IspisOrdinacijaCekanje()
        {
            InitializeComponent();
        }

        public IspisOrdinacijaCekanje(Klinika k, Form bivsa)
        {
            this.K = k;
            this.Bivsa = bivsa;
            
        }

        public Klinika K { get => k; set => k = value; }
        public Form Bivsa { get => bivsa; set => bivsa = value; }

        private void IspisOrdinacijaCekanje_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Bivsa.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = k.ispisiOrdinacijeCekanje();
        }
    }
}
