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
    class BUS_Product
    {
        DAO_Product daoProduct = new DAO_Product();

        public DataTable getAllProduct()
        {
            return daoProduct.getAllProduct();
        }

        public DataTable searchByName(string name)
        {
            return daoProduct.searchByName(name);
        }

        public int insertProduct(DTO_Product product)
        {
            return daoProduct.insertProduct(product);
        }

        public void updateProduct(DTO_Product product)
        {
            daoProduct.updateProduct(product);
        }

        public void deleteProduct(int id)
        {
            daoProduct.deleteProduct(id);
        }
    }
}
