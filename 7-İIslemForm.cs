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
    public partial class islemForm : Form
    {
        public islemForm()
        {
            InitializeComponent();
        }
        Oto_galeriEntities1 db = new Oto_galeriEntities1();
        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void IslemForm_Load(object sender, EventArgs e)
        {
            var islem= db.TipTable.ToList();
            cmb_is.DataSource = islem;
            cmb_is.DisplayMember = "T_Tip";
            cmb_is.ValueMember = "T_ID";

            var mu = db.MusteriTable.ToList();
            cmb_mu.DataSource = mu;
            cmb_mu.DisplayMember = "M_TC";
            cmb_mu.ValueMember = "M_ID";

            var pers = db.PersonelTable.ToList();
            cmb_pers.DataSource = pers;
            cmb_pers.DisplayMember = "P_Ad";
            cmb_pers.ValueMember = "P_ID";

            var ap=db.ArabaTable.ToList();
            cmb_pla.DataSource = ap;
            cmb_pla.DisplayMember = "A_plaka";
            cmb_pla.ValueMember = "A_ID";


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IslemTable it = new IslemTable();
            it.Is_Fiyat =Convert.ToInt32(txt_fiyat.Text);
            it.Is_Tar = dateTimePicker1.Text;
            it.A_ID = Convert.ToInt32(cmb_pla.SelectedValue.ToString());
            it.Is_ID = Convert.ToInt32(cmb_is.SelectedValue.ToString());
            it.P_ID = Convert.ToInt32(cmb_pers.SelectedValue.ToString());
            it.M_ID = Convert.ToInt32(cmb_mu.SelectedValue.ToString());
            db.IslemTable.Add(it);
            db.SaveChanges();
            MessageBox.Show("İşlem Başarılı", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
    }
}
