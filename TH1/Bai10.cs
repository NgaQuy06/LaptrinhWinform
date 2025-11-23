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
    public partial class Bai10 : Form
    {
        public Bai10()
        {
            InitializeComponent();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtHovaTen.Text == "")
            {
                MessageBox.Show("Vui long nhap ho va ten");
                return;
            }
            lstA.Items.Add(txtHovaTen.Text);
            txtHovaTen.Text = "";
            txtHovaTen.Focus();
        }

        private void btnPhai1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstA.Items.Count; i++)
            {
                if (lstA.GetSelected(i))
                {
                    lstB.Items.Add(lstA.Items[i]);
                    lstA.Items.RemoveAt(i);
                }
            }
        }

        private void btnPhai2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstA.Items.Count; i++)
            {
                lstB.Items.Add(lstA.Items[i]);
                lstA.Items.RemoveAt(i);
            }
        }

        private void btnTrai1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstB.Items.Count; i++)
            {
                if (lstB.GetSelected(i))
                {
                    lstA.Items.Add(lstB.Items[i]);
                    lstB.Items.RemoveAt(i);
                }
            }
        }

        private void btnTrai2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstB.Items.Count; i++)
            {
                lstA.Items.Add(lstB.Items[i]);
                lstB.Items.RemoveAt(i);
            }
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bai3_1_Load(object sender, EventArgs e)
        {

        }
    }
}
