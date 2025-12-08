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
    public partial class Bai5 : Form
    {
        public Bai5()
        {
            InitializeComponent();
        }

        private void Bbai4_Load(object sender, EventArgs e)
        {

        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            int a = dgv.Rows.Add();
            dgv.Rows[a].Cells["MaSV"].Value = txtMaSV.Text;
            dgv.Rows[a].Cells["HoTen"].Value = txtHoTen.Text;
            dgv.Rows[a].Cells["QueQuan"].Value = txtQueQuan.Text;
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtQueQuan.Clear();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (!dgv.SelectedRows[0].IsNewRow)
                {
                    int a = dgv.SelectedRows[0].Index;
                    txtMaSV.Text = dgv.Rows[a].Cells["MaSV"].Value.ToString();
                    txtHoTen.Text = dgv.Rows[a].Cells["HoTen"].Value.ToString();
                    txtQueQuan.Text = dgv.Rows[a].Cells["QueQuan"].Value.ToString();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                int a = dgv.SelectedRows[0].Index;
                dgv.Rows[a].Cells["MaSV"].Value = txtMaSV.Text;
                dgv.Rows[a].Cells["HoTen"].Value = txtHoTen.Text;
                dgv.Rows[a].Cells["QueQuan"].Value = txtQueQuan.Text;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSV.Text != "")
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;
                    if (row.Cells["MaSV"].Value.ToString() == txtMaSV.Text)
                    {
                        dgv.Rows.Remove(row);
                    }
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["MaSV"].Value.ToString() == txtMaSV.Text)
                {
                    row.Selected = true;
                }
            }
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
