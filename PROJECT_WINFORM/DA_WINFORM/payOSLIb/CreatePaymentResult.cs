using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_WINFORM.payOSLIb
{
    public class CreatePaymentResult
    {
        public string bin { get; set; }
        public string accountNumber { get; set; }
        public int amount { get; set; }
        public string description { get; set; }
        public int orderCode { get; set; }
        public string paymentLinkId { get; set; }
        public string status { get; set; }
        public string checkoutUrl { get; set; }
        public string qrCode { get; set; }
    }
}