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

namespace BaiThucHanh4
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        DataHelper db;
        DataTable dtNhanVien;

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            dtNhanVien = Program.Db.FillDataTable("SELECT MaNV, TenNV, DiaChi, TenDN, MatKhau, QuyenHan FROM NhanVien");
            dgvNhanVien.DataSource = dtNhanVien;
            cboQuyen.Items.Add("Quản Trị");
            cboQuyen.Items.Add("Nhân Viên");
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
            try
            {
                object[] values =
                {
                    txtMa.Text,
                    txtTenNV.Text,
                    txtDiaChi.Text,
                    txtTenDN.Text,
                    txtMatKhau.Text,
                    cboQuyen.Text
                };

                Program.Db.InsertTable(dtNhanVien, values);
                Program.Db.UpdateTableToDatabase(dtNhanVien, "nhanvien");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                object[] values =
                {
                    txtMa.Text,
                    txtTenNV.Text,
                    txtDiaChi.Text,
                    txtTenDN.Text,
                    txtMatKhau.Text,
                    cboQuyen.Text
                };

                Program.Db.UpdateTable(dtNhanVien, values);
                Program.Db.UpdateTableToDatabase(dtNhanVien, "nhanvien");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa nhân viên này?", "Xác nhận",
                    MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            try
            {
                Program.Db.DeleteTable(dtNhanVien, txtMa.Text);
                Program.Db.UpdateTableToDatabase(dtNhanVien, "nhanvien");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string cot = "MaNV";
            string giaTri = txtMa.Text.Trim();
            if (giaTri == "")
            {
                MessageBox.Show("Vui lòng nhập nội dung tìm kiếm");
                return;
            }

            DataView dv = new DataView(dtNhanVien);

            dv.RowFilter = $"{cot} LIKE '%{giaTri}%'";

            dgvNhanVien.DataSource = dv;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataRowView r = (DataRowView)dgvNhanVien.Rows[e.RowIndex].DataBoundItem;

            txtMa.Text = r.Row["manhanvien"].ToString();
            txtTenNV.Text = r.Row["hoten"].ToString();
            txtDiaChi.Text = r.Row["dachi"].ToString();
            txtTenDN.Text = r.Row["tendangnhap"].ToString();
            txtMatKhau.Text = r.Row["matkhau"].ToString();
            cboQuyen.Text = r.Row["quyenhan"].ToString();
        }
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = dtNhanVien;
        }
    }
}
