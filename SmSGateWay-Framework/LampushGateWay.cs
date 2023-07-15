using System.Net;
using System.Net.Http;

namespace SmSGateWay_Framework;

public class LampushGateWay
{
    private readonly string _accountId;
    private readonly string _password;
    private readonly HttpClient _httpClient;
    private readonly string _sender;
    private readonly string _lampushServer = "https://lampush-json.lafricamobile.com";

    public LampushGateWay(string accountId, string password, string sender)
    {
        _accountId = accountId;
        _password = password;
        _sender = sender;
        _httpClient = new HttpClient{BaseAddress =new Uri(_lampushServer)};
    }

    public async Task SendMessage(string message, string receiver)
    {
        var data = new SmsRequest
        {
            Accountid = _accountId,
            Password = _password,
            Receiver =new []{receiver},
            Text = message,
            Sender = _sender
        };
        try
        {
            var dataJson = data.ToJson();
            var response = await _httpClient.PostAsync("/sms/push", dataJson);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Console.Write("Message sent");
            }
            else
            {
                var result = await response.Content.ReadAsStringAsync();
                var msg =await response.RequestMessage?.Content.ReadAsStringAsync();
            }
        }
        catch (Exception e)
        {
            HandleError(e);
        }
    }

    public void CheckCredit()
    {
    }


    private string HandleError(Exception exception)
    {
        Console.WriteLine(exception);
        throw exception;
    }
}