using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_WINFORM.payOSLIb
{
    public class PaymentLinkInformation
    {
        public string id { set; get; }
        public int orderCode { set; get; }
        public int amount { set; get; }
        public int amountPaid { set; get; }
        public int amountRemaining { set; get; }
        public string status { set; get; }
        public string createdAt { set; get; }
        public List<Transaction> transactions { set; get; }
        public string canceledAt { set; get; }
        public string cancellationReason { set; get; }
    }
}
