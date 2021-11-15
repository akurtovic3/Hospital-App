using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using klinika;

namespace klinika_forma
{
    public partial class Slike : UserControl
    {
        
        private Image slika;
        private DateTime datum;
        public Slike()
        {
            InitializeComponent();
        }

        public Image Slika { get => slika;  }
        public DateTime Datum { get => datum;  }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Izaberite sliku"; dlg.Filter = "jpg files (*.jpg)|*.jpg";

                if (dlg.ShowDialog() == DialogResult.OK) { pictureBox1.Image = new Bitmap(dlg.FileName); slika = pictureBox1.Image;  }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DateTime.Now.Month - dateTimePicker1.Value.Month >= 6) { pictureBox1 = new PictureBox(); slika = null; }
            else datum = dateTimePicker1.Value;
        }
        public Image vratiSliku()
        {
            return slika;
        }
        public DateTime vratiDatum()
        {
            return datum;
        }

        private void Slike_Load(object sender, EventArgs e)
        {

        }
    }
}
