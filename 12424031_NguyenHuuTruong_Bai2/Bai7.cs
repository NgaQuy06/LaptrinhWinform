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
    public partial class Bai7 : Form
    {
        public Bai7()
        {
            InitializeComponent();
        }

        private void Bbai6_Load(object sender, EventArgs e)
        {
            tv.ExpandAll();
            txtNhap.Focus();
        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode sd = tv.SelectedNode;
            TreeNode goc = tv.Nodes[0];
            lstView.Items.Clear();
            if (goc == sd)
            {
                foreach (TreeNode node in goc.Nodes)
                {
                    foreach (TreeNode child in node.Nodes)
                    {
                        string[] str = { child.Text, node.Text };
                        lstView.Items.Add(new ListViewItem(str));
                    }
                }
            }
            foreach (TreeNode node in goc.Nodes)
            {
                if (node == sd)
                {
                    foreach (TreeNode child in node.Nodes)
                    {
                        string[] str = { child.Text, node.Text };
                        lstView.Items.Add(new ListViewItem(str));
                    }
                }
                foreach (TreeNode child in node.Nodes)
                {
                    if (child == sd)
                    {
                        string[] str = { child.Text, node.Text };
                        lstView.Items.Add(new ListViewItem(str));
                    }
                }
            }
        }

        private void lstView_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            TreeNode goc = tv.Nodes[0];
            foreach (TreeNode node in goc.Nodes)
            {
                foreach (TreeNode child in node.Nodes)
                {
                    if (txtNhap.Text == child.Text)
                    {
                        lstView.Items.Clear();
                        string[] str = { child.Text, node.Text };
                        lstView.Items.Add(new ListViewItem(str));
                        return;
                    }
                }
            }
        }
    }
}
