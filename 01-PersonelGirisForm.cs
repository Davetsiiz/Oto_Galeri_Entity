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
    public partial class PersonelGirisForm : Form
    {
        public PersonelGirisForm()
        {
            InitializeComponent();
        }
        Oto_galeriEntities1 db = new Oto_galeriEntities1();
        private void btn_home_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void PersonelGirisForm_Load(object sender, EventArgs e)
        {

        }

        private void brn_giris_Click(object sender, EventArgs e)
        {
            var mn = db.PSifreTable.SingleOrDefault(x => x.PS_Nick == txt_ka.Text);
            string nick = mn.PS_Nick;
            string pass = mn.PS_S;
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
