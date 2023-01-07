using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19120481_QLBH.DTO
{
    public class DTO_User
    {
        private int _id;
        private string _fullname;
        private DateTime _dob;
        private int _role;
        private string _username;
        private string _password;

        public string password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public string username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }

        public int id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string fullname
        {
            get
            {
                return _fullname;
            }

            set
            {
                _fullname = value;
            }
        }

        public DateTime dob
        {
            get
            {
                return _dob;
            }

            set
            {
                _dob = value;
            }
        }

        public int role
        {
            get
            {
                return _role;
            }

            set
            {
                _role = value;
            }
        }

        public DTO_User() { }

        public DTO_User(int id, string fullname, DateTime dob, int role)
        {
            this.id = id;
            this.fullname = fullname;
            this.dob = dob;
            this.role = role;
        }

        public DTO_User(string fullname, DateTime dob, int role, string username, string password)
        {
            _fullname = fullname;
            _dob = dob;
            _role = role;
            _username = username;
            _password = password;
        }

        public DTO_User(int id, string fullname, DateTime dob, int role, string username, string password)
        {
            _id = id;
            _fullname = fullname;
            _dob = dob;
            _role = role;
            _username = username;
            _password = password;
        }
    }
}
