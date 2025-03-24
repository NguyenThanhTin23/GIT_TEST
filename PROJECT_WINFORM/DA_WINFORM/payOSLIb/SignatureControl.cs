using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DA_WINFORM.payOSLIb
{
    public class SignatureControl
    {
        private static string ConvertObjToQueryStr(JObject obj)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (JProperty item in obj.Properties())
            {
                string name = item.Name;
                JToken value = item.Value;
                string value2 = "";
                if (value.Type == JTokenType.Date)
                {
                    value2 = ((DateTime)value).ToString("yyyy-MM-ddTHH:mm:sszzz");
                }
                else if (value.Type == JTokenType.String)
                {
                    value2 = value.Value<string>();
                }
                else if (value.Type == JTokenType.Array)
                {
                    value2 = "[";
                    bool flag = false;
                    foreach (JObject item2 in (IEnumerable<JToken>)value)
                    {
                        if (flag)
                        {
                            value2 += ",";
                        }

                        value2 += SortObjDataByKey(item2).ToString(Formatting.None);
                        flag = true;
                    }

                    value2 += "]";
                }
                else if (value.Type != JTokenType.Null)
                {
                    value2 = value.ToString();
                }

                if (stringBuilder.Length > 0)
                {
                    stringBuilder.Append('&');
                }

                stringBuilder.Append(name).Append('=').Append(value2);
            }

            return stringBuilder.ToString();
        }

        private static JObject SortObjDataByKey(JObject obj)
        {
            if (obj.Type != JTokenType.Object)
            {
                return obj;
            }

            return new JObject(from x in obj.Properties()
                               orderby x.Name
                               select x);
        }

        private static string GenerateHmacSHA256(string dataStr, string key)
        {

            HMACSHA256 hMACSHA = new HMACSHA256(Encoding.UTF8.GetBytes(key));
            byte[] array = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(dataStr));
            StringBuilder stringBuilder = new StringBuilder();
            byte[] array2 = array;
            foreach (byte b in array2)
            {
                stringBuilder.Append(b.ToString("x2"));
            }

            return stringBuilder.ToString();

        }

        public static string CreateSignatureFromObj(JObject data, string key)
        {
            JObject obj = SortObjDataByKey(data);
            string dataStr = ConvertObjToQueryStr(obj);
            return GenerateHmacSHA256(dataStr, key);
        }

        public static string CreateSignatureOfPaymentRequest(PaymentData data, string key)
        {
            int amount = data.amount;
            string cancelUrl = data.cancelUrl;
            string description = data.description;
            string value = data.orderCode.ToString();
            string returnUrl = data.returnUrl;
            string dataStr = $"amount={amount}&cancelUrl={cancelUrl}&description={description}&orderCode={value}&returnUrl={returnUrl}";
            return GenerateHmacSHA256(dataStr, key);
        }
    }
}
