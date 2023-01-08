using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using _19120481_QLBH.DTO;

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

        public int insertProduct(DTO_Product product)
        {
            string sql = "INSERT INTO M_PRODUCT VALUES (" +
                "N'" + product.name +"', " +
                "N'" + product.description + "', " +
                "'" + product.image + "', " +
                "" + product.quantity + ", " +
                "" + product.price + ")";

            DBAccess.RunSQL(sql);

            return DBAccess.getIDInserted();
        }

        public void updateProduct(DTO_Product product)
        {
            string sql = "update M_PRODUCT set " +
               "NAME = '" + product.name + "', " +
               "DESCRIPTION = '" + product.description + "', " +
               "IMAGE = N'" + product.image + "', " +
               "QUANTITY = '" + product.quantity + "', " +
               "PRICE = '" + product.price + "' " +
               "where ID = " + product.id + "";

            DBAccess.RunSQL(sql);
        }

        public void deleteProduct(int id)
        {
            DBAccess.RunSQL("delete from M_PRODUCT where ID = "+ id +"");
        }
    } 
}
