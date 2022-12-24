using Oto_Galeri;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using GroupBox = System.Windows.Forms.GroupBox;
using RadioButton = System.Windows.Forms.RadioButton;

namespace Oto_Galeri
{
    public partial class MusteriForm : Form
    {
        public MusteriForm()
        {
            InitializeComponent();
        }
        Oto_galeriEntities1 db = new Oto_galeriEntities1();
        public void getir()
        {

            if (dataGridView1.FirstDisplayedCell != null)
            {


                txt_ad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txt_soy.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txt_tel.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                if (dataGridView1.CurrentRow.Cells[5].Value.ToString() == "ERKEK")
                {
                    rb_erk.Checked = true;
                    rb_kad.Checked = false;
                }
                else if (dataGridView1.CurrentRow.Cells[5].Value.ToString() == "KADIN")
                {
                    rb_kad.Checked = true;
                    rb_erk.Checked = true;
                }
                else
                {
                    rb_kad.Checked = false;
                    rb_erk.Checked = false;
                }
                txt_dyil.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txt_mail.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                if (dataGridView1.CurrentRow.Cells[8].Value.ToString() == "Var")
                {
                    rb_var.Checked = true;
                    rb_yok.Checked = false;
                }
                else if (dataGridView1.CurrentRow.Cells[8].Value.ToString() == "Yok")
                {
                    rb_var.Checked = false;
                    rb_yok.Checked = true;
                }
                else
                {
                    rb_var.Checked = false;
                    rb_yok.Checked = false;
                }
                int de = Convert.ToInt32(dataGridView1.CurrentRow.Cells[9].Value);
                //MessageBox.Show(de.ToString());
                var ibil = db.IlTable.Where(x => x.I_ID == de).ToList();
                cmb_il.DataSource = ibil;
                cmb_il.DisplayMember = "I_AD";
                cmb_il.ValueMember = "I_ID";
            }





        }
        private void yuvarlak_Button1_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void MusteriForm_Load(object sender, EventArgs e)
        {
            btn_ara.Enabled = false;
            var iller = db.IlTable.ToList();
            cmb_il.DataSource = iller;
            cmb_il.DisplayMember = "I_AD";
            cmb_il.ValueMember = "I_ID";

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                btn_ara.Enabled = true;
                btn_ekle.Enabled = false;
                btn_sil.Enabled = false;
                btn_update.Enabled = false;
                txt_dyil.ReadOnly = true;
                txt_ad.ReadOnly = true;
                txt_soy.ReadOnly = true;
                txt_mail.ReadOnly = true;
                txt_tel.ReadOnly = true;
                rb_erk.Enabled = false;
                rb_kad.Enabled = false;
                cmb_il.Enabled = false;
                rb_var.Enabled = false;
                rb_yok.Enabled = false;

                txt_nick.Visible = false;
                txt_pass.Visible = false;
                txt_tpass.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label10.Visible = false;
            }
            else if (checkBox1.Checked == false)
            {
                btn_ara.Enabled = false;
                btn_ekle.Enabled = true;
                btn_sil.Enabled = true;
                btn_update.Enabled = true;
                txt_dyil.ReadOnly = false;
                txt_tel.ReadOnly = false;
                txt_ad.ReadOnly = false;
                txt_soy.ReadOnly = false;
                txt_mail.ReadOnly = false;
                rb_erk.Enabled = true;
                rb_kad.Enabled = true;
                cmb_il.Enabled = true;
                rb_var.Enabled = true;
                rb_yok.Enabled = true;

                txt_nick.Visible = true;
                txt_pass.Visible = true;
                txt_tpass.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                label10.Visible = true;
            }
        }



        private void txt_tc_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (txt_tc.Text != null)
                {
                    List<MusteriTable> mbilgi = db.MusteriTable.Where(p => p.M_TC.StartsWith(txt_tc.Text)).ToList();
                    dataGridView1.DataSource = mbilgi;
                    getir();

                }
            }
        }



        private void btn_ekle_Click(object sender, EventArgs e)
        {
            string cins;
            string ehl;
            MusteriTable Mt = new MusteriTable();

            Mt.M_TC = txt_tc.Text;
            Mt.M_AD = txt_ad.Text;
            Mt.M_Soyad = txt_soy.Text;
            Mt.M_Tel = txt_tel.Text;
            Mt.M_Dyil = txt_dyil.Text;
            Mt.M_Mail = txt_mail.Text;
            Mt.I_ID = Convert.ToInt32(cmb_il.SelectedValue.ToString());
            if (rb_erk.Checked == true)
            {
                cins = "ERKEK";
                Mt.M_Cins = cins;
            }
            else if (rb_kad.Checked == true)
            {
                cins = "KADIN";
                Mt.M_Cins = cins;
            }
            else if (rb_erk.Checked == false && rb_kad.Checked == false) { MessageBox.Show("Cinsiyet Seçimi Yapınız.", "Cinsiyet seçimi!"); }



            if (rb_var.Checked == true)
            {
                ehl = "Var";
                Mt.M_Ehliyet = ehl;

            }
            else if (rb_yok.Checked == true)
            {
                ehl = "Yok";
                Mt.M_Ehliyet = ehl;
            }
            else if (rb_yok.Checked == false && rb_var.Checked == false)
            {
                MessageBox.Show("Ehliyet Seçimi Yapınız.", "Ehliyet seçimi!");

            }
            db.MusteriTable.Add(Mt);
            db.SaveChanges();

            //////////////////////////
            MSifreTable Ms = new MSifreTable();

            Ms.MS_Nick = txt_nick.Text;

            if (txt_pass.Text == txt_tpass.Text)
            {
                if (txt_pass.Text.Length < 13 && txt_pass.Text.Length > 7)
                {
                    Ms.MS_S = txt_pass.Text;
                }
                else
                {
                    MessageBox.Show("Şifreniz en az 8 hane en fazla 12 hane olabilir.");
                }
            }
            else
            {
                MessageBox.Show("Şifreniz eşleşmiyor tekrar giriniz.");

            }

            var musterid = db.MusteriTable.SingleOrDefault(aid => aid.M_TC == txt_tc.Text);
            Ms.M_ID = musterid.M_ID;

            db.MSifreTable.Add(Ms);
            db.SaveChanges();
            MessageBox.Show("Kayıt Oluşturuldu", "Kayıt Başarılı", MessageBoxButtons.OK);

            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = item as TextBox;
                    txt.Clear();
                }
                if (item is GroupBox)
                {
                    foreach (Control itemx in item.Controls)
                    {
                        if (itemx is RadioButton)
                        {
                            RadioButton rb = itemx as RadioButton;
                            rb.Checked = false;
                        }
                    }
                }

            }

        }

        private void cmb_il_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (txt_tc.Text != "")
            {
                
                MusteriTable Mt = new MusteriTable();
                MSifreTable Ms = new MSifreTable();

                var musterid = db.MusteriTable.Single(aid => aid.M_TC == txt_tc.Text);
                var mid = musterid.M_ID;
                MSifreTable sil = db.MSifreTable.Single(i => i.M_ID == mid);
                if (sil != null && musterid != null)
                {
                    db.MSifreTable.Remove(sil);
                    db.SaveChanges();
                    db.MusteriTable.Remove(musterid);
                    db.SaveChanges();
                }
                else
                    MessageBox.Show("Hata!\n Veri yok!");
            }
            else
                MessageBox.Show("Bilgileri Giriniz");

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            var musterid = db.MusteriTable.Single(aid => aid.M_TC == txt_tc.Text);
            var mid = musterid.M_ID;
            MSifreTable ud = db.MSifreTable.Single(i => i.M_ID == mid);
            musterid.M_TC = txt_tc.Text;
            musterid.M_AD = txt_ad.Text;
            musterid.M_Soyad = txt_soy.Text;
            musterid.M_Tel = txt_tel.Text;
            musterid.M_Dyil = txt_dyil.Text;
            if (rb_erk.Checked == true){musterid.M_Cins = "ERKEK";}
            else if (rb_kad.Checked == true){musterid.M_Cins = "KADIN";}
            else if (rb_erk.Checked == false && rb_kad.Checked == false) { MessageBox.Show("Cinsiyet Seçimi Yapınız.", "Cinsiyet seçimi!"); }

            if (rb_var.Checked == true){musterid.M_Ehliyet = "Var";}
            else if (rb_yok.Checked == true){musterid.M_Ehliyet = "Yok";}
            else if (rb_yok.Checked == false && rb_var.Checked == false){MessageBox.Show("Ehliyet Seçimi Yapınız.", "Ehliyet seçimi!");}
            musterid.M_Mail = txt_mail.Text;
            musterid.I_ID= Convert.ToInt32(cmb_il.SelectedValue.ToString());
        }
    }
}
