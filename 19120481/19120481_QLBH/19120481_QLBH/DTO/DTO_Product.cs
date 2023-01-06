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
        private int _quantity;
        private float _price;
        private string _image;

        public int id { get { return _id; } set { _id = value; } }
        public string name { get { return _name; } set { _name = value; } }
        public string description { get { return _description; } set { _description = value; } }
        public int quantity { get { return _quantity; } set { _quantity = value; } }
        public float price { get { return _price; } set { _price = value; } }
        public string image { get { return _image; } set { _image = value; } }

        public DTO_Product(int id, string name, string description, int quantity, float price, string image)
        {
            this._id = id;
            this._name = name;
            this._description = description;
            this._quantity = quantity;
            this._price = price;
            this._image = image;
        }


    }
}
