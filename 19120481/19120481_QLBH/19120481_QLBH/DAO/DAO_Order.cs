using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19120481_QLBH.DTO;
using System.Data;

namespace _19120481_QLBH.DAO
{
    public class DAO_Order
    {
        public int insertOrder(DTO_Order dtoOrder)
        {
            string sql = "INSERT INTO M_ORDER " +
                "VALUES(" +
                ""+ dtoOrder.ID_CUSTOMER + ", " +
                "" + dtoOrder.ID_STAFF + ", " +
                "N'" + dtoOrder.DELIVERY_ADDRESS + "', " +
                "'" + dtoOrder.DELIVERY_DATE + "', " +
                "N'" + dtoOrder.RECIPIENT_NAME + "', " +
                "'" + dtoOrder.RECIPIENT_PHONE + "', " +
                "'" + dtoOrder.DATE_CREATED + "', " +
                "" + dtoOrder.ORDER_STATUS + ", " +
                "" + dtoOrder.PAYMENT_TYPE + ", " +
                "" + dtoOrder.DELIVERY_COST + ", " +
                "" + dtoOrder.TOTAL_MONEY + ")";

            DBAccess.RunSQL(sql);

            return DBAccess.getIDInserted();
        }

        public void insertOrderDetail(DTO_OrderDetail dtoOrderDetail)
        {
            string sql = "INSERT INTO M_ORDER_DETAIL VALUES (" +
                ""+ dtoOrderDetail.ID_ORDER + ", " +
                "" + dtoOrderDetail.ID_PRODUCT + ", " +
                "" + dtoOrderDetail.QUANTITY+ ", " +
                "" + dtoOrderDetail.AMOUNT + ")";

            DBAccess.RunSQL(sql);
        }

        public void reduceProductQuantity(int productId, int newQuantity)
        {
            string sql = "update M_PRODUCT set QUANTITY = '" + newQuantity + "' where ID = "+ productId + "";

            DBAccess.RunSQL(sql);
        }

        public DataTable getOrderByStaffId(int staffId)
        {
            string sql = "select * from M_ORDER where ID_STAFF = '" + staffId + "'";

            return DBAccess.GetDataToTable(sql);
        }

        public DataTable getAllOrder()
        {
            string sql = "select * from M_ORDER";

            return DBAccess.GetDataToTable(sql);
        }
    }
}
