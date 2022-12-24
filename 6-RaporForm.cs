using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oto_Galeri
{
    public partial class RaporForm : Form
    {
        public RaporForm()
        {
            InitializeComponent();
        }
        Oto_galeriEntities1 db = new Oto_galeriEntities1();
        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void yuvarlak_Button1_Click(object sender, EventArgs e)
        {
            int adet = db.ArabaTable.Count();
            lbl_asay.Text = adet.ToString();
        }

        private void yuvarlak_Button2_Click(object sender, EventArgs e)
        {
            string fiyat = db.ArabaTable.Max(a => a.A_Fiyat).ToString();
            lbl_amax.Text = fiyat+" ₺";
        }

        private void yuvarlak_Button3_Click(object sender, EventArgs e)
        {
            int adet = db.SubeTable.Count();
            lbl_ssa.Text=adet.ToString();
        }

        private void yuvarlak_Button7_Click(object sender, EventArgs e)
        {
            string fiyat = db.ArabaTable.Sum(s => s.A_Fiyat).ToString();
            lbl_tfi.Text = fiyat + " ₺";
        }

        private void yuvarlak_Button4_Click(object sender, EventArgs e)
        {
            string adet = db.MusteriTable.Count().ToString();
            lbl_msa.Text = adet;

        }

        private void yuvarlak_Button10_Click(object sender, EventArgs e)
        {
            List<ArabaTable> lar = db.ArabaTable.Where(l => l.A_Marka.StartsWith(textBox1.Text)).ToList();
            dataGridView1.DataSource = lar;
        }

        private void yuvarlak_Button9_Click(object sender, EventArgs e)
        {
            string isl= db.IslemTable.Max(i => i.Is_Fiyat).ToString();
            lbl_is.Text = isl+" ₺";
        }

        private void yuvarlak_Button6_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != null)
            {
                int mid = Convert.ToInt32(textBox2.Text);
                List<MusteriTable> mt = db.MusteriTable.Where(m => m.M_ID == mid).ToList();
                dataGridView1.DataSource = mt;
            }
            else if (textBox2.Text == null)
                MessageBox.Show("Lütfen TextBox'ı Doldurunuz");

        }

        private void yuvarlak_Button5_Click(object sender, EventArgs e)
        {
            string ps = db.PersonelTable.Count().ToString();
            lbl_ps.Text = ps;
        }

        private void yuvarlak_Button8_Click(object sender, EventArgs e)
        {
            List<MusteriTable> list = db.MusteriTable.OrderBy(p => p.M_AD).ToList();
            dataGridView1.DataSource = list;

        }
    }
}
