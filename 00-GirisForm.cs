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
    public partial class GirisForm : Form
    {
        public GirisForm()
        {
            InitializeComponent();
        }
        Oto_galeriEntities1 db = new Oto_galeriEntities1();
        private void brn_giris_Click(object sender, EventArgs e)
        {
            if (txt_ka.Text != null && txt_pass.Text != null)
            {
                var mn = db.MSifreTable.SingleOrDefault(x => x.MS_Nick == txt_ka.Text);
                string nick = mn.MS_Nick;
                string pass = mn.MS_S;
                if (nick == txt_ka.Text && pass == txt_pass.Text)
                {
                    AnaForm fo1 = new AnaForm();
                    fo1.Show();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (txt_ka.Text == null || txt_pass.Text == null)
                MessageBox.Show("Kullanıcı adı veya Şifrenizi Giriniz", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KayitForm fo7 = new KayitForm();
            fo7.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PersonelGirisForm fo8 = new PersonelGirisForm();
            fo8.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (txt_pass.PasswordChar.ToString() == "*")
            {
                txt_pass.PasswordChar = char.Parse("\0");
                checkBox1.Text = "Gizle";
            }
            else
            {
                txt_pass.PasswordChar = char.Parse("*");
                checkBox1.Text = "Göster";
            }
        }
    }
}
