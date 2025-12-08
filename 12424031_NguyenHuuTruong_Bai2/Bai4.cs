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
    public partial class Bai4 : Form
    {
        public Bai4()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvw.SelectedItems.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Ban co chac muon xoa khong", "Xac nhan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    lvw.Items.Remove(lvw.SelectedItems[0]);
                }
            }
            else MessageBox.Show("Vui long chon sinh vien de xoa", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string[] str = { txtMaSV.Text, txtHoTen.Text, txtDiaChi.Text, dtpNgaySinh.Value.ToString("dd/MM/yyyy"), cboLop.SelectedItem.ToString() };
            lvw.Items.Add(new ListViewItem(str));
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
        }

        private void Bbai3_Load(object sender, EventArgs e)
        {

        }

        private void lvw_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvw.SelectedItems.Count > 0)
            {
                ListViewItem item = lvw.SelectedItems[0];
                txtMaSV.Text = item.SubItems[0].Text;
                txtHoTen.Text = item.SubItems[1].Text;
                txtDiaChi.Text = item.SubItems[2].Text;
                dtpNgaySinh.Value = DateTime.ParseExact(item.SubItems[3].Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                cboLop.SelectedItem = item.SubItems[4].Text;
            }
        }
    }
}
