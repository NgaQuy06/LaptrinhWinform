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
    public partial class Bai8 : Form
    {
        public Bai8()
        {
            InitializeComponent();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtA.Text = "";
            txtB.Text = "";
            lblNghiem.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGiai_Click(object sender, EventArgs e)
        {
            if (txtA.Text == "0")
            {
                MessageBox.Show("Phuong trinh vo nghiem");
                return;
            }
            else if (txtA.Text == "" || txtB.Text == "")
            {
                MessageBox.Show("Vui long nhap day du he so");
            }
            else
            {
                lblNghiem.Text = (float.Parse(txtB.Text) / float.Parse(txtA.Text)).ToString();
            }
        }

        private void Bai8_Load(object sender, EventArgs e)
        {
            
        }

        private void txtA_TextChanged(object sender, EventArgs e)
        {
            if (txtA.Text == "" && txtB.Text == "") btnXoa.Enabled = false;
            else btnXoa.Enabled = true;
        }

        private void txtB_TextChanged(object sender, EventArgs e)
        {
            if (txtA.Text == "" && txtB.Text == "") btnXoa.Enabled = false;
            else btnXoa.Enabled = true;
        }
    }
}
