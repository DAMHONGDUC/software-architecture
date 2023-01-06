using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19120481_QLBH.DTO
{
    public class DTO_Customer
    {
        private string _id;
        private string _fullname;
        private string _sdt;

        public string id { get { return _id; } set { _id = value; } }
        public string fullname { get { return _fullname; } set { _fullname = value; } }
        public string sdt { get { return _sdt; } set { _sdt = value; } }

        public DTO_Customer(string id, string fullname, string sdt)
        {
            _id = id;
            _fullname = fullname;
            _sdt = sdt;
        }
        public DTO_Customer(string fullname, string sdt)
        {        
            _fullname = fullname;
            _sdt = sdt;
        }
    }
}
