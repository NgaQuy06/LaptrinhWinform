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
    public partial class Bai3 : Form
    {
        public Bai3()
        {
            InitializeComponent();
        }

        private void Bai3_Load(object sender, EventArgs e)
        {

        }

        private void btnAddName_Click(object sender, EventArgs e)
        {
            string[] str = { txtLastName.Text, txtFirstName.Text, txtPhone.Text };
            lvw.Items.Add(new ListViewItem(str));
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            txtLastName.Focus();
        }
    }
}
