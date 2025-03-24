using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_WINFORM.payOSLIb
{
    public class PayOSError : Exception
    {
        public string Code { get; }

        public PayOSError(string code, string message)
            : base(message)
        {
            Code = code;
        }
    }
}
