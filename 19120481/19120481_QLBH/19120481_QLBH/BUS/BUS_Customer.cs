using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using _19120481_QLBH.DAO;
using _19120481_QLBH.DTO;

namespace _19120481_QLBH.BUS
{
    public class BUS_Customer
    {
        DAO_Customer daoCustomer = new DAO_Customer();
        public DataTable getCustomer(string sdt)
        {
            return daoCustomer.getCustomer(sdt);
        }

        public int insertCustomer(DTO_Customer dtoCustomer)
        {
            return daoCustomer.insertCustomer(dtoCustomer);
        }
    }
}
