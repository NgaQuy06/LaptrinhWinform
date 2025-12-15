using BaiThucHanh4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiThucHanh4
{
    internal class DataHelper
    {
        private string st = "";
        private SqlConnection con;
        public DataHelper(string SV, string DB)
        {
            st = @"Server=" + SV + "; Database=" + DB + "; Integrated security=true" + "; TrustServerCertificate=True;";
            con = new SqlConnection(st);
        }
        public DataHelper(string svName, string dbName, string userName, string password)
        {
            st = @"Server=" + svName + "; Database=" + dbName + "; User Id=" + userName + "; Password=" + password + "; TrustServerCertificate=True" + ";";
            con = new SqlConnection(st);
        }
        public SqlConnection Connection
        {
            get { return con; }
        }
        public void Open()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
        }
        public void Close()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
        public static void ReadConfig(string tentep, out string quyen, out string svName, out string dbName, out string userName, out string password)
        {
            using (StreamReader sr = new StreamReader(tentep))
            {
                quyen = !sr.EndOfStream ? sr.ReadLine() : "";
                svName = !sr.EndOfStream ? sr.ReadLine() : "";
                dbName = !sr.EndOfStream ? sr.ReadLine() : "";
                userName = !sr.EndOfStream ? sr.ReadLine() : "";
                password = !sr.EndOfStream ? sr.ReadLine() : "";
            }
        }
        public static void WriteConfig(string fileName, string quyen, string svName, string dbName, string userName, string password)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine(quyen);
                sw.WriteLine(svName);
                sw.WriteLine(dbName);
                sw.WriteLine(userName);
                sw.WriteLine(password);
            }
        }
        private SqlDataAdapter _adapter;
        public DataTable FillDataTable(string sql)
        {
            _adapter = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            _adapter.Fill(dt);
            return dt;
        }

        public void InsertTable(DataTable dt, object[] values)
        {
            DataRow row = dt.NewRow();
            for (int i = 0; i < values.Length; i++)
                row[i] = values[i];
            dt.Rows.Add(row);
        }

        public void UpdateTable(DataTable dt, object[] values)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (row["MaNV"].ToString() == values[0].ToString())
                {
                    row["TenNV"] = values[1];
                    row["DiaChi"] = values[2];
                    row["TenDN"] = values[3];
                    row["MatKhau"] = values[4];
                    row["QuyenHan"] = values[5];
                    break;
                }
            }
        }

        public void DeleteTable(DataTable dt, string maNV)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (row["MaNV"].ToString() == maNV)
                {
                    row.Delete();
                    break;
                }
            }
        }

        public void UpdateTableToDatabase(DataTable dt, string tableName)
        {
            _adapter = new SqlDataAdapter("SELECT * FROM " + tableName, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(_adapter);
            _adapter.Update(dt);
        }
    }
}
