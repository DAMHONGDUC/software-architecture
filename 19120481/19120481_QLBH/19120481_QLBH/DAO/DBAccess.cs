using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;

namespace _19120481_QLBH.DAO
{
    class DBAccess
    {
        // tên server của SQL server, chạy câu lệnh "SELECT @@SERVERNAME" trong sql server để lấy
        private static string server_name = @"DESKTOP-2V6T4K0\SQLEXPRESS";

        //Khai báo đối tượng kết nối  
        public static SqlConnection Con;
        public static bool Connect()
        {
            Con = new SqlConnection();
            Con.ConnectionString = "Data Source=" + DBAccess.server_name + ";Initial Catalog=QLBH;Integrated Security=True";
            //Mở kết nối

            try
            {
                Con.Open();

                //Kiểm tra kết nối
                if (Con.State == ConnectionState.Open)
                {
                    return true;
                }             
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return false;
        }

        public static void Disconnect()
        {
            if (Con.State == ConnectionState.Open)
            {
                //Đóng kết nối
                Con.Close();

                //Giải phóng tài nguyên
                Con.Dispose();
                Con = null;

                //Kiểm tra kết nối
                //MessageBox.Show("Đóng Kết nối DB thành công");
            }
        }

        // Lấy dữ liệu đổ vào bảng
        public static DataTable GetDataToTable(string sql) 
        {
            SqlDataAdapter dap = new SqlDataAdapter();
            dap.SelectCommand = new SqlCommand();

            //Kết nối cơ sở dữ liệu
            dap.SelectCommand.Connection = DBAccess.Con;
            dap.SelectCommand.CommandText = sql;

            DataTable table = new DataTable();
            dap.Fill(table);
            return table;
        }

        // kiểm tra xem có trùng khóa hay không
        public static bool CheckKey(string sql) 
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, Con);
            DataTable table = new DataTable();
            dap.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }

        // chạy câu lệnh sql
        public static void RunSQL(string sql) 
        {
            SqlCommand cmd = new SqlCommand();

            //Gán kết nối
            cmd.Connection = Con;

            //Gán lệnh SQL
            cmd.CommandText = sql;

            //Thực hiện câu lệnh SQL
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //Giải phóng bộ nhớ
            cmd.Dispose();
            cmd = null;
        }

        public static int getIDInserted()
        {
            return Int32.Parse(DBAccess.GetFieldValues("SELECT SCOPE_IDENTITY()"));
        }

        // đổ dữ liệu vào comboBox
        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten) 
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, Con);
            DataTable table = new DataTable();
            dap.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma;
            cbo.DisplayMember = ten;
        }

        // lấy dữ liệu từ câu lệnh sql
        public static string GetFieldValues(string sql) 
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, Con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            return ma;
        }
    }
}
