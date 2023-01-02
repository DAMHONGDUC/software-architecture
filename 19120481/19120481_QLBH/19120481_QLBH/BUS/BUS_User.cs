using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19120481_QLBH.DAO;
using _19120481_QLBH.DTO;

namespace _19120481_QLBH.BUS
{
    class BUS_User
    {
        DAO_User daoUser = new DAO_User();

        public BUS_User()
        {
        }

        public bool ConnectDB()
        {
            return daoUser.ConnectDB();
        }

        public DTO_User Login(string username, string password)
        {
            return daoUser.Login(username, password);
        }
    }
}
