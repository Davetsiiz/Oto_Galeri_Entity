using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Oto_Galeri
{
    class Yuvarlak_Button:Button
    {
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GraphicsPath gp=new GraphicsPath();
            System.Drawing.Rectangle rec = new System.Drawing.Rectangle(System.Drawing.Point.Empty,this.Size);
            gp.AddEllipse(rec);
            this.Region = new System.Drawing.Region(gp);
        }
    }
}
