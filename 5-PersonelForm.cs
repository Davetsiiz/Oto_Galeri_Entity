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
    public partial class PersonelForm : Form
    {
        public PersonelForm()
        {
            InitializeComponent();
        }
        Oto_galeriEntities1 db = new Oto_galeriEntities1();
        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                btn_ara.Enabled = true;
                
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        TextBox txt = item as TextBox;
                        txt.ReadOnly = true;

                    }
                    txt_ka.ReadOnly = false;
                }

            }
            else if (checkBox1.Checked == false)
            {
                btn_ara.Enabled = false;
               
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        TextBox txt = item as TextBox;
                        txt.ReadOnly = false;

                    }


                }

            }
        }

        private void txt_ka_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (txt_ka.Text != null)
                {
                    var pbilgi = db.PSifreTable.Where(p => p.PS_Nick.StartsWith(txt_ka.Text)).ToList();
                    dataGridView1.DataSource = pbilgi;
                    if (dataGridView1.FirstDisplayedCell != null)
                    {
                        int pid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                        var pidb = db.PersonelTable.Where(p => p.P_ID == pid).ToList();
                        dataGridView1.DataSource = pidb;
                        txt_as.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        int sid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                        var sidl = db.SubeTable.Where(s => s.S_ID == sid).ToList();
                        dataGridView1.DataSource = sidl;
                        txt_sube.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        dataGridView1.DataSource = db.PersonelTable.ToList();
                    }
                }
            }

        }

    }
}
