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
    public partial class Bai3 : Form
    {
        DataHelper dh;
        public Bai3()
        {
            InitializeComponent();
        }

        private void Bai3_Load(object sender, EventArgs e)
        {
            dh = new DataHelper(@"DESKTOP-R5QKMVL\SQLEXPRESS", "QLSV1");
            DataTable dt = dh.FillDataTable(@"select MaSV, LEFT(Hoten, CHARINDEX(' ', Hoten + ' ') - 1) AS HoSV, RIGHT(Hoten, CHARINDEX(' ', REVERSE(Hoten)) - 1) AS TenSV, Ngaysinh from Sinhvien");
            foreach(DataRow row in dt.Rows)
            {
                string[] str = { row["MaSV"].ToString(), row["HoSV"].ToString(), row["TenSV"].ToString(), row["Ngaysinh"].ToString() };
                lstView.Items.Add(new ListViewItem(str));
            }
            LoadCboMaKhoa();
        }
        private void LoadCboMaKhoa()
        {
            DataTable dt = dh.FillDataTable("select Makhoa from Khoa");
            foreach (DataRow row in dt.Rows)
            {
                cboMaKhoa.Items.Add(row["Makhoa"].ToString());
            }
        }

        private void cboMaKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaKhoa.SelectedIndex < 0) return;
            string makhoa = cboMaKhoa.SelectedItem.ToString();
            lstView.Items.Clear();
            DataTable dt = dh.FillDataTable($@"select sv.MaSV, LEFT(Hoten, CHARINDEX(' ', Hoten + ' ') - 1) AS HoSV, RIGHT(Hoten, CHARINDEX(' ', REVERSE(Hoten)) - 1) AS TenSV, Ngaysinh, Tenkhoa from Sinhvien sv join Lop l on sv.Malop = l.Malop join Khoa k on l.Makhoa = k.Makhoa where k.Makhoa = '{makhoa}'");
            foreach (DataRow row in dt.Rows)
            {
                string[] str = { row["MaSV"].ToString(), row["HoSV"].ToString(), row["TenSV"].ToString(), row["Ngaysinh"].ToString() };
                lstView.Items.Add(new ListViewItem(str));
                txtTenKhoa.Text = row["Tenkhoa"].ToString();
            }
        }
    }
}
