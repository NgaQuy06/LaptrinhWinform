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
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtNhap.Text = "";
        }

        private void btnKetQua_Click(object sender, EventArgs e)
        {
            if (rdoChuThuong.Checked)
            {
                txtKetQua.Text = txtNhap.Text.ToLower();
            }
            else if (rdoChuHoa.Checked)
            {
                txtKetQua.Text = txtNhap.Text.ToUpper();
            }
            else
            {
                MessageBox.Show("Hay chon 1 kieu chuyen doi");
            }
        }

        private void Bai2_Load(object sender, EventArgs e)
        {

        }
    }
}
