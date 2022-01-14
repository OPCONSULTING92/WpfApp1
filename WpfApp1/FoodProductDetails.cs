using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class FoodProductDetails
    {
        public int code;
        public Product produit;
    }

    class Product
    {
        public int ID;
        public string[]  _keywords ;
        public string abbreviated_product_name;
    }
}
