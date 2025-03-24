using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_WINFORM.payOSLIb
{

    public class ItemData
    {
        public string name { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }

        public ItemData(string _name, int _quantity, int _price)
        {
            name = _name;
            quantity = _quantity;
            price = _price;
        }
    }
}
