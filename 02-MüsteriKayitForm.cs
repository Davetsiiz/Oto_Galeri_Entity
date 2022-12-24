using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Oto_Galeri
{
    public partial class KayitForm : Form
    {
        public KayitForm()
        {
            InitializeComponent();
        }

        Oto_galeriEntities1 db=new Oto_galeriEntities1();
        private void KayitForm_Load(object sender, EventArgs e)
        {
            var iller = db.IlTable.ToList();
            cmb_il.DataSource = iller;
            cmb_il.DisplayMember = "I_AD";
            cmb_il.ValueMember = "I_ID";
        }
        private void btn_home_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void yuvarlak_Button1_Click(object sender, EventArgs e)
        {
            MSifreTable Ms=new MSifreTable();
            MusteriTable Mt=new MusteriTable();

            Mt.M_TC = txt_tc.Text;
            Mt.M_AD = txt_ad.Text;
            Mt.M_Soyad = txt_soy.Text;
            Mt.M_Tel=txt_tel.Text;
            Mt.M_Dyil =txt_dyil.Text;
            Mt.M_Mail = txt_mail.Text;
            Mt.I_ID = Convert.ToInt32(cmb_il.SelectedValue.ToString());
            string cins;
            if (rb_erk.Checked == true) 
            {
                cins = "ERKEK";
                Mt.M_Cins = cins;
            }
            else if (rb_kad.Checked==true) 
            { 
                cins = "KADIN";
                Mt.M_Cins = cins;
            }
            else if (rb_erk.Checked == false&& rb_kad.Checked == false) { MessageBox.Show("Cinsiyet Seçimi Yapınız.", "Cinsiyet seçimi!"); }

            string ehl;
            
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
            Ms.MS_Nick = txt_nick.Text;
            
            if (txt_pass.Text == txt_tpass.Text)
            {
                if(txt_pass.Text.Length<13&& txt_pass.Text.Length > 7)
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

            db.MusteriTable.Add(Mt);
            db.SaveChanges();
            var musterid = db.MusteriTable.SingleOrDefault(aid => aid.M_TC == txt_tc.Text);
            Ms.M_ID = musterid.M_ID;

            db.MSifreTable.Add(Ms);
            db.SaveChanges();
            MessageBox.Show("Kayıt Oluşturuldu", "Kayıt Başarılı", MessageBoxButtons.OK);
            this.Close();

        }

       
    }
}
