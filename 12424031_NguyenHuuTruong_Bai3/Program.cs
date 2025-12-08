using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BaiThucHanh3
{
    internal static class Program
    {
        public static DataHelper Db;
        
        [STAThread]
        static void Main()
        {
            if (TestConnection())
            {
                Application.Run(new frmDangNhap());
            }
            else
            {
                Application.Run(new frmCauHinh());
            }
        }
        private static bool TestConnection()
        {
            try
            {
                string quyen, sv, db, un, pw;
                string configFile = "config.ini";
                if (!File.Exists(configFile))
                {
                    File.Create(configFile).Close();
                }
                DataHelper.ReadConfig(configFile, out quyen, out sv, out db, out un, out pw);
                if (string.IsNullOrWhiteSpace(sv) || string.IsNullOrWhiteSpace(db))
                    return false;
                if (quyen == "WD")
                    Db = new DataHelper(sv, db);
                else
                    Db = new DataHelper(sv, db, un, pw);
                Db.Open();
                Db.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
