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

namespace BaiThucHanh3
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            dgvNhanVien.Columns.Clear();
            dgvNhanVien.Columns.Add("MaNV", "Mã NV");
            dgvNhanVien.Columns.Add("TenNV", "Tên NV");
            dgvNhanVien.Columns.Add("DiaChi", "Địa chỉ");
            dgvNhanVien.Columns.Add("TenDN", "Tên đăng nhập");
            dgvNhanVien.Columns.Add("MatKhau", "Mật khẩu");
            dgvNhanVien.Columns.Add("QuyenHan", "Quyền hạn");

            // Nạp quyền hạn
            cboQuyen.Items.Clear();
            cboQuyen.Items.Add("Quản trị");
            cboQuyen.Items.Add("Nhân viên");
            cboQuyen.SelectedIndex = 0;

            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            LoadData();
        }
        private void LoadData()
        {
            dgvNhanVien.Rows.Clear();

            Program.Db.Open();
            string sql = "SELECT MaNV, TenNV, DiaChi, TenDN, MatKhau, QuyenHan FROM NhanVien";
            SqlCommand cmd = new SqlCommand(sql, Program.Db.Connection);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dgvNhanVien.Rows.Add(
                    dr["MaNV"].ToString(),
                    dr["TenNV"].ToString(),
                    dr["DiaChi"].ToString(),
                    dr["TenDN"].ToString(),
                    dr["MatKhau"].ToString(),
                    dr["QuyenHan"].ToString()
                );
            }

            dr.Close();
            Program.Db.Close();
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow r = dgvNhanVien.Rows[e.RowIndex];

            txtMa.Text = r.Cells["MaNV"].Value?.ToString();
            txtTenNV.Text = r.Cells["TenNV"].Value?.ToString();
            txtDiaChi.Text = r.Cells["DiaChi"].Value?.ToString();
            txtTenDN.Text = r.Cells["TenDN"].Value?.ToString();
            txtMatKhau.Text = r.Cells["MatKhau"].Value?.ToString();
            cboQuyen.Text = r.Cells["QuyenHan"].Value?.ToString();
        }
        private void btnMoi_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO NhanVien(MaNV, TenNV, DiaChi, TenDN, MatKhau, QuyenHan) " +
             "VALUES (@ma, @ten, @dc, @tendn, @mk, @qh)";

            try
            {
                Program.Db.Open();
                SqlCommand cmd = new SqlCommand(sql, Program.Db.Connection);
                cmd.Parameters.AddWithValue("@ma", txtMa.Text.Trim());
                cmd.Parameters.AddWithValue("@ten", txtTenNV.Text.Trim());
                cmd.Parameters.AddWithValue("@dc", txtDiaChi.Text.Trim());
                cmd.Parameters.AddWithValue("@tendn", txtTenDN.Text.Trim());
                cmd.Parameters.AddWithValue("@mk", txtMatKhau.Text.Trim());
                cmd.Parameters.AddWithValue("@qh", cboQuyen.Text.Trim());

                int n = cmd.ExecuteNonQuery();
                Program.Db.Close();

                if (n > 0)
                {
                    MessageBox.Show("Thêm thành công");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                Program.Db.Close();
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE NhanVien SET TenNV=@ten, DiaChi=@dc, TenDN=@tendn, " +
            "MatKhau=@mk, QuyenHan=@qh WHERE MaNV=@ma";

            try
            {
                Program.Db.Open();
                SqlCommand cmd = new SqlCommand(sql, Program.Db.Connection);
                cmd.Parameters.AddWithValue("@ma", txtMa.Text.Trim());
                cmd.Parameters.AddWithValue("@ten", txtTenNV.Text.Trim());
                cmd.Parameters.AddWithValue("@dc", txtDiaChi.Text.Trim());
                cmd.Parameters.AddWithValue("@tendn", txtTenDN.Text.Trim());
                cmd.Parameters.AddWithValue("@mk", txtMatKhau.Text.Trim());
                cmd.Parameters.AddWithValue("@qh", cboQuyen.Text.Trim());

                int n = cmd.ExecuteNonQuery();
                Program.Db.Close();

                if (n > 0)
                {
                    MessageBox.Show("Sửa thành công");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                Program.Db.Close();
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa nhân viên này?", "Xác nhận",
                   MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            string sql = "DELETE FROM NhanVien WHERE MaNV=@ma";

            try
            {
                Program.Db.Open();
                SqlCommand cmd = new SqlCommand(sql, Program.Db.Connection);
                cmd.Parameters.AddWithValue("@ma", txtMa.Text.Trim());

                int n = cmd.ExecuteNonQuery();
                Program.Db.Close();

                if (n > 0)
                {
                    MessageBox.Show("Xóa thành công");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                Program.Db.Close();
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtMa.Text.Trim() == "")
            {
                MessageBox.Show("Nhập mã nhân viên cần tìm");
                return;
            }
            foreach (DataGridViewRow r in dgvNhanVien.Rows)
            {
                if (r.Cells["MaNV"].Value?.ToString() == txtMa.Text.Trim())
                {
                    r.Selected = true;
                    dgvNhanVien.FirstDisplayedScrollingRowIndex = r.Index;
                    dgvNhanVien_CellContentClick(null, new DataGridViewCellEventArgs(0, r.Index));
                    return;
                }
            }
        }
    }
}
