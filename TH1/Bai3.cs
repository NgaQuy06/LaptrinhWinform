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
    public partial class Bai3 : Form
    {
        public Bai3()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txt.Text != "")
            {
                cbo.Items.Add(txt.Text);
                txt.Text = "";
                txt.Focus();
            }
            else
                MessageBox.Show("Vui long nhap du lieu");
        }

        private void cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lst.Items.Add(cbo.SelectedItem.ToString());
        }

        private void btnTong_Click(object sender, EventArgs e)
        {
            int tong = 0;
            for (int i = 0; i < lst.Items.Count; i++)
            {
                int tmp = Convert.ToInt16(lst.Items[i]);
                for (int j = 1; j <= tmp; j++)
                {
                    if (tmp % j == 0)
                    {
                        tong += j;
                    }
                }
            }
            MessageBox.Show("Tong cac uoc so la: " + tong);
        }

        private void btnChan_Click(object sender, EventArgs e)
        {
            int tong = 0;
            for (int i = 0; i < lst.Items.Count; i++)
            {
                int tmp = Convert.ToInt16(lst.Items[i]);
                for (int j = 1; j <= tmp; j++)
                {
                    if (tmp % j == 0)
                    {
                        if (j % 2 == 0)
                        {
                            tong++;
                        }
                    }
                }
            }
            MessageBox.Show("So luong cac uoc so chan la: " + tong);
        }

        private void btnNguyen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ban can nap tien de su dung tinh nang nay!", "Thong bao");
        }

        private void Bai3_Load(object sender, EventArgs e)
        {

        }
    }
}
