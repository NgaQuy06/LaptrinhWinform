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

namespace BaiThucHanh3
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
        
    }
}
