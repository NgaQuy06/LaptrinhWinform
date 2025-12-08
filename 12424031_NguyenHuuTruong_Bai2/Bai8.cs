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
    public partial class Bai8 : Form
    {
        public Bai8()
        {
            InitializeComponent();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            //if (tv.SelectedNode.Name == "Node1" || tv.SelectedNode.Name == "Node2" || tv.SelectedNode.Name == "Node3")
            //{
            //    TreeNode n1 = new TreeNode(txtMaSV.Text + "-" + txtHoTen.Text);
            //    tv.SelectedNode.Nodes.Add(n1);
            //    n1.Nodes.Add(txtDiaChi.Text);
            //}
            TreeNode selectedNode = tv.SelectedNode;
            TreeNode rootNode = tv.Nodes[0];
            foreach (TreeNode child in rootNode.Nodes)
            {
                if (child == selectedNode)
                {
                    TreeNode n1 = new TreeNode(txtMaSV.Text + "-" + txtHoTen.Text);
                    tv.SelectedNode.Nodes.Add(n1);
                    n1.Nodes.Add(txtDiaChi.Text);
                    break;
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }
    }
}
