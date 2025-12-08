using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BaiThucHanh2
{
    public partial class Bai6 : Form
    {
        public Bai6()
        {
            InitializeComponent();
        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void Bbai5_Load(object sender, EventArgs e)
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                tv.Nodes.Add(c.ToString());
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddName_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tv.Nodes.Count; i++)
            {
                if (txtLastName.Text.ToUpper().StartsWith(tv.Nodes[i].Text))
                {
                    tv.Nodes[i].Nodes.Add(txtLastName.Text + ", " + txtFirstName.Text);
                    break;
                }
            }
            txtFirstName.Clear();
            txtLastName.Clear();
            txtFirstName.Focus();
        }
    }
}
