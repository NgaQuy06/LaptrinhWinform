using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiThucHanh5
{
    public partial class Bai2 : Form
    {
        private QLSV1Entities1 db;
        public Bai2()
        {
            InitializeComponent();
        }

        private void Bai2_Load(object sender, EventArgs e)
        {
            db = new QLSV1Entities1();
            dgv.Rows.Clear();
            var sv = from s in db.Sinhviens
                     join bd in db.Bangdiems on s.MaSV equals bd.Masv
                     select new { s.MaSV, s.Hoten, s.Ngaysinh, bd.DiemL1 };
            foreach (var s in sv)
            {
                string hosv = s.Hoten.Split(' ')[0];
                string tenSV = s.Hoten.Split(' ')[1];
                if (s.Hoten.Split(' ').Length > 2)
                {
                    tenSV = s.Hoten.Split(' ')[2];
                }
                dgv.Rows.Add(s.MaSV, hosv, tenSV, s.Ngaysinh, s.DiemL1);
            }
            LoadCboMaMH();
        }

        private void LoadCboMaMH()
        {
            var mamh = db.Monhocs.Select(m => m.MaMH);
            foreach (var m in mamh)
            {
                cboMaMH.Items.Add(m);
            }
        }

        private void cboMaMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaMH.SelectedIndex == -1) return;
            dgv.Rows.Clear();
            var sinhvien = from sv in db.Sinhviens
                           join bd in db.Bangdiems on sv.MaSV equals bd.Masv
                           join mh in db.Monhocs on bd.MaMh equals mh.MaMH
                           where mh.MaMH == cboMaMH.SelectedItem.ToString()
                           select new { sv.MaSV, sv.Hoten, sv.Ngaysinh, bd.DiemL1, mh.TenMH, mh.sotc };
            foreach (var s in sinhvien)
            {
                string hosv = s.Hoten.Split(' ')[0];
                string tenSV = s.Hoten.Split(' ')[1] + " " + s.Hoten.Split(' ')[2];
                dgv.Rows.Add(s.MaSV, hosv, tenSV, s.Ngaysinh, s.DiemL1);
            }
            txtTenMH.Text = sinhvien.FirstOrDefault().TenMH;
            txtSoTiet.Text = (int.Parse(sinhvien.FirstOrDefault().sotc.ToString()) * 15).ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
