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
    public partial class Bai1 : Form
    {
        int i = 20;
        public Bai1()
        {
            InitializeComponent();
        }

        private void Bai1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i > 0)
            {
                i--;
                label1.Text = i.ToString();
            }
            else
            {
                timer1.Stop();
                label1.Text = "Het gio";
            }
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void btnDung_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
