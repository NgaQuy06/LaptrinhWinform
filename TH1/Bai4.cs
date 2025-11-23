using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiThucHanh
{
    public partial class Bai4 : Form
    {
        public Bai4()
        {
            InitializeComponent();
        }

        private void Bai4_Load(object sender, EventArgs e)
        {
            
        }

        private void rdoCong_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCong.Checked)
                txtKetQua.Text = (int.Parse(txtso1.Text) + int.Parse(txtso2.Text)).ToString();
        }

        private void rdoTru_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTru.Checked)
                txtKetQua.Text = (int.Parse(txtso1.Text) - int.Parse(txtso2.Text)).ToString();
        }

        private void rdoNhan_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNhan.Checked)
                txtKetQua.Text = (int.Parse(txtso1.Text) * int.Parse(txtso2.Text)).ToString();
        }

        private void rdoChia_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoChia.Checked)
                txtKetQua.Text = (int.Parse(txtso1.Text) / int.Parse(txtso2.Text)).ToString();
        }
    }
}
