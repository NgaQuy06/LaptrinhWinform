using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiThucHanh
{
    public partial class Bai12 : Form
    {
        public Bai12()
        {
            InitializeComponent();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtHienThi.Text = "";
        }

        private void Bai5_1_Load(object sender, EventArgs e)
        {
            btn0.Click += btn_Number_Click;
            btn1.Click += btn_Number_Click;
            btn2.Click += btn_Number_Click;
            btn3.Click += btn_Number_Click;
            btn4.Click += btn_Number_Click;
            btn5.Click += btn_Number_Click;
            btn6.Click += btn_Number_Click;
            btn7.Click += btn_Number_Click;
            btn8.Click += btn_Number_Click;
            btn9.Click += btn_Number_Click;
            btnCong.Click += btn_Operator_Click;
            btnTru.Click += btn_Operator_Click;
            btnNhan.Click += btn_Operator_Click;
            btnChia.Click += btn_Operator_Click;
        }
        private void btn_Number_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            txtHienThi.Text += btn.Text;
        }
        private void btn_Operator_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            txtHienThi.Text += btn.Text;
        }

        private void btnBang_Click(object sender, EventArgs e)
        {
            List<string> tokens = new List<string>();
            string so = "";
            foreach (char c in txtHienThi.Text)
            {
                if (char.IsDigit(c))
                    so += c;
                else if ("+-*/".Contains(c))
                {
                    if (so != "")
                    {
                        tokens.Add(so);
                        so = "";
                    }
                    tokens.Add(c.ToString());
                }
            }
            if (so != "") tokens.Add(so);
            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i] == "*" || tokens[i] == "/")
                {
                    double a = double.Parse(tokens[i - 1]);
                    double b = double.Parse(tokens[i + 1]);
                    double result = tokens[i] == "*" ? a * b : a / b;

                    tokens[i - 1] = result.ToString();
                    tokens.RemoveAt(i);
                    tokens.RemoveAt(i);
                    i--;
                }
            }
            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i] == "+" || tokens[i] == "-")
                {
                    double a = double.Parse(tokens[i - 1]);
                    double b = double.Parse(tokens[i + 1]);
                    double result = tokens[i] == "+" ? a + b : a - b;

                    tokens[i - 1] = result.ToString();
                    tokens.RemoveAt(i);
                    tokens.RemoveAt(i);
                    i--;
                }
            }
            txtHienThi.Text = tokens[0];
        }
    }
}
