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

        public DataTable getAllStaff()
        {
            return daoUser.getAllStaff();
        }

        public int insertUser(DTO_User user)
        {
            return daoUser.insertUser(user);
        }

        public void updateUser(DTO_User user)
        {
            daoUser.updateUser(user);
        }
    }
}
