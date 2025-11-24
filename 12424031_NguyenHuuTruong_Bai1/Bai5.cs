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
    public partial class Bai5 : Form
    {
        public Bai5()
        {
            InitializeComponent();
        }

        private void rdoRed_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRed.Checked)
            {
                txtHienThi.Text = txtNhap.Text;
                txtHienThi.ForeColor = Color.Red;
            }
        }

        private void rdoGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoGreen.Checked)
            {
                txtHienThi.Text = txtNhap.Text;
                txtHienThi.ForeColor = Color.Green;
            }
        }

        private void rdoBlue_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBlue.Checked)
            {
                txtHienThi.Text = txtNhap.Text;
                txtHienThi.ForeColor = Color.Blue;
            }
        }

        private void rdoBlack_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBlack.Checked)
            {
                txtHienThi.Text = txtNhap.Text;
                txtHienThi.ForeColor = Color.Black;
            }
        }

        private void chkBold_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBold.Checked)
            {
                txtHienThi.Text = txtNhap.Text;
                txtHienThi.Font = new Font(txtHienThi.Font, txtHienThi.Font.Style | FontStyle.Bold);
            }
            else
            {
                txtHienThi.Text = txtNhap.Text;
                txtHienThi.Font = new Font(txtHienThi.Font, txtHienThi.Font.Style & ~FontStyle.Bold);
            }
        }

        private void chkItalic_CheckedChanged(object sender, EventArgs e)
        {
            if (chkItalic.Checked)
            {
                txtHienThi.Text = txtNhap.Text;
                txtHienThi.Font = new Font(txtHienThi.Font, txtHienThi.Font.Style | FontStyle.Italic);
            }
            else
            {
                txtHienThi.Text = txtNhap.Text;
                txtHienThi.Font = new Font(txtHienThi.Font, txtHienThi.Font.Style & ~FontStyle.Italic);
            }
        }

        private void chkUnder_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnder.Checked)
            {
                txtHienThi.Text = txtNhap.Text;
                txtHienThi.Font = new Font(txtHienThi.Font, txtHienThi.Font.Style | FontStyle.Underline);
            }
            else
            {
                txtHienThi.Text = txtNhap.Text;
                txtHienThi.Font = new Font(txtHienThi.Font, txtHienThi.Font.Style & ~FontStyle.Underline);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bai5_Load(object sender, EventArgs e)
        {

        }
    }
}
