using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiThucHanh2
{
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
        }

        private void rdo1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo1.Checked)
            {
                pictureBox1.BackgroundImage = Image.FromFile(@"C:\Users\Admin\Pictures\Camera Roll\VietNam.png");
            }
        }

        private void rdo2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo2.Checked)
            {
                pictureBox1.BackgroundImage = Image.FromFile(@"C:\Users\Admin\Pictures\Camera Roll\USA.png");
            }
        }

        private void rdo3_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo3.Checked)
            {
                pictureBox1.BackgroundImage = Image.FromFile(@"C:\Users\Admin\Pictures\Camera Roll\Italian.png");
            }
        }

        private void rdo4_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo4.Checked)
            {
                pictureBox1.BackgroundImage = Image.FromFile(@"C:\Users\Admin\Pictures\Camera Roll\Philippine.png");
            }
        }
    }
}
