using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DA_WINFORM.payOSLIb
{
    public class PayOS
    {
        private readonly string _clientId;

        private readonly string _apiKey;

        private readonly string _checksumKey;

        public PayOS(string clientId, string apiKey, string checksumKey)
        {
            _clientId = clientId;
            _apiKey = apiKey;
            _checksumKey = checksumKey;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        public async Task<CreatePaymentResult> createPaymentLink(PaymentData paymentData)
        {
            string signature = SignatureControl.CreateSignatureOfPaymentRequest(paymentData, _checksumKey);
            string url = "https://api-merchant.payos.vn/v2/payment-requests";
            paymentData.signature = signature;
            string jsonString = JsonConvert.SerializeObject(paymentData);
            HttpClient httpClient = new HttpClient();
            JObject responseBodyJson = JObject.Parse(await (await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(jsonString, Encoding.UTF8, "application/json"),
                Headers =
            {
                { "x-client-id", _clientId },
                { "x-api-key", _apiKey }
            }
            })).Content.ReadAsStringAsync());
            string code = responseBodyJson["code"]?.ToString();
            string desc = responseBodyJson["desc"]?.ToString();
            string data = responseBodyJson["data"]?.ToString();
            if (code == null)
            {
                throw new PayOSError("20", "Internal Server Error.");
            }

            if (code == "00" && data != null)
            {
                JObject dataJson = JObject.Parse(data);
                string paymentLinkResSignature = SignatureControl.CreateSignatureFromObj(dataJson, _checksumKey);
                if (paymentLinkResSignature != responseBodyJson["signature"].ToString())
                {
                    throw new Exception("The data is unreliable because the signature of the response does not match the signature of the data");
                }

                CreatePaymentResult response = JsonConvert.DeserializeObject<CreatePaymentResult>(data);
                if (response == null)
                {
                    throw new InvalidOperationException("Error deserializing JSON response: Deserialized object is null.");
                }

                return response;
            }

            throw new PayOSError(code, desc);
        }

        public async Task<PaymentLinkInformation> getPaymentLinkInfomation(int orderId)
        {
            string url = "https://api-merchant.payos.vn/v2/payment-requests/" + orderId;
            HttpClient httpClient = new HttpClient();
            JObject responseBodyJson = JObject.Parse(await (await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, url)
            {
                Headers =
                {
                { "x-client-id", _clientId },
                { "x-api-key", _apiKey }
            }
            })).Content.ReadAsStringAsync());
            string code = responseBodyJson["code"]?.ToString();
            string desc = responseBodyJson["desc"]?.ToString();
            string data = responseBodyJson["data"]?.ToString();
            if (code == null)
            {
                throw new PayOSError("20", "Internal Server Error.");
            }

            if (code == "00" && data != null)
            {
                JObject dataJson = JObject.Parse(data);
                string paymentLinkResSignature = SignatureControl.CreateSignatureFromObj(dataJson, _checksumKey);
                if (paymentLinkResSignature != responseBodyJson["signature"].ToString())
                {
                    throw new Exception("The data is unreliable because the signature of the response does not match the signature of the data");
                }

                PaymentLinkInformation response = JsonConvert.DeserializeObject<PaymentLinkInformation>(data);
                if (response == null)
                {
                    throw new InvalidOperationException("Error deserializing JSON response: Deserialized object is null.");
                }

                return response;
            }

            throw new PayOSError(code, desc);
        }

        public async Task<string> confirmWebhook(string webhookUrl)
        {
            if (webhookUrl == null || webhookUrl.Length == 0)
            {
                throw new Exception("Invalid Parameter.");
            }

            string url = "https://api-merchant.payos.vn/confirm-webhook";
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage responseApi = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent("{\"webhookUrl\": \"" + webhookUrl + "\"}", Encoding.UTF8, "application/json"),
                Headers =
            {
                { "x-client-id", _clientId },
                { "x-api-key", _apiKey }
            }
            });
            if (responseApi.IsSuccessStatusCode)
            {
                return webhookUrl;
            }

            if (responseApi.StatusCode == HttpStatusCode.NotFound)
            {
                throw new PayOSError("20", "Webhook URL invalid.");
            }

            if (responseApi.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new PayOSError("401", "Unauthorized.");
            }

            throw new PayOSError("20", "Internal Server Error.");
        }

        public async Task<PaymentLinkInformation> cancelPaymentLink(int orderId, string cancellationReason = null)
        {
            string url = "https://api-merchant.payos.vn/v2/payment-requests/" + orderId + "/cancel";
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            if (cancellationReason != null)
            {
                request.Content = new StringContent("{\"cancellationReason\": \"" + cancellationReason + "\"}", Encoding.UTF8, "application/json");
            }

            request.Headers.Add("x-client-id", _clientId);
            request.Headers.Add("x-api-key", _apiKey);
            JObject responseBodyJson = JObject.Parse(await (await httpClient.SendAsync(request)).Content.ReadAsStringAsync());
            string code = responseBodyJson["code"]?.ToString();
            string desc = responseBodyJson["desc"]?.ToString();
            string data = responseBodyJson["data"]?.ToString();
            if (code == null)
            {
                throw new PayOSError("20", "Internal Server Error.");
            }

            if (code == "00" && data != null)
            {
                JObject dataJson = JObject.Parse(data);
                string paymentLinkResSignature = SignatureControl.CreateSignatureFromObj(dataJson, _checksumKey);
                if (paymentLinkResSignature != responseBodyJson["signature"].ToString())
                {
                    throw new Exception("The data is unreliable because the signature of the response does not match the signature of the data");
                }

                PaymentLinkInformation response = JsonConvert.DeserializeObject<PaymentLinkInformation>(data);
                if (response == null)
                {
                    throw new InvalidOperationException("Error deserializing JSON response: Deserialized object is null.");
                }

                return response;
            }

            throw new PayOSError(code, desc);
        }

        public WebhookData verifyPaymentWebhookData(WebhookType webhookBody)
        {
            WebhookData data = webhookBody.data;
            string signature = webhookBody.signature;
            if (data == null)
            {
                throw new Exception("No data.");
            }

            if (signature == null)
            {
                throw new Exception("No signature.");
            }

            string text = SignatureControl.CreateSignatureFromObj(JObject.FromObject(data), _checksumKey);
            if (text != signature)
            {
                throw new Exception("The data is unreliable because the signature of the response does not match the signature of the data");
            }

            return data;
        }

        
    }
}
