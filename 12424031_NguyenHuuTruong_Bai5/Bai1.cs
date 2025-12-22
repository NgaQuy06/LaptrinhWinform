using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiThucHanh5
{
    public partial class Bai1 : Form
    {
        private QLSachEntities db;
        private bool isAdding = false;
        private bool isEditing = false;
        public Bai1()
        {
            InitializeComponent();
        }

        private void frmSach_Load(object sender, EventArgs e)
        {
            db = new QLSachEntities();
            LoadCategories();
            LoadProducts();
            SetEditing(false);
        }

        private void SetEditing(bool isEditing)
        {
            txtMaSach.Enabled = isEditing;
            txtTieuDe.Enabled = isEditing;
            txtGia.Enabled = isEditing;
            txtSoLuong.Enabled = isEditing;

            btnLuu.Enabled = isEditing;

            btnThem.Enabled = !isEditing;
            btnSua.Enabled = !isEditing;
            btnXoa.Enabled = !isEditing;
        }

        private void ClearInputs()
        {
            txtMaSach.Clear();
            txtTieuDe.Clear();
            txtGia.Clear();
            txtSoLuong.Clear();
        }

        private void LoadCategories()
        {
            var categories = db.Categories
                .OrderBy(c => c.CategoryName)
                .Select(c => new { c.CategoryID, c.CategoryName })
                .ToList();

            cboLoaiSach.DataSource = categories;
            cboLoaiSach.DisplayMember = "CategoryName";
            cboLoaiSach.ValueMember = "CategoryId";
        }

        private void LoadProducts()
        {
            var products = db.Products
                .OrderBy(p => p.ProductCode)
                .Select(p => new
                {
                    p.ProductCode,
                    p.Descriptionn,
                    p.UnitPrice,
                    p.OnHandQuantity,
                    p.CategoryID
                })
                .ToList();

            dgv.DataSource = products;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            isEditing = false;

            SetEditing(true);
            ClearInputs();
            txtMaSach.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSach.Text))
            {
                MessageBox.Show("Chon sach can sua!");
                return;
            }

            isAdding = false;
            isEditing = true;
            SetEditing(true);
            txtMaSach.Enabled = false; // KHONG cho sua khoa
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            string code = txtMaSach.Text.Trim();
            if (string.IsNullOrEmpty(code))
            {
                MessageBox.Show("Hay chon 1 sach de xoa!");
                return;
            }

            var confirm = MessageBox.Show("Ban co chac muon xoa?", "Xac nhan",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.No) return;

            var p = db.Products.FirstOrDefault(x => x.ProductCode == code);
            if (p == null)
            {
                MessageBox.Show("Khong tim thay sach can xoa!");
                return;
            }

            db.Products.Remove(p);
            db.SaveChanges();

            LoadProducts();
            ClearInputs();
            MessageBox.Show("Xoa thanh cong!");
        }

        private void cboLoaiSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiSach.SelectedValue == null) return;

            int categoryId;
            if (!int.TryParse(cboLoaiSach.SelectedValue.ToString(), out categoryId)) return;

            var products = db.Products
                .Where(p => p.CategoryID == categoryId.ToString())
                .Select(p => new
                {
                    p.ProductCode,
                    p.Descriptionn,
                    p.UnitPrice,
                    p.OnHandQuantity,
                    p.CategoryID
                })
                .ToList();

            dgv.DataSource = products;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Validate chung
            if (!decimal.TryParse(txtGia.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Don gia khong hop le!");
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out int qty) || qty < 0)
            {
                MessageBox.Show("So luong khong hop le!");
                return;
            }

            // ===== THem moi =====
            if (isAdding)
            {
                string code = txtMaSach.Text.Trim();

                if (db.Products.Any(p => p.ProductCode == code))
                {
                    MessageBox.Show("Ma sach da ton tai!");
                    return;
                }

                var pNew = new Product
                {
                    ProductCode = code,
                    Descriptionn = txtTieuDe.Text.Trim(),
                    UnitPrice = int.Parse(price.ToString()),
                    OnHandQuantity = qty,
                    CategoryID = cboLoaiSach.SelectedValue.ToString()
                };
                db.Products.Add(pNew);
                db.SaveChanges();

                MessageBox.Show("Them sach thanh cong!");
            }
            else if (isEditing)
            {
                string code = txtMaSach.Text.Trim();
                var p = db.Products.FirstOrDefault(x => x.ProductCode == code);

                if (p == null)
                {
                    MessageBox.Show("Khong tim thay sach!");
                    return;
                }

                p.Descriptionn = txtTieuDe.Text.Trim();
                p.UnitPrice = int.Parse(price.ToString());
                p.OnHandQuantity = qty;
                p.CategoryID = cboLoaiSach.SelectedValue.ToString();

                db.SaveChanges();

                MessageBox.Show("Cap nhat thanh cong!");
            }

            // Reset trang thai
            isAdding = false;
            isEditing = false;

            LoadProducts();
            SetEditing(false);
        }

        private void lstView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgv.Rows[e.RowIndex];

            txtMaSach.Text = row.Cells["ProductCode"].Value?.ToString();
            txtTieuDe.Text = row.Cells["Descriptionn"].Value?.ToString();
            txtGia.Text = row.Cells["UnitPrice"].Value?.ToString();
            txtSoLuong.Text = row.Cells["OnHandQuantity"].Value?.ToString();

            if (row.Cells["CategoryID"].Value != null)
                cboLoaiSach.SelectedValue = (int)row.Cells["CategoryID"].Value;
        }
    }
}
