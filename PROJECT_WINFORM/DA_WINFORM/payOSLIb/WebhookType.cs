using DA_WINFORM.payOSLIb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_WINFORM
{
    public class WebhookType
    {
        public string code { get; }
        public string desc { get; }
        public WebhookData data { get; }
        public string signature { get; }
    }
}
