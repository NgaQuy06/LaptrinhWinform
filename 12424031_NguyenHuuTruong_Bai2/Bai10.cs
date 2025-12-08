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
    public partial class Bai10 : Form
    {
        public Bai10()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{txtName.Text}\n{mtxtDateofBirth.Text}\n{txtAdrress.Text}\n{lstBox.SelectedItem.ToString()}\n{cboCountry.ToString()}\n{txtQualification.Text}\n{mtxtPhone.Text}\n{txtMail.Text}");
            
        }

        private void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCountry.SelectedIndex == 0)
            {
                lstBox.Items.Clear();
                lstBox.Items.Add("Ho Chi Minh");
                lstBox.Items.Add("Nha Trang");
                lstBox.Items.Add("Ha Noi");
            }
            if (cboCountry.SelectedIndex == 1)
            {
                lstBox.Items.Clear();
                lstBox.Items.Add("Pattaya");
                lstBox.Items.Add("ChiengMai");
                lstBox.Items.Add("Bangkok");
            }
        }
    }
}
