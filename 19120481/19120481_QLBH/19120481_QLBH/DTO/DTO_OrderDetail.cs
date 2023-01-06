using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19120481_QLBH.DTO
{
    public class DTO_OrderDetail
    {
        private int _ID_ORDER;
        private int _ID_PRODUCT;
        private int _QUANTITY;
        private float _AMOUNT;

        public int ID_ORDER { get { return _ID_ORDER; } set { _ID_ORDER = value; } }
        public int ID_PRODUCT { get { return _ID_PRODUCT; } set { _ID_PRODUCT = value; } }
        public int QUANTITY { get { return _QUANTITY; } set { _QUANTITY = value; } }
        public float AMOUNT { get { return _AMOUNT; } set { _AMOUNT = value; } }

        public DTO_OrderDetail(int iD_ORDER, int iD_PRODUCT, int qUANTITY, float aMOUNT)
        {
            _ID_ORDER = iD_ORDER;
            _ID_PRODUCT = iD_PRODUCT;
            _QUANTITY = qUANTITY;
            _AMOUNT = aMOUNT;
        }
    }
}
