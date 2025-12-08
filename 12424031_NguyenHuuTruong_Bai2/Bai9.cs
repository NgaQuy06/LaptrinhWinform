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
    public partial class Bai9 : Form
    {
        public Bai9()
        {
            InitializeComponent();
        }

        private void cboKhuVuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhuVuc.SelectedIndex == 0) lblDinhMuc.Text = "50";
            else if (cboKhuVuc.SelectedIndex == 1) lblDinhMuc.Text = "100";
            else if (cboKhuVuc.SelectedIndex == 2) lblDinhMuc.Text = "150";
            else lblDinhMuc.Text = "";
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Ban chua nhap ho ten");
                txtHoTen.Focus();
                return;
            }
            if (cboKhuVuc.SelectedIndex == -1)
            {
                MessageBox.Show("Ban chua chon khu vuc");
                cboKhuVuc.Focus();
                return;
            }
            int a;
            if (!int.TryParse(txtSoCu.Text, out a) || !int.TryParse(txtSoMoi.Text, out a))
            {
                MessageBox.Show("Phai la so");
                return;
            }
            int tieuthu = int.Parse(txtSoMoi.Text) - int.Parse(txtSoCu.Text);
            if (tieuthu > 50 && tieuthu < 150)
            {
                lblTieuThu.Text = tieuthu.ToString();
                lblThanhTien.Text = (tieuthu * 500).ToString();
            }
            else
            {
                lblTieuThu.Text = tieuthu.ToString();
                lblThanhTien.Text = (tieuthu * 1000).ToString();
            }
            string[] str = { txtHoTen.Text, cboKhuVuc.Text, lblDinhMuc.Text, lblTieuThu.Text, lblThanhTien.Text };
            lstView.Items.Add(new ListViewItem(str));
            int tong = 0;
            foreach (ListViewItem item in lstView.Items)
            {
                tong += int.Parse(item.SubItems[4].Text);
            }
            lblTongTien.Text = tong.ToString();
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
            lblDinhMuc.Text = "";
            txtSoCu.Text = "";
            txtSoMoi.Text = "";
            lblTieuThu.Text = "";
            lblThanhTien.Text = "";
            txtHoTen.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lstView.SelectedItems.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Ban co chac muon xoa khong", "Hello", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    lstView.Items.Remove(lstView.SelectedItems[0]);
                    int tong = 0;
                    foreach (ListViewItem item in lstView.Items)
                    {
                        tong += int.Parse(item.SubItems[4].Text);
                    }
                    lblTongTien.Text = tong.ToString();
                }
            }
        }
    }
}
