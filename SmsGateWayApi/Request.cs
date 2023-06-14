using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace SmsGateWayApi;

public class SmsRequest
{

    public string Text { get; set; }
    public string To { get; set; }
    public string Accountid { get; set; }
    public string Password { get; set; }
    public string Hmac { get; internal set; }
    public string Sender { get; set; }

    public StringContent ToJson()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = new SnakeCaseNamingPolicy(),
            WriteIndented = true
        };
        Hmac = HashMessage();

        var json = JsonSerializer.Serialize(this,options);
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