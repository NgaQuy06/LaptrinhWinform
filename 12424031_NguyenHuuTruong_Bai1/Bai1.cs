using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BaiThucHanh
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Ten đăng nhập: {txtTenDangNhap.Text}\nMật khẩu: + {txtMatKhau.Text}", "Thông báo");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
            txtTenDangNhap.SelectionStart = 2;
            txtTenDangNhap.Focus();
        }

        private void btnDung_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bai1_Load(object sender, EventArgs e)
        {

        }
    }
}
