using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace _19120481_QLBH.DTO
{
    public class DTO_Product
    {
        private int _id;
        private string _name;
        private string _description;
        private string _image;
        private int _quantity;
        private float _price;

        public int id { get { return _id; } set { _id = value; } }
        public string name { get { return _name; } set { _name = value; } }
        public string description { get { return _description; } set { _description = value; } }

        public string image { get { return _image; } set { _image = value; } }
        public int quantity { get { return _quantity; } set { _quantity = value; } }
        public float price { get { return _price; } set { _price = value; } }

        public DTO_Product(int id, string name, string description, string image, int quantity, float price)
        {
            _id = id;
            _name = name;
            _description = description;
            _image = image;
            _quantity = quantity;
            _price = price;
        }

        public DTO_Product(string name, string description, string image, int quantity, float price)
        {
            _name = name;
            _description = description;
            _image = image;
            _quantity = quantity;
            _price = price;
        }
    }
}
