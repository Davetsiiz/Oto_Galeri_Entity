using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;

namespace Oto_Galeri
{
    public partial class ArabaForm : Form
    {
        public ArabaForm()
        {
            InitializeComponent();
        }
        Oto_galeriEntities1 db = new Oto_galeriEntities1();
        private void btn_home_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void ArabaForm_Load(object sender, EventArgs e)
        {
            btn_ara.Enabled = false;
            var sube = db.SubeTable.ToList();
            cmb_sube.DataSource = sube;
            cmb_sube.DisplayMember = "S_AD";
            cmb_sube.ValueMember = "S_ID";
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                btn_ara.Enabled = true;
                btn_ekle.Enabled = false;
                btn_sil.Enabled = false;
                btn_update.Enabled = false;
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        TextBox txt = item as TextBox;
                        txt.ReadOnly = true;

                    }
                }
                cmb_sube.Enabled = false;
                txt_pla.ReadOnly = false;
            }
            else if (checkBox1.Checked == false)
            {
                btn_ara.Enabled = false;
                btn_ekle.Enabled = true;
                btn_sil.Enabled = true;
                btn_update.Enabled = true;
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        TextBox txt = item as TextBox;
                        txt.ReadOnly = false;

                    }

                }
                cmb_sube.Enabled = true;
            }
        }

        private void txt_pla_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (txt_pla.Text != null)
                {
                    List<ArabaTable> abilgi = db.ArabaTable.Where(p => p.A_Plaka.StartsWith(txt_pla.Text)).ToList();
                    dataGridView1.DataSource = abilgi;
                    if (dataGridView1.FirstDisplayedCell != null)
                    {
                        txt_ano.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        txt_marka.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                        txt_Model.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                        txt_tip.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                        txt_renk.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                        txt_yakit.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                        txt_vites.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                        txt_yil.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                        txt_fiyat.Text = (dataGridView1.CurrentRow.Cells[9].Value.ToString());
                        txt_tarih.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                        int de = Convert.ToInt32(dataGridView1.CurrentRow.Cells[12].Value);
                        var ibil = db.SubeTable.Where(x => x.S_ID == de).ToList();
                        cmb_sube.DataSource = ibil;
                        cmb_sube.DisplayMember = "S_AD";
                        cmb_sube.ValueMember = "S_ID";

                    }
                    else if (dataGridView1.FirstDisplayedCell == null)
                    {
                        foreach (Control item in this.Controls)
                        {
                            if (item is TextBox)
                            {
                                if (item != txt_pla)
                                {
                                    TextBox txt = item as TextBox;
                                    txt.Clear();
                                }

                            }
                            if (item is ComboBox)
                            {
                                ComboBox cmb = item as ComboBox;
                                cmb.SelectedIndex = -1;
                            }

                        }
                    }
                }
            }
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            ArabaTable at = new ArabaTable();
            at.A_No = txt_ano.Text;
            at.A_Marka = txt_marka.Text;
            at.A_Model = txt_Model.Text;
            at.A_Tip = txt_tip.Text;
            at.A_Renk = txt_renk.Text;
            at.A_Yakit = txt_yakit.Text;
            at.A_Vites = txt_vites.Text;
            at.A_Yil = txt_yil.Text;
            at.A_Fiyat = Convert.ToInt32(txt_fiyat.Text);
            at.A_Tarih = txt_tarih.Text;
            at.S_ID = Convert.ToInt32(cmb_sube.SelectedValue.ToString());
            at.A_Plaka = txt_pla.Text;
            db.ArabaTable.Add(at);
            db.SaveChanges();
            MessageBox.Show("Yeni Araba Eklendi", "SONUÇ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            var at = db.ArabaTable.Single(a => a.A_Plaka == txt_pla.Text);
            var ai = at.A_ID;
            at.A_No = txt_ano.Text;
            at.A_Marka = txt_marka.Text;
            at.A_Model = txt_Model.Text;
            at.A_Tip = txt_tip.Text;
            at.A_Renk = txt_renk.Text;
            at.A_Yakit = txt_yakit.Text;
            at.A_Vites = txt_vites.Text;
            at.A_Yil = txt_yil.Text;
            int af = Convert.ToInt32(txt_fiyat.Text);
            at.A_Fiyat = af;
            at.A_Tarih = txt_tarih.Text;
            at.S_ID = Convert.ToInt32(cmb_sube.SelectedValue.ToString());
            db.ArabaTable.AddOrUpdate(at);
            db.SaveChanges();
            MessageBox.Show("Güncelleme Başarılı", "SONUÇ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (txt_pla != null)
            {

                ArabaTable att = new ArabaTable();
                var at = db.ArabaTable.Single(a => a.A_Plaka == txt_pla.Text);
                if (at != null)
                {
                    db.ArabaTable.Remove(at);
                    db.SaveChanges();

                }
                else
                    MessageBox.Show("Hata!\n Veri yok!");
            }
            else
                MessageBox.Show("Bilgileri Giriniz");

            MessageBox.Show("Silme İşlemi Başarılı", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
