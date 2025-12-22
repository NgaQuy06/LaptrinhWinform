using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiThucHanh5
{
    public partial class Bai2 : Form
    {
        DataHelper dh;
        private QLSV1Entities1 db;
        public Bai2()
        {
            InitializeComponent();
        }

        private void Bai2_Load(object sender, EventArgs e)
        {
            db = new QLSV1Entities1();
            dgv.Columns.Clear();
            var ds = db.Database.SqlQuery<QLSV1Entities1>("exec BTH5_Bai2_01").ToList();
            dgv.DataSource = ds;
            LoadCboMaMH();
        }

        private void LoadCboMaMH()
        {
            
        }

        private void cboMaMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
