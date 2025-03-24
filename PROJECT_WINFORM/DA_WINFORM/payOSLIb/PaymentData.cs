using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_WINFORM.payOSLIb
{
    public class PaymentData
    {
        public int orderCode { get; set; }
        public int amount { get; set; }
        public string description { get; set; }
        public List<ItemData> items { get; set; }
        public string cancelUrl { get; set; }
        public string returnUrl { get; set; }
        public string signature { get; set; }
        public string buyerName { get; set; }
        public string buyerEmail { get; set; }
        public string buyerPhone { get; set; }
        public string buyerAddress { get; set; }
        public int? expiredAt { get; set; }

        public PaymentData(int _orderCode, int _amount, string _description, List<ItemData> _items, string _cancelUrl, string _returnUrl)
        {
            orderCode = _orderCode;
            amount = _amount;
            description = _description;
            items = _items;
            cancelUrl = _cancelUrl;
            returnUrl = _returnUrl;
        }

      
        public PaymentData()
        {
            
        }
    }
 }
