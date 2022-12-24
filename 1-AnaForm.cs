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
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void yuvarlak_Button1_Click(object sender, EventArgs e)
        {
            
            MusteriForm fo1 = new MusteriForm();
            fo1.Show();
            

        }

        private void yuvarlak_Button2_Click(object sender, EventArgs e)
        {
            ArabaForm fo2 = new ArabaForm();
            fo2.Show();
            
        }

        private void yuvarlak_Button3_Click(object sender, EventArgs e)
        {
            SubeForm fo3 = new SubeForm();
            fo3.Show();
            
        }

        private void yuvarlak_Button4_Click(object sender, EventArgs e)
        {
            PersonelForm fo4=new PersonelForm();
            fo4.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RaporForm fo5 = new RaporForm();
            fo5.Show();
            

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            islemForm fo6 = new islemForm();
            fo6.Show();
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_ques_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorunun mu var?", "Sorn??", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
    }
}
