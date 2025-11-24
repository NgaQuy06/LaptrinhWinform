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
    public partial class Bai7 : Form
    {
        public Bai7()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            int a;
            bool kt = false;
            if (txtName.Text == "")
            {
                errorProvider1.SetError(txtName, "Ban chua nhap ten");
                kt = false;
            }
            else
            {
                errorProvider1.SetError(txtName, "");
                kt = true;
            }
            if (!int.TryParse(txtYear.Text, out a))
            {
                errorProvider1.SetError(txtYear, "Ban phai nhap so");
                kt = false;
            }
            else
            {
                errorProvider1.SetError(txtYear, "");
                kt = true;
            }
            if (kt)
            {
                int age = time.Year - int.Parse(txtYear.Text);
                MessageBox.Show($"Ten: {txtName.Text}, Tuoi: {age}");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtYear.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bai7_Load(object sender, EventArgs e)
        {

        }
    }
}
