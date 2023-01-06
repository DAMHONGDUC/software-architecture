using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using _19120481_QLBH.DTO;

namespace _19120481_QLBH.DAO
{
    public class DAO_Customer
    {
        public DataTable getCustomer(string sdt)
        {
            string sql = "select * from M_CUSTOMER where sdt = '" + sdt + "'";
            return DBAccess.GetDataToTable(sql);
        }

        public int insertCustomer(DTO_Customer dtoCustomer)
        {
            string sql = "INSERT INTO M_CUSTOMER VALUES (" +
                "N'" + dtoCustomer.fullname + "', " +
                "'" + dtoCustomer.sdt + "')";
            DBAccess.RunSQL(sql);

            return DBAccess.getIDInserted();
        }
    }
}
