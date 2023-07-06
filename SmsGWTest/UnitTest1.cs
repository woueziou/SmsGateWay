using SmsGateWayApi;

namespace SmsGWTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task TestSendSms()
    {
        var lampSms = new LampushGateWay("account_id", "password", "LAM");
        try
        {
             lampSms.SendMessage("Test not awaited", "+22890913661").GetAwaiter().GetResult();
         
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Assert.Fail();
        }
    }
        [Test]
    public void TestRequestClass()
    {
        var request = new SmsRequest
        {
            Accountid = "A",
            Password = "Pass",Sender = "Taas",Text = "Hello world",Receiver = new []{"90913661","98498611"},
        };
        var result = request.ToJson();
        Console.WriteLine(result);
    }
}