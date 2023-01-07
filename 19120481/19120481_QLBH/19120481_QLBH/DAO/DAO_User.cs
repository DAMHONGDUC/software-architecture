using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19120481_QLBH.DTO;
using System.Data;

namespace _19120481_QLBH.DAO
{
    public class DAO_User
    {
        public DAO_User()
        {
        }

        public bool ConnectDB()
        {
            return DBAccess.Connect();          
        }

        public DTO_User Login(string username, string password)
        {
            string sql = "select * from M_USER where USERNAME = '" + username + "' and PASSWORD = '" + password + "'";

            DataTable tbl = DBAccess.GetDataToTable(sql);

            if (tbl.Rows.Count > 0)
            {
                int id = tbl.Rows[0].Field<int>(0);
                string fullname = tbl.Rows[0].Field<string>(3);
                DateTime dob = tbl.Rows[0].Field<DateTime>(4);
                int role = tbl.Rows[0].Field<int>(5);

                return new DTO_User(id, fullname, dob, role);
            }

            return null;
        }

        public DataTable getAllStaff()
        {
            return DBAccess.GetDataToTable("select * from M_USER");
        }

        public int insertUser(DTO_User user)
        {
            string sql = "INSERT INTO M_USER VALUES (" +
                "'"+ user.username +"', " +
                "'" + user.password + "', " +
                "N'" + user.fullname + "', " +
                "'" + user.dob + "', " +
                "" + user.role + ")";

            DBAccess.RunSQL(sql);

            return DBAccess.getIDInserted();
        }

        public void updateUser(DTO_User user)
        {
            string sql = "update M_USER set " +
                "USERNAME = '" + user.username + "', " +
                "PASSWORD = '" + user.password + "', " +
                "FULLNAME = N'" + user.fullname + "', " +
                "DOB = '" + user.dob + "', " +
                "ROLE = '" + user.role + "' " +
                "where ID = " + user.id + "";

            DBAccess.RunSQL(sql);
        }
    }
}
