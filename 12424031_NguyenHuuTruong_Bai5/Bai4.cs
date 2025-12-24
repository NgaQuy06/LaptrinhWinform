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
    public partial class Bai4 : Form
    {
        QLSV_BTH5_Bai4Entities db = new QLSV_BTH5_Bai4Entities();
        public Bai4()
        {
            InitializeComponent();
        }

        private void Bai4_Load(object sender, EventArgs e)
        {
            var student = db.Students.ToList();
            foreach (var stu in student)
            {
                string[] str = { stu.stuName, stu.stuYear?.ToString("dd/MM/yyyy"), stu.address };
                lstView.Items.Add(new ListViewItem(str));
            }
            txtTotal.Text = lstView.Items.Count.ToString();
            LoadCboClass();
        }

        private void LoadCboClass()
        {
            var classNo = db.Students.ToList();
            foreach (var cls in classNo)
            {
                cboClass.Items.Add(cls.classNo);
            }
        }

        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClass.SelectedIndex == -1) return;
            lstView.Items.Clear();
            var student = db.Students.ToList();
            foreach (var stu in student)
            {
                if (stu.classNo == cboClass.SelectedItem.ToString())
                {
                    string[] str = { stu.stuName, stu.stuYear?.ToString("dd/MM/yyyy"), stu.address };
                    lstView.Items.Add(new ListViewItem(str));
                }
            }
            var teacher = db.StudentClasses.Where(c => c.classNo == cboClass.SelectedItem.ToString());
            txtTeacher.Text = teacher.FirstOrDefault().homeroomTeacher;
            txtTotal.Text = lstView.Items.Count.ToString();
        }
    }
}
