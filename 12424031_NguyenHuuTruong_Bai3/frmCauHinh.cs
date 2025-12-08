using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiThucHanh3
{
    public partial class frmCauHinh : Form
    {
        public frmCauHinh()
        {
            InitializeComponent();
        }

        private void btnCauHinh_Click(object sender, EventArgs e)
        {
            string quyen = rdo1.Checked ? "WD" : "AC";
            string sv = txtTenMay.Text.Trim();
            string db = txtTenData.Text.Trim();
            string un = txtUserName.Text.Trim();
            string pw = txtPass.Text.Trim();
            try
            {
                DataHelper temp;
                if (quyen == "WD")
                    temp = new DataHelper(sv, db);
                else
                    temp = new DataHelper(sv, db, un, pw);

                temp.Open(); // thử kết nối
                temp.Close();

                // Ghi file
                DataHelper.WriteConfig("config.ini", quyen, sv, db, un, pw);

                MessageBox.Show("Kết nối thành công, đã lưu cấu hình.");

                // Gán cho Program.Db và mở Form đăng nhập
                Program.Db = temp;
                this.Hide();
                new frmDangNhap().ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại: " + ex.Message);
                txtTenMay.Focus();
            }
        }

        private void frmCauHinh_Load(object sender, EventArgs e)
        {
            string quyen, sv, db, un, pw;
            DataHelper.ReadConfig("config.ini",
                                  out quyen, out sv, out db, out un, out pw);

            if (quyen == "WD")
                rdo1.Checked = true;
            else
                rdo2.Checked = true;

            txtTenMay.Text = sv;
            txtTenData.Text = db;
            txtUserName.Text = un;
            txtPass.Text = pw;
        }
    }
}
