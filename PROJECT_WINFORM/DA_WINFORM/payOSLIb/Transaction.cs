using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_WINFORM.payOSLIb
{

    public class Transaction
    {
        public string reference { get; }
        public int amount { get; }
        public string accountNumber { get; }
        public string description { get; }
        public string transactionDateTime { get; }
        public string virtualAccountName { get; }
        public string virtualAccountNumber { get; }
        public string counterAccountBankId { get; }
        public string counterAccountBankName { get; }
        public string counterAccountName { get; }
        public string counterAccountNumber { get; }
    }
}

