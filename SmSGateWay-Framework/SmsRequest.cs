using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmSGateWay_Framework
{

    public class SmsRequest
    {
        public string Text { get; set; }
        [JsonIgnore] public string[] Receiver { get; set; }
        public string Accountid { get; set; }
        public string Password { get; set; }
        public string Hmac { get; internal set; }
        public string Sender { get; set; }


        public dynamic To => ConvertReceiver();

        private dynamic ConvertReceiver()
        {
            var result = Receiver.Select((data, i) => new Dictionary<string, string> { { $"{i + 1}", data } }).ToList();
            return result;
        }

        public StringContent ToJson()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new SnakeCaseNamingPolicy(),
                WriteIndented = false
            };
            Hmac = HashMessage();

            var json = JsonSerializer.Serialize(this, options);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private string HashMessage()
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(Accountid);
            var token = Guid.NewGuid().ToString();
            byte[] messageBytes = Encoding.UTF8.GetBytes($"{Accountid}&{Password}&{Accountid}");

            byte[] hashBytes;

            using (HMACSHA256 hmac = new HMACSHA256())
            {
                hashBytes = hmac.ComputeHash(messageBytes);
            }

            string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            return hash;
        }
    }
}
