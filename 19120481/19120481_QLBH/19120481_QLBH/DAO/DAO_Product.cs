using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace _19120481_QLBH.DAO
{
    class DAO_Product
    {
        public DAO_Product()
        {
        }

        public DataTable getAllProduct()
        {
            return DBAccess.GetDataToTable("SELECT * FROM M_PRODUCT");
        }

        public DataTable searchByName(string name)
        {
            return DBAccess.GetDataToTable("SELECT * FROM M_PRODUCT WHERE NAME LIKE N'%" + name + "%'");
        }
    } 
}
