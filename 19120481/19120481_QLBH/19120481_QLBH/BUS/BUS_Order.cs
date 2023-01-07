using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19120481_QLBH.DAO;
using _19120481_QLBH.DTO;
using System.Data;

namespace _19120481_QLBH.BUS
{ 
    public class BUS_Order
    {
        DAO_Order daoOrder = new DAO_Order();

        public int insertOrder(DTO_Order dtoOrder)
        {
            return daoOrder.insertOrder(dtoOrder);
        }

        public void insertOrderDetail(DTO_OrderDetail dtoOrderDetail)
        {
            daoOrder.insertOrderDetail(dtoOrderDetail);
        }

        public void reduceProductQuantity(int productId, int newQuantity)
        {
            daoOrder.reduceProductQuantity(productId, newQuantity);
        }

        public DataTable getOrderByStaffId(int staffId)
        {
            return daoOrder.getOrderByStaffId(staffId);
        }

        public DataTable getAllOrder()
        {
            return daoOrder.getAllOrder();
        }
    }
}
