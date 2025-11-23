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
    public partial class Bai2_1_ : Form
    {
        public Bai2_1_()
        {
            InitializeComponent();
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            int a;
            if (!int.TryParse(txt.Text, out a))
            {
                MessageBox.Show("Vui long nhap so nguyen");
                txt.Text = "";
                txt.Focus();
                return;
            }
            lstHienThi.Items.Add(txt.Text);
            txt.Text = "";
            txt.Focus();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            int tong = 0;
            for (int i = 0; i < lstHienThi.Items.Count; i++)
            {
                tong += int.Parse(lstHienThi.Items[i].ToString());
            }
            MessageBox.Show("Tong cac so la: " + tong);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            lstHienThi.Items.RemoveAt(0);
            lstHienThi.Items.RemoveAt(lstHienThi.Items.Count - 1);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            lstHienThi.Items.Remove(lstHienThi.SelectedItem);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstHienThi.Items.Count; i++)
            {
                lstHienThi.Items[i] = int.Parse(lstHienThi.Items[i].ToString()) + 2;
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstHienThi.Items.Count; i++)
            {
                lstHienThi.Items[i] = int.Parse(lstHienThi.Items[i].ToString()) * int.Parse(lstHienThi.Items[i].ToString());
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstHienThi.Items.Count; i++)
            {
                if (int.Parse(lstHienThi.Items[i].ToString()) % 2 == 0)
                    lstHienThi.SetSelected(i, true);
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstHienThi.Items.Count; i++)
            {
                if (int.Parse(lstHienThi.Items[i].ToString()) % 2 == 1)
                    lstHienThi.SetSelected(i, true);
            }
        }

        private void Bai2_1__Load(object sender, EventArgs e)
        {

        }
    }
}
