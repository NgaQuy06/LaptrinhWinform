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
    public partial class Bai6 : Form
    {
        public Bai6()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdo_CheckedChanged(object sender, EventArgs e)
        {
            if (sender != null)
            {
                RadioButton rdo = sender as RadioButton;
                if (rdo.Checked)
                {
                    FontFamily ff = new FontFamily(rdo.Text);
                    txtHienThi.Font = new Font(ff, txtHienThi.Font.Size);
                }
            }
        }

        private void Bai6_Load(object sender, EventArgs e)
        {
            rdo1.CheckedChanged += rdo_CheckedChanged;
            rdo2.CheckedChanged += rdo_CheckedChanged;
            rdo3.CheckedChanged += rdo_CheckedChanged;
            rdo4.CheckedChanged += rdo_CheckedChanged;
        }
    }
}
