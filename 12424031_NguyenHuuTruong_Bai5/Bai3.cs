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
        QLSV1Entities1 db = new QLSV1Entities1();
        public Bai3()
        {
            InitializeComponent();
        }

        private void Bai3_Load(object sender, EventArgs e)
        {
            var sv = db.Sinhviens.ToList();
            foreach (var s in sv)
            {
                string hosv = s.Hoten.Split(' ')[0];
                string tensv = s.Hoten.Split(' ')[1] + " " + s.Hoten.Split(' ')[2];
                string[] str = { s.MaSV, hosv, tensv, s.Ngaysinh.ToString() };
                lstView.Items.Add(new ListViewItem(str));
            }
            lblTongSV.Text = lstView.Items.Count.ToString();
            LoadCboMaKhoa();
        }
        private void LoadCboMaKhoa()
        {
            db.Khoas.ToList();
            foreach (var k in db.Khoas)
            {
                cboMaKhoa.Items.Add(k.Makhoa);
            }
        }

        private void cboMaKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaKhoa.SelectedIndex < 0) return;
            lstView.Items.Clear();
            string makhoa = cboMaKhoa.SelectedItem.ToString();
            var sinhvien = db.Sinhviens.ToList();
            foreach (var ss in sinhvien)
            {
                var lop = db.lops.Where(l => l.Makhoa == makhoa);
                var tenkhoa = db.Khoas.Where(mk => mk.Makhoa == makhoa).Select(k => k.Tenkhoa);
                txtTenKhoa.Text = tenkhoa.FirstOrDefault();
                foreach (var l in lop)
                {
                    if (ss.Malop == l.Malop)
                    {
                        string hosv = ss.Hoten.Split(' ')[0];
                        string tensv = ss.Hoten.Split(' ')[1] + " " + ss.Hoten.Split(' ')[2];
                        string[] str = { ss.MaSV, hosv, tensv, ss.Ngaysinh.ToString() };
                        lstView.Items.Add(new ListViewItem(str));
                    }
                }
                lblTongSV.Text = lstView.Items.Count.ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
