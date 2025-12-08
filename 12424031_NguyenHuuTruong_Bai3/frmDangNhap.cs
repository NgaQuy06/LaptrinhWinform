using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BaiThucHanh3
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtTen.Text.Trim();
            string pass = txtMatKhau.Text.Trim();

            if (user == "" || pass == "")
            {
                MessageBox.Show("Nhập tên đăng nhập và mật khẩu.");
                return;
            }

            try
            {
                Program.Db.Open();

                string sql = "SELECT * FROM NhanVien " +
                             "WHERE TenDN = @user AND MatKhau = @pass";

                SqlCommand cmd = new SqlCommand(sql, Program.Db.Connection);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pass", pass);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    dr.Close();
                    Program.Db.Close();

                    this.Hide();
                    new frmNhanVien().ShowDialog();
                    this.Close();
                }
                else
                {
                    dr.Close();
                    Program.Db.Close();
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu.");
                    txtTen.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
