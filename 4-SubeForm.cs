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
    public partial class SubeForm : Form
    {
        public SubeForm()
        {
            InitializeComponent();
        }
        Oto_galeriEntities1 db = new Oto_galeriEntities1();
        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void SubeForm_Load(object sender, EventArgs e)
        {
            var sube = db.SubeTable.ToList();
            cmb_sube.DataSource = sube;
            cmb_sube.DisplayMember = "S_AD";
            cmb_sube.ValueMember = "S_ID";
            dataGridView1.DataSource = sube;
            int iid =Convert.ToInt32 (dataGridView1.CurrentRow.Cells[2].Value.ToString());
        }

        private void cmb_sube_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int val=Convert.ToInt32(cmb_sube.SelectedValue.ToString());
            //var iller = db.IlTable.Single(i=>i.I_ID==val);
            ////cmb_il.DataSource = iller;
            ////cmb_il.DisplayMember = "I_AD";
            ////cmb_il.ValueMember = "I_ID";
            //dataGridView1.DataSource = iller;
        }
    }
}
