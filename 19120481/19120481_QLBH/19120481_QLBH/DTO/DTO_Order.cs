using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19120481_QLBH.DTO
{
    public class DTO_Order
    {
        private int _ID_CUSTOMER;
        private int _ID_STAFF;
        private string _DELIVERY_ADDRESS;
        private string _DELIVERY_DATE;
        private string _RECIPIENT_NAME;
        private string _RECIPIENT_PHONE;
        private string _DATE_CREATED;
        private int _ORDER_STATUS;
        private int _PAYMENT_TYPE;
        private float _DELIVERY_COST;
        private float _TOTAL_MONEY;

        public int ID_CUSTOMER { get { return _ID_CUSTOMER; } set { _ID_CUSTOMER = value; } }
        public int ID_STAFF { get { return _ID_STAFF; } set { _ID_STAFF = value; } }
        public string DELIVERY_ADDRESS { get { return _DELIVERY_ADDRESS; } set { _DELIVERY_ADDRESS = value; } }
        public string DELIVERY_DATE { get { return _DELIVERY_DATE; } set { _DELIVERY_DATE = value; } }
        public string RECIPIENT_NAME { get { return _RECIPIENT_NAME; } set { _RECIPIENT_NAME = value; } }
        public string RECIPIENT_PHONE { get { return _RECIPIENT_PHONE; } set { _RECIPIENT_PHONE = value; } }
        public string DATE_CREATED { get { return _DATE_CREATED; } set { _DATE_CREATED = value; } }
        public int ORDER_STATUS { get { return _ORDER_STATUS; } set { _ORDER_STATUS = value; } }
        public int PAYMENT_TYPE { get { return _PAYMENT_TYPE; } set { _PAYMENT_TYPE = value; } }
        public float DELIVERY_COST { get { return _DELIVERY_COST; } set { _DELIVERY_COST = value; } }
        public float TOTAL_MONEY { get { return _TOTAL_MONEY; } set { _TOTAL_MONEY = value; } }

        public DTO_Order(int iD_CUSTOMER, int iD_STAFF, string dELIVERY_ADDRESS, string dELIVERY_DATE, string rECIPIENT_NAME, string rECIPIENT_PHONE, string dATE_CREATED, int oRDER_STATUS, int pAYMENT_TYPE, float dELIVERY_COST, float tOTAL_MONEY)
        {
            _ID_CUSTOMER = iD_CUSTOMER;
            _ID_STAFF = iD_STAFF;
            _DELIVERY_ADDRESS = dELIVERY_ADDRESS;
            _DELIVERY_DATE = dELIVERY_DATE;
            _RECIPIENT_NAME = rECIPIENT_NAME;
            _RECIPIENT_PHONE = rECIPIENT_PHONE;
            _DATE_CREATED = dATE_CREATED;
            _ORDER_STATUS = oRDER_STATUS;
            _PAYMENT_TYPE = pAYMENT_TYPE;
            _DELIVERY_COST = dELIVERY_COST;
            _TOTAL_MONEY = tOTAL_MONEY;
        }

        public DTO_Order(int iD_STAFF, string dELIVERY_ADDRESS, string dELIVERY_DATE, string rECIPIENT_NAME, string rECIPIENT_PHONE,  string dATE_CREATED, int oRDER_STATUS, int pAYMENT_TYPE, float dELIVERY_COST, float tOTAL_MONEY)
        {
            _ID_STAFF = iD_STAFF;
            _DELIVERY_ADDRESS = dELIVERY_ADDRESS;
            _DELIVERY_DATE = dELIVERY_DATE;
            _RECIPIENT_PHONE = rECIPIENT_PHONE;
            _RECIPIENT_NAME = rECIPIENT_NAME;
            _DATE_CREATED = dATE_CREATED;
            _ORDER_STATUS = oRDER_STATUS;
            _PAYMENT_TYPE = pAYMENT_TYPE;
            _DELIVERY_COST = dELIVERY_COST;
            _TOTAL_MONEY = tOTAL_MONEY;
        }
    }
}
